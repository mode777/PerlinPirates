using System;
using Tgl.Net.Bindings;

namespace Tgl.Net
{
    public class VertexAttribute
    {
        private int _components;

        public VertexAttribute()
        {
            
        }

        public VertexAttribute(string name, int components)
        {
            Name = name;
            Components = components;
        }

        public VertexAttribute(string name, int components, GL.VertexAttribPointerType type)
            : this(name, components)
        {
            DataType = type;
        }

        public string Name { get; set; }

        public int Components
        {
            get => _components;
            set
            {
                if (value > 4 || value < 1)
                    throw new InvalidOperationException("Components has to be between 1 and 4");

                _components = value;
            }
        }
        public bool Normalized { get; set; }
        public int Order { get; set; } = -1;
        public int Offset { get; set; } = -1;
        public GL.VertexAttribPointerType DataType { get; set; }
            = GL.VertexAttribPointerType.GL_FLOAT;

        public int ComponentSize
        {
            get
            {
                switch (DataType)
                {
                    case GL.VertexAttribPointerType.GL_BYTE:
                    case GL.VertexAttribPointerType.GL_UNSIGNED_BYTE:
                        return 1;
                    case GL.VertexAttribPointerType.GL_SHORT:
                    case GL.VertexAttribPointerType.GL_UNSIGNED_SHORT:
                        return 2;
                    case GL.VertexAttribPointerType.GL_INT:
                    case GL.VertexAttribPointerType.GL_UNSIGNED_INT:
                    case GL.VertexAttribPointerType.GL_FLOAT:
                        return 4;
                    default:
                        throw new NotSupportedException($"DataType {DataType} is not supported.");
                }
            }
        }

        public int AttributeSize
        {
            get
            {
                return ComponentSize * Components;
            }
        }
    }
}