using System;
using System.Collections.Generic;
using System.Text;

namespace Tgl.Net
{
    public class DrawableBuilder
    {
        Shader Shader { get; set; }
        IEnumerable<VertexBuffer> Buffers { get; set; }
        IEnumerable<Texture> Textures { get; set; }
        public Action<Shader> UniformSetters { get; set; }
    }
}
