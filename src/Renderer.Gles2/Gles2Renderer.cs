using System;
using System.Collections.Generic;
using System.Text;
using Game.Abstractions;
using Renderer.Gles2.Tests;
using Tgl.Net;
using Tgl.Net.Bindings;
using Tgl.Net.Math;

namespace Renderer.Gles2
{
    public class Gles2Renderer : IRenderer
    {
        private readonly IPlatform _platform;
        private readonly IImageLoader _loader;
        private readonly IRenderTest _test;

        private GlStateCache _state;
        private GlContext _context;

        public Gles2Renderer(IPlatform platform, IImageLoader loader)
        {
            _platform = platform;
            _loader = loader;
            platform.CreateGlContext();
            GL.LoadApi(platform.GetGlProcAddress);

            //_test = new SimpleTriangle();            
            //_test = new TextureChecker();            
            _test = new PngTexture(loader);            

            Init();
        }

        public void Init()
        {
            _state = new GlStateCache();
            _context = new GlContext(_state);

            _state.PropertyChanged += (s, args) => Console.WriteLine(args.PropertyName);

            _test.Init(_state, _context);
        }

        public void Render()
        {
            _test.Render(_state, _context);

            _platform.SwapBuffers();
        }
    }
}
