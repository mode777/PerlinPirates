using System;
using System.Collections.Generic;
using System.Text;
using Game.Abstractions;
using Tgl.Net;
using Tgl.Net.Bindings;

namespace Renderer.Gles2.Tests
{
    class TilesTest : GameComponent
    {
        private const int TILE_SIZE = 16;
        private const int FIELD_SIZE = 64;

        private readonly GlContext _context;
        private readonly ResourceManager _manager;

        private QuadBuffer2D _buffer;

        public TilesTest(GlContext context, ResourceManager manager)
        {
            _context = context;
            _manager = manager;
        }

        public override void Load()
        {
            var texture = _manager.LoadResource<Texture>("Resources.Textures.tiles.png");

            var shader = new Shader2d(_context, _manager);

            _buffer = new QuadBuffer2D(_context, shader, texture, FIELD_SIZE * FIELD_SIZE);
        }

        public override void Draw()
        {
            _context.Clear(ClearBufferMask.GL_COLOR_BUFFER_BIT);

            _buffer.Render();
        }

        public override void Update(float delta)
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
        }
    }
}
