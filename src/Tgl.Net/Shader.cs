using System;
using System.Collections.Generic;
using System.Text;
using Tgl.Net.Math;
using static Tgl.Net.GL;

namespace Tgl.Net.Core
{
    public class ShaderOptions
    {
        public ShaderOptions(string vertexSource, string fragmentSource)
        {
            VertexSource = vertexSource;
            FragmentSource = fragmentSource;
        }

        public string VertexSource { get; }
        public string FragmentSource { get; }
    }

    public class Shader : IDisposable
    {
        private readonly TglContext _context;
        private readonly uint _handle;
        private readonly Dictionary<string, ShaderVariableInfo> _uniformsByName
            = new Dictionary<string, ShaderVariableInfo>();
        private readonly Dictionary<string, ShaderVariableInfo> _attributesByName
            = new Dictionary<string, ShaderVariableInfo>();

        public Shader(TglContext context, ShaderOptions options)
        {
            _context = context;

            StringBuilder infolog = new StringBuilder(1024);
            infolog.EnsureCapacity(1024);
            int infologLength;

            var vertexShader = glCreateShader(ShaderType.GL_VERTEX_SHADER);
            ShaderSource(vertexShader, new[] { options.VertexSource });
            glCompileShader(vertexShader);
            glGetShaderiv(vertexShader, ShaderParameterName.GL_COMPILE_STATUS, out var compiled);
            if (compiled == 0)
            {
                glGetShaderInfoLog(vertexShader, 1024, out infologLength, infolog);
                throw new InvalidProgramException(infolog.ToString());
            }

            var fragmentShader = glCreateShader(ShaderType.GL_FRAGMENT_SHADER);
            ShaderSource(fragmentShader, new[] { options.FragmentSource });
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
            _context.State.Program.Set(_handle);
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
        public void SetUniform(string name, float value) => SetUniform(_uniformsByName[name].Location, value);

        public void SetUniform(int location, Vertex2f value)
        {
            Use();
            glUniform2f(location, value.X, value.Y);
        }
        public void SetUniform(string name, Vertex2f value) => SetUniform(_uniformsByName[name].Location, value);

        public void SetUniform(int location, Vertex3f value)
        {
            Use();
            Gl.Uniform3f(location, 1, value);
        }
        public void SetUniform(string name, Vertex3f value) => SetUniform(_uniformsByName[name].Location, value);

        public void SetUniform(int location, Vertex4f value)
        {
            Use();
            Gl.Uniform4f(location, 1, value);
        }
        public void SetUniform(string name, Vertex4f value) => SetUniform(_uniformsByName[name].Location, value);

        public void SetUniform(int location, Matrix2x2f value)
        {
            Use();
            Gl.UniformMatrix2f(location, 1, false, value);
        }
        public void SetUniform(string name, Matrix2x2f value) => SetUniform(_uniformsByName[name].Location, value);

        public void SetUniform(int location, Matrix3x3f value)
        {
            Use();
            glUniformMatrix3f(location, 1, false, value);
        }
        public void SetUniform(string name, Matrix3x3f value) => SetUniform(_uniformsByName[name].Location, value);

        public void SetUniform(int location, Matrix4x4f value)
        {
            Use();
            glUniformMatrix4f(location, 1, false, value);
        }
        public void SetUniform(string name, Matrix4x4f value) => SetUniform(_uniformsByName[name].Location, value);

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
            int size;
            int type;
            int location;
            string name;

            for (uint i = 0; i < uniforms; i++)
            {
                glGetActiveUniform(_handle, i, 1024, out namebufferLength, out size, out type, nameBuffer);
                name = nameBuffer.ToString();
                location = glGetUniformLocation(_handle, name);
                _uniformsByName[nameBuffer.ToString()] = new ShaderVariableInfo
                {
                    Location = location,
                    Name = name,
                    Size = size,
                    Type = (AttributeType)type
                };
            }
        }

        private void CollectAttributeInformation()
        {
            glGetProgramiv(_handle, ProgramPropertyARB.GL_ACTIVE_ATTRIBUTES, out var attributes);

            StringBuilder nameBuffer = new StringBuilder(1024);
            nameBuffer.EnsureCapacity(1024);
            int namebufferLength;
            int size;
            int type;
            int location;
            string name;

            for (uint i = 0; i < attributes; i++)
            {
                glGetActiveAttrib(_handle, i, 1024, out namebufferLength, out size, out type, nameBuffer);
                name = nameBuffer.ToString();
                location = glGetAttribLocation(_handle, name);
                _attributesByName[nameBuffer.ToString()] = new ShaderVariableInfo
                {
                    Location = location,
                    Name = name,
                    Size = size,
                    Type = (AttributeType)type
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
