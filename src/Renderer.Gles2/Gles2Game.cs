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
    public abstract class Gles2Game : GameBase
    {
        public Gles2Game(GlContext context, 
            ResourceManager manager, 
            ILogger<IGame> logger)
        {
            Context = context;
            Resources = manager;
            Logger = logger;
        }

        protected ResourceManager Resources { get; }
        protected ILogger<IGame> Logger { get; }
        protected GlContext Context { get; }

        public override void Load()
        {
            var resolver = new EmbeddedResourceResolver(typeof(Gles2Game).Assembly);
            var imageLoader = new ImageLoader(resolver);

            Resources.RegisterLoader(new ShaderLoader(Context, resolver));
            Resources.RegisterLoader(imageLoader);
            Resources.RegisterLoader(new SpriteFontLoader(Context, imageLoader, resolver));

            Context.State.PropertyChanged += (s, args) => Logger.LogDebug($"GLState changed: {args.PropertyName}");
        }

        public override void Draw()
        {

        }

        public override void Update(double dt)
        {

        }
    }
}
