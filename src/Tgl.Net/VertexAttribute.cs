using System;

namespace Tgl.Net.Core
{
    public class VertexAttribute
    {
        public VertexAttribute(string name, uint components)
        {
            Name = name;
            if (components > 4 || components < 1)
                throw new InvalidOperationException("Components has to be between 1 and 4");

            Components = components;
        }

        public VertexAttribute(string name, uint components, GL.VertexAttribPointerType type)
            : this(name, components)
        {
            DataType = type;
        }

        public string Name { get; }
        public uint Components { get; }
        public bool Normalized { get; set; }
        public uint? Offset { get; set; }
        public GL.VertexAttribPointerType DataType { get; set; } = GL.VertexAttribPointerType.GL_FLOAT;
    }
}