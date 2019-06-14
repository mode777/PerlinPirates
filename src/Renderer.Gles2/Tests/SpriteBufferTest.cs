using System;
using System.Collections.Generic;
using System.Text;
using Game.Abstractions;
using Tgl.Net;

namespace Renderer.Gles2.Tests
{
    public class SpriteBufferTest : IRenderTest
    {
        private SpriteBatch buffer;
        private Renderer renderer;
        private ResourceManager manager;

        public void Init(GlContext context, ResourceManager manager)
        {
            this.manager = manager;
            buffer = new SpriteBatch(context.State, 10);
            var texture = manager.LoadResource<Texture>("Resources.Textures.grid.png");

            buffer.Push(texture, 20, 20);
        }

        public void Render(GlContext context)
        {
            renderer = new Renderer(context, manager);

            renderer.RenderSprites(buffer);
        }
    }
}
