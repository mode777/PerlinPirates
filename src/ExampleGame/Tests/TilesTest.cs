using System;
using System.Drawing;
using Game.Abstractions;
using Renderer.Gles2;
using Tgl.Net;
using Tgl.Net.Bindings;

namespace ExampleGame.Tests
{
    class TilesTest : IGameComponent
    {
        private const int TILE_SIZE = 16;
        private const int FIELD_SIZE = 64;

        private readonly GlContext _context;
        private readonly ResourceManager _manager;
        private readonly EventsProvider _provider;

        private Framebuffer _fb;
        private IDrawable _fbDrawable;
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
            _fb = _context.BuildFramebuffer()
                .HasAttachment(FramebufferAttachment.GL_COLOR_ATTACHMENT0)
                .WithDefaultTexture(256, 128)
                .Build();

            var texture = _manager.LoadResource<Texture>("Resources.Textures.tiles.png");

            var shader = new Shader2d(_context, _manager);

            var tileset = new Tileset(texture, new Size(TILE_SIZE, TILE_SIZE));

            _map = new Tilemap(_context, shader, tileset, 16, 8);
            var data = new int[_map.Width * _map.Height];
            var rand = new Random();

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = rand.Next(8);
            }

            _map.SetData(data);


            _fbDrawable = _context.CreateFullscreenTexture(_fb.ColorAttachment);
        }

        private void Draw()
        {
            using (var context = _fb.StartDrawing())
            {
                _context.Clear(ClearBufferMask.GL_COLOR_BUFFER_BIT);
                _map.Render();
            }

            _context.Clear(ClearBufferMask.GL_COLOR_BUFFER_BIT);
            _context.DrawDrawable(_fbDrawable);
        }

        private void Update(float delta)
        {
            //_map.Update();
        }

    }
}
