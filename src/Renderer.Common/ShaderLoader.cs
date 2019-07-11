using System.IO;
using Game.Abstractions;
using Tgl.Net;

namespace Renderer.Common
{
    public class ShaderLoader : ResourceLoader<Shader>
    {
        private readonly GlContext _context;
        private readonly ResourceManager _manager;

        public ShaderLoader(GlContext context, ResourceManager manager)
        {
            this._context = context;
            _manager = manager;
        }
        
        public override Shader Load(string key, Stream stream)
        {
            string vertex, fragment;

            vertex = _manager.LoadResource<string>(key + ".vertex.glsl");
            fragment = _manager.LoadResource<string>(key + ".fragment.glsl");

            return _context.BuildShader()
                .HasVertexString(vertex)
                .HasFragmentString(fragment)
                .Build();
        }
    }
}
