using System;
using System.Collections.Generic;

namespace Tgl.Net
{
    public class Drawable
    {
        Shader Shader { get; set; }
        IEnumerable<VertexBuffer> Buffers { get; set; }
        public IndexBuffer IndexBuffer { get; set; }
        IEnumerable<Texture> Textures { get; set; }
        public Action<Shader> UniformSetters { get; set; }
    }
}
