using Game.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Tgl.Net;

namespace Renderer.Gles2
{
    public class ShaderLoader : ResourceLoader<Shader>
    {
        private readonly GlContext _context;

        public ShaderLoader(GlContext context, IResourceResolver resolver) : base(resolver)
        {
            this._context = context;
        }

        public override async Task<Shader> Load(string key)
        {
            string vertex, fragment;

            using (var stream = ResolveResourceId(key + ".vertex.glsl"))
            using (var reader = new StreamReader(stream))
            {
                vertex = await reader.ReadToEndAsync();
            }

            using (var stream = ResolveResourceId(key + ".fragment.glsl"))
            using (var reader = new StreamReader(stream))
            {
                fragment = await reader.ReadToEndAsync();
            }

            return _context.BuildShader()
                .HasVertexString(vertex)
                .HasFragmentString(fragment)
                .Build();
        }
    }
}
