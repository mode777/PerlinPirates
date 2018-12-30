using System;
using System.Collections.Generic;

namespace Tgl.Net
{
    public interface IDrawable
    {
        Shader Shader { get; }
        IEnumerable<VertexBuffer> Buffers { get; }
        IndexBuffer IndexBuffer { get; }
        IReadOnlyDictionary<string, Texture> Textures { get; }
        IReadOnlyDictionary<string, Action<Shader>> UniformSetters { get; }
    }
}
