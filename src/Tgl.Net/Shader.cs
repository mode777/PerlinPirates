﻿using System;
using System.Collections.Generic;
using System.Text;
using Tgl.Net.Bindings;
using Tgl.Net.Math;

namespace Tgl.Net
{
    public class Shader : IDisposable
    {
        private readonly IGlState _state;
        private Dictionary<string, ShaderVariableInfo> _uniformsByName;
        private Dictionary<string, ShaderVariableInfo> _attributesByName;

        public Shader(IGlState state)
        {
            _state = state;
            Handle = GL.glCreateProgram();
        }

        public uint Handle { get; }

        public void CompileAndLink(string vertexSource, string fragmentSource)
        {
            StringBuilder infolog = new StringBuilder(1024);
            infolog.EnsureCapacity(1024);
            int infologLength;

            var vertexShader = GL.glCreateShader(GL.ShaderType.GL_VERTEX_SHADER);
            GL.ShaderSource(vertexShader, new[] { vertexSource });
            GL.glCompileShader(vertexShader);
            GL.glGetShaderiv(vertexShader, GL.ShaderParameterName.GL_COMPILE_STATUS, out var compiled);
            if (compiled == 0)
            {
                GL.glGetShaderInfoLog(vertexShader, 1024, out infologLength, infolog);
                throw new InvalidProgramException(infolog.ToString());
            }

            var fragmentShader = GL.glCreateShader(GL.ShaderType.GL_FRAGMENT_SHADER);
            GL.ShaderSource(fragmentShader, new[] { fragmentSource });
            GL.glCompileShader(fragmentShader);
            GL.glGetShaderiv(fragmentShader, GL.ShaderParameterName.GL_COMPILE_STATUS, out compiled);
            if (compiled == 0)
            {
                GL.glGetShaderInfoLog(fragmentShader, 1024, out infologLength, infolog);
                throw new InvalidProgramException(infolog.ToString());
            }

            GL.glAttachShader(Handle, vertexShader);
            GL.glAttachShader(Handle, fragmentShader);
            GL.glLinkProgram(Handle);
            GL.glGetProgramiv(Handle, GL.ProgramPropertyARB.GL_LINK_STATUS, out var linked);
            if (linked == 0)
            {
                GL.glGetProgramInfoLog(Handle, 1024, out infologLength, infolog);
                throw new InvalidProgramException(infolog.ToString());
            }

            GL.glDeleteShader(vertexShader);
            GL.glDeleteShader(fragmentShader);

            Use();
            CollectAttributeInformation();
            CollectUniformInformation();
        }

        public void Use()
        {
            _state.CurrentProgram = Handle;
        }

        public int GetUniformLocation(string name)
        {
            return _uniformsByName[name].Location;
        }

        public int GetAttributeLocation(string name)
        {
            return _attributesByName[name].Location;
        }

        public void SetUniform(int location, float value)
        {
            Use();
            GL.glUniform1f(location, value);
        }

        public void SetUniform(int location, GL.TextureUnit unit)
        {
            Use();
            int value = (int)(unit - GL.TextureUnit.GL_TEXTURE0);
            GL.glUniform1i(location, value);
        }

        public void SetUniform(int location, int value)
        {
            Use();
            GL.glUniform1i(location, value);
        }

        public void SetUniform(string name, float value) 
            => SetUniform(_uniformsByName[name].Location, value);

        public void SetUniform(int location, Vector2 value)
        {
            Use();
            GL.glUniform2f(location, value.X, value.Y);
        }
        public void SetUniform(string name, Vector2 value) 
            => SetUniform(_uniformsByName[name].Location, value);

        public void SetUniform(int location, Vector3 value)
        {
            Use();
            GL.glUniform3f(location, value.X, value.Y, value.Z);
        }
        public void SetUniform(string name, Vector3 value) 
            => SetUniform(_uniformsByName[name].Location, value);

        public void SetUniform(int location, Vector4 value)
        {
            Use();
            GL.glUniform4f(location, value.X, value.Y, value.Z, value.W);
        }
        public void SetUniform(string name, Vector4 value) 
            => SetUniform(_uniformsByName[name].Location, value);

        public void SetUniform(int location, Matrix2 value)
        {
            Use();

            GL.glUniformMatrix2fv(location, 1, false, ref value);
        }
        public void SetUniform(string name, Matrix2 value) 
            => SetUniform(_uniformsByName[name].Location, value);

        public void SetUniform(int location, Matrix3 value)
        {
            Use();

            GL.glUniformMatrix3fv(location, 1, false, ref value);
        }

        public void SetUniform(string name, Matrix3 value) 
            => SetUniform(_uniformsByName[name].Location, value);

        public void SetUniform(int location, Matrix4 value)
        {
            Use();
            GL.glUniformMatrix4fv(location, 1, false, ref value);
        }

        public void SetUniform(string name, Matrix4 value) 
            => SetUniform(_uniformsByName[name].Location, value);

        public void Dispose()
        {
            GL.glDeleteProgram(Handle);
        }

        private void CollectUniformInformation()
        {
            _uniformsByName = new Dictionary<string, ShaderVariableInfo>();

            GL.glGetProgramiv(Handle, GL.ProgramPropertyARB.GL_ACTIVE_UNIFORMS, out var uniforms);

            StringBuilder nameBuffer = new StringBuilder(1024);

            nameBuffer.EnsureCapacity(1024);
            int namebufferLength;

            for (uint i = 0; i < uniforms; i++)
            {
                int size;
                GL.AttributeType type;
                GL.glGetActiveUniform(Handle, i, 1024, out namebufferLength, out size, out type, nameBuffer);
                var name = nameBuffer.ToString();
                var location = GL.glGetUniformLocation(Handle, name);
                _uniformsByName[nameBuffer.ToString()] = new ShaderVariableInfo
                {
                    Location = location,
                    Name = name,
                    Size = size,
                    Type = type
                };
            }
        }

        private void CollectAttributeInformation()
        {
            _attributesByName = new Dictionary<string, ShaderVariableInfo>();

            GL.glGetProgramiv(Handle, GL.ProgramPropertyARB.GL_ACTIVE_ATTRIBUTES, out var attributes);

            StringBuilder nameBuffer = new StringBuilder(1024);
            nameBuffer.EnsureCapacity(1024);
            int namebufferLength;

            for (uint i = 0; i < attributes; i++)
            {
                int size;
                GL.AttributeType type;
                GL.glGetActiveAttrib(Handle, i, 1024, out namebufferLength, out size, out type, nameBuffer);
                var name = nameBuffer.ToString();
                var location = GL.glGetAttribLocation(Handle, name);
                _attributesByName[nameBuffer.ToString()] = new ShaderVariableInfo
                {
                    Location = location,
                    Name = name,
                    Size = size,
                    Type = type
                };
            }
        }

        private class ShaderVariableInfo
        {
            public string Name { get; set; }
            public int Location { get; set; }
            public int Size { get; set; }
            public GL.AttributeType Type { get; set; }
        }
    }
}