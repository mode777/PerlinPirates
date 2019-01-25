using System;
using System.Collections.Generic;
using System.Text;
using Game.Abstractions;
using Tgl.Net;
using Tgl.Net.Abstractions;

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
            var image = manager.LoadResource<IImage>("Resources.Textures.grid.png");
            var texture = context.TextureFromImage(image);

            buffer.Push(texture, 20, 20);
        }

        public void Render(GlContext context)
        {
            renderer = new Renderer(context, manager);

            renderer.RenderSprites(buffer);
        }
    }
}
