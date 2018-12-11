using System.Collections.Generic;

namespace Tgl.Net.Core
{
    public class BufferOptions
    {
        public BufferOptions(object data, uint vertices, IEnumerable<VertexAttribute> attributes)
        {
            Data = data;
            Vertices = vertices;
            Attributes = attributes;
        }

        public object Data { get; }
        public uint Vertices { get; }
        public IEnumerable<VertexAttribute> Attributes { get; }
        public GL.BufferUsageARB Usage { get; set; } = GL.BufferUsageARB.GL_STATIC_DRAW;

    }
}