using System;
using System.Collections.Generic;
using System.Text;
using Game.Abstractions;
using ImageSharpLoader;
using Renderer.Gles2.Tests;
using Tgl.Net;
using Tgl.Net.Abstractions;
using Tgl.Net.Bindings;
using Tgl.Net.Math;

namespace Renderer.Gles2
{
    public class TestRunner : IRenderer
    {
        private readonly IPlatform _platform;
        private readonly ResourceManager _resources;
        private readonly IRenderTest _test;

        private GlContext _context;

        public TestRunner(IPlatform platform, ResourceManager manager)
        {
            _platform = platform;
            _resources = manager;
            _platform.CreateGlContext();

            _context = new GlContext(_platform.GetGlProcAddress);

            var resolver = new EmbeddedResourceResolver(typeof(TestRunner).Assembly);
            _resources.RegisterLoader(new ShaderLoader(_context, resolver));
            _resources.RegisterLoader(new ImageLoader(resolver));

            _test = new TilesTest();            

            Init();
        }

        public void Init()
        {
            _context.State.PropertyChanged += (s, args) => Console.WriteLine(args.PropertyName);

            _test.Init(_context, _resources);
        }

        public void Render()
        {
            _test.Render(_context);

            _platform.SwapBuffers();
        }
    }
}
