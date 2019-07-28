using System;
using System.Collections.Generic;
using System.Numerics;
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

            var vertexShader = GL.glCreateShader(ShaderType.GL_VERTEX_SHADER);
            GL.ShaderSource(vertexShader, new[] { vertexSource });
            GL.glCompileShader(vertexShader);
            GL.glGetShaderiv(vertexShader, ShaderParameterName.GL_COMPILE_STATUS, out var compiled);
            if (compiled == 0)
            {
                GL.glGetShaderInfoLog(vertexShader, 1024, out infologLength, infolog);
                throw new InvalidProgramException(infolog.ToString());
            }

            var fragmentShader = GL.glCreateShader(ShaderType.GL_FRAGMENT_SHADER);
            GL.ShaderSource(fragmentShader, new[] { fragmentSource });
            GL.glCompileShader(fragmentShader);
            GL.glGetShaderiv(fragmentShader, ShaderParameterName.GL_COMPILE_STATUS, out compiled);
            if (compiled == 0)
            {
                GL.glGetShaderInfoLog(fragmentShader, 1024, out infologLength, infolog);
                throw new InvalidProgramException(infolog.ToString());
            }

            GL.glAttachShader(Handle, vertexShader);
            GL.glAttachShader(Handle, fragmentShader);
            GL.glLinkProgram(Handle);
            GL.glGetProgramiv(Handle, ProgramPropertyARB.GL_LINK_STATUS, out var linked);
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
            if (_uniformsByName.TryGetValue(name, out var uni))
            {
                return uni.Location;
            }
            else
            {
                return 0;
            }
        }

        public int GetAttributeLocation(string name)
        {
            if (_attributesByName.TryGetValue(name, out var loc))
            {
                return loc.Location;
            }
            else
            {
                return 0;
            }
        }
        
        public void SetUniform(int location, float value)
        {
            Use();
            GL.glUniform1f(location, value);
        }
        

        public void SetUniform(int location, TextureUnit unit)
        {
            Use();
            int value = (int)(unit - TextureUnit.GL_TEXTURE0);
            GL.glUniform1i(location, value);
        }

        public void SetUniform(string location, TextureUnit unit)
            => SetUniform(_uniformsByName[location].Location, unit);

        public void SetUniform(int location, int value)
        {
            Use();
            GL.glUniform1i(location, value);
        }

        public void SetUniform(string name, float value) 
            => SetUniform(_uniformsByName[name].Location, value);

        public void SetUniform(int location, float x, float y)
        {
            Use();
            GL.glUniform2f(location, x, y);
        }
        public void SetUniform(string name, float x, float y) 
            => SetUniform(_uniformsByName[name].Location, x, y);

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

        public void SetUniform(int location, Matrix2x2 value)
        {
            Use();

            GL.glUniformMatrix2fv(location, 1, false, ref value);
        }
        public void SetUniform(string name, Matrix2x2 value) 
            => SetUniform(_uniformsByName[name].Location, value);

        public void SetUniform(int location, Matrix3x3 value)
        {
            Use();

            GL.glUniformMatrix3fv(location, 1, false, ref value);
        }

        public void SetUniform(string name, Matrix3x3 value) 
            => SetUniform(_uniformsByName[name].Location, value);

        public void SetUniform(string name, ref Matrix4x4 value)
            => SetUniform(_uniformsByName[name].Location, value);

        public void SetUniform(int location, Matrix4x4 value)
        {
            Use();
            GL.glUniformMatrix4fv(location, 1, false, ref value);
        }

        public void SetUniform(string name, Matrix4x4 value) 
            => SetUniform(_uniformsByName[name].Location, value);

        public void Dispose()
        {
            GL.glDeleteProgram(Handle);
        }

        private void CollectUniformInformation()
        {
            _uniformsByName = new Dictionary<string, ShaderVariableInfo>();

            GL.glGetProgramiv(Handle, ProgramPropertyARB.GL_ACTIVE_UNIFORMS, out var uniforms);

            StringBuilder nameBuffer = new StringBuilder(1024);

            nameBuffer.EnsureCapacity(1024);
            int namebufferLength;

            for (uint i = 0; i < uniforms; i++)
            {
                int size;
                AttributeType type;
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

            GL.glGetProgramiv(Handle, ProgramPropertyARB.GL_ACTIVE_ATTRIBUTES, out var attributes);

            StringBuilder nameBuffer = new StringBuilder(1024);
            nameBuffer.EnsureCapacity(1024);
            int namebufferLength;

            for (uint i = 0; i < attributes; i++)
            {
                int size;
                AttributeType type;
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
            public AttributeType Type { get; set; }
        }
    }
}
