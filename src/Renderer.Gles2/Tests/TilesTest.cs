using System;
using System.Collections.Generic;
using System.Text;
using Game.Abstractions;
using Tgl.Net;
using Tgl.Net.Abstractions;
using Tgl.Net.Bindings;

namespace Renderer.Gles2.Tests
{
    class TilesTest : IRenderTest
    {
        private const int TILE_SIZE = 16;
        private const int FIELD_SIZE = 64;


        private QuadBuffer2D _buffer;
        private GlContext _context;

        public void Init(GlContext context, ResourceManager manager)
        {
            _context = context;

            var image = manager.LoadResource<IImage>("Resources.Textures.tiles.png");
            var texture = context.TextureFromImage(image);

            var shader = new Shader2d(context, manager);

            _buffer = new QuadBuffer2D(context, shader, texture, FIELD_SIZE * FIELD_SIZE);
        }

        public void Render(GlContext context)
        {
            var rand = new Random();
            for (int i = 0; i < _buffer.Size; i++)
            {
                var tileId = rand.Next(6) + 1;

                var srcX = tileId * TILE_SIZE;
                var srcY = 0;
                var x = (i % FIELD_SIZE) * TILE_SIZE;
                var y = (i / FIELD_SIZE) * TILE_SIZE;

                _buffer.SetQuad(i, x, y, TILE_SIZE, TILE_SIZE, srcX, srcY);
            }
            _buffer.Update();

            _context.Clear(ClearBufferMask.GL_COLOR_BUFFER_BIT);

            _buffer.Render();
        }
    }
}
