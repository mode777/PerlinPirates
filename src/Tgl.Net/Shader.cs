﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Tgl.Net.Helpers;
using Tgl.Net.Math;
using static Tgl.Net.GL;

namespace Tgl.Net.Core
{
    public class ShaderBuilder
    {
        private readonly IGlState _state;

        internal ShaderBuilder(IGlState state)
        {
            _state = state;
        }

        internal string VertexSource { get; private set; }
        internal string FragmentSource { get; private set; }

        public ShaderBuilder WithVertexFile(string path)
        {
            return WithVertexString(File.ReadAllText(path));
        }

        public ShaderBuilder WithVertexString(string shader)
        {
            VertexSource = shader;
            return this;
        }

        public ShaderBuilder WithVertexResource(string path)
        {
            return WithVertexString(
                ResourceHelpers.GetResourceString(Assembly.GetCallingAssembly(), path));
        }

        public ShaderBuilder WithFragmentResource(string path)
        {
            return WithFragmentString(
                ResourceHelpers.GetResourceString(Assembly.GetCallingAssembly(), path));

        }

        public ShaderBuilder WithFragmentFile(string path)
        {
            return WithFragmentString(File.ReadAllText(path));
        }

        public ShaderBuilder WithFragmentString(string shader)
        {
            FragmentSource = shader;
            return this;
        }

        public Shader Build()
        {
            return new Shader(_state, this);
        }
    }

    public class Shader : IDisposable
    {
        private readonly IGlState _state;
        private readonly uint _handle;
        private readonly Dictionary<string, ShaderVariableInfo> _uniformsByName
            = new Dictionary<string, ShaderVariableInfo>();
        private readonly Dictionary<string, ShaderVariableInfo> _attributesByName
            = new Dictionary<string, ShaderVariableInfo>();

        internal Shader(IGlState state, ShaderBuilder builder)
        {
            _state = state;

            StringBuilder infolog = new StringBuilder(1024);
            infolog.EnsureCapacity(1024);
            int infologLength;

            var vertexShader = glCreateShader(ShaderType.GL_VERTEX_SHADER);
            ShaderSource(vertexShader, new[] { builder.VertexSource });
            glCompileShader(vertexShader);
            glGetShaderiv(vertexShader, ShaderParameterName.GL_COMPILE_STATUS, out var compiled);
            if (compiled == 0)
            {
                glGetShaderInfoLog(vertexShader, 1024, out infologLength, infolog);
                throw new InvalidProgramException(infolog.ToString());
            }

            var fragmentShader = glCreateShader(ShaderType.GL_FRAGMENT_SHADER);
            ShaderSource(fragmentShader, new[] { builder.FragmentSource });
            glCompileShader(fragmentShader);
            glGetShaderiv(fragmentShader, ShaderParameterName.GL_COMPILE_STATUS, out compiled);
            if (compiled == 0)
            {
                glGetShaderInfoLog(fragmentShader, 1024, out infologLength, infolog);
                throw new InvalidProgramException(infolog.ToString());
            }

            _handle = glCreateProgram();
            glAttachShader(_handle, vertexShader);
            glAttachShader(_handle, fragmentShader);
            glLinkProgram(_handle);
            glGetProgramiv(_handle, ProgramPropertyARB.GL_LINK_STATUS, out var linked);
            if (linked == 0)
            {
                glGetProgramInfoLog(_handle, 1024, out infologLength, infolog);
                throw new InvalidProgramException(infolog.ToString());
            }

            glDeleteShader(vertexShader);
            glDeleteShader(fragmentShader);

            Use();
            CollectAttributeInformation();
            CollectUniformInformation();
        }

        public void Use()
        {
            _state.CurrentProgram = _handle;
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
            glUniform1f(location, value);
        }

        public void SetUniform(string name, float value) 
            => SetUniform(_uniformsByName[name].Location, value);

        public void SetUniform(int location, Vector2 value)
        {
            Use();
            glUniform2f(location, value.X, value.Y);
        }
        public void SetUniform(string name, Vector2 value) 
            => SetUniform(_uniformsByName[name].Location, value);

        public void SetUniform(int location, Vector3 value)
        {
            Use();
            glUniform3f(location, value.X, value.Y, value.Z);
        }
        public void SetUniform(string name, Vector3 value) 
            => SetUniform(_uniformsByName[name].Location, value);

        public void SetUniform(int location, Vector4 value)
        {
            Use();
            glUniform4f(location, value.X, value.Y, value.Z, value.W);
        }
        public void SetUniform(string name, Vector4 value) 
            => SetUniform(_uniformsByName[name].Location, value);

        public void SetUniform(int location, Matrix2 value)
        {
            Use();

            glUniformMatrix2fv(location, 1, false, ref value);
        }
        public void SetUniform(string name, Matrix2 value) 
            => SetUniform(_uniformsByName[name].Location, value);

        public void SetUniform(int location, Matrix3 value)
        {
            Use();

            glUniformMatrix3fv(location, 1, false, ref value);
        }

        public void SetUniform(string name, Matrix3 value) 
            => SetUniform(_uniformsByName[name].Location, value);

        public void SetUniform(int location, Matrix4 value)
        {
            Use();
            glUniformMatrix4fv(location, 1, false, ref value);
        }

        public void SetUniform(string name, Matrix4 value) 
            => SetUniform(_uniformsByName[name].Location, value);

        public void Dispose()
        {
            glDeleteProgram(_handle);
        }

        private void CollectUniformInformation()
        {
            glGetProgramiv(_handle, ProgramPropertyARB.GL_ACTIVE_UNIFORMS, out var uniforms);

            StringBuilder nameBuffer = new StringBuilder(1024);

            nameBuffer.EnsureCapacity(1024);
            int namebufferLength;

            for (uint i = 0; i < uniforms; i++)
            {
                int size;
                AttributeType type;
                glGetActiveUniform(_handle, i, 1024, out namebufferLength, out size, out type, nameBuffer);
                var name = nameBuffer.ToString();
                var location = glGetUniformLocation(_handle, name);
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
            glGetProgramiv(_handle, ProgramPropertyARB.GL_ACTIVE_ATTRIBUTES, out var attributes);

            StringBuilder nameBuffer = new StringBuilder(1024);
            nameBuffer.EnsureCapacity(1024);
            int namebufferLength;

            for (uint i = 0; i < attributes; i++)
            {
                int size;
                AttributeType type;
                glGetActiveAttrib(_handle, i, 1024, out namebufferLength, out size, out type, nameBuffer);
                var name = nameBuffer.ToString();
                var location = glGetAttribLocation(_handle, name);
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
            public AttributeType Type { get; set; }
        }
    }
}
