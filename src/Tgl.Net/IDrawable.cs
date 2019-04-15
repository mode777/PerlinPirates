using System;
using System.Collections.Generic;

namespace Tgl.Net
{
    public interface IDrawable
    {
        Shader Shader { get; }
        IEnumerable<VertexBuffer> Buffers { get; }
        IndexBuffer IndexBuffer { get; }
        IDictionary<string, Texture> Textures { get; }
        IDictionary<string, Action<Shader>> UniformSetters { get; }
    }
}
