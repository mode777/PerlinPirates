using System;
using System.Collections.Generic;
using System.Text;
using Game.Abstractions;
using ImageSharpLoader;
using Microsoft.Extensions.Logging;
using Renderer.Gles2.Tests;
using Tgl.Net;
using Tgl.Net.Abstractions;
using Tgl.Net.Bindings;
using Tgl.Net.Math;

namespace Renderer.Gles2
{
    public class Gles2Renderer : IRenderer
    {
        private readonly IPlatform _platform;
        private readonly ResourceManager _resources;
        private readonly ILogger<IRenderer> _logger;
        private IRenderTest _test;

        private GlContext _context;

        public Gles2Renderer(IPlatform platform, ResourceManager manager, ILogger<IRenderer> logger)
        {
            _platform = platform;
            _resources = manager;
            _logger = logger;
        }

        public void Initialize()
        {
            _context = new GlContext(_platform.GetGlProcAddress);

            var resolver = new EmbeddedResourceResolver(typeof(Gles2Renderer).Assembly);
            var imageLoader = new ImageLoader(resolver);

            _resources.RegisterLoader(new ShaderLoader(_context, resolver));
            _resources.RegisterLoader(imageLoader);
            _resources.RegisterLoader(new SpriteFontLoader(_context, imageLoader, resolver));

            //_test = new SpriteFontTest();
            _test = new ParticleSystemTest();

            _context.State.PropertyChanged += (s, args) => _logger.LogDebug($"GLState changed: {args.PropertyName}");

            _test.Init(_context, _resources);
        }

        public void Render()
        {
            _test.Render(_context);
        }
    }
}
