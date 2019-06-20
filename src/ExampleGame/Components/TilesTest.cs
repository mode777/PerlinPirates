using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Game.Abstractions;
using Tgl.Net;
using Tgl.Net.Bindings;

namespace Renderer.Gles2.Tests
{
    class TilesTest : IGameComponent
    {
        private const int TILE_SIZE = 16;
        private const int FIELD_SIZE = 64;

        private readonly GlContext _context;
        private readonly ResourceManager _manager;
        private readonly EventsProvider _provider;

        private Tilemap _map;

        public TilesTest(GlContext context, ResourceManager manager, EventsProvider provider)
        {
            _context = context;
            _manager = manager;
            _provider = provider;

            _provider.Load += Load;
            _provider.Draw += Draw;
            _provider.Update += Update;
        }

        private void Load()
        {
            var texture = _manager.LoadResource<Texture>("Resources.Textures.tiles.png");

            var shader = new Shader2d(_context, _manager);

            var tileset = new Tileset(texture, new Size(TILE_SIZE,TILE_SIZE));

            _map = new Tilemap(_context, shader, tileset, 4, 4, new int[]
            {
                2, 3, 4, 5,
                6, 7, 6, 5,
                4, 3, 2, 1,
                2, 3, 4, 5
            });
        }

        private void Draw()
        {
            _context.Clear(ClearBufferMask.GL_COLOR_BUFFER_BIT);

            _map.Render();
        }

        private void Update(float delta)
        {
            _map.Update();
        }
    }
}
