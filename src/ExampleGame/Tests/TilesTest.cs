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
        private readonly Shader2d _shader;

        private Framebuffer _fb;
        private IDrawable _fbDrawable;
        private Tilemap _map;
        private Tilemap _map2;

        public TilesTest(GlContext context, ResourceManager manager, EventsProvider provider, Shader2d shader)
        {
            _context = context;
            _manager = manager;
            _provider = provider;
            _shader = shader;

            _provider.Load += Load;
            _provider.Draw += Draw;
            _provider.Update += Update;
        }

        private void Load()
        {
            _map2 = _manager.LoadResource<Tilemap>("Resources/Tilemaps/level");

            _fb = _context.BuildFramebuffer()
                .HasAttachment(FramebufferAttachment.GL_COLOR_ATTACHMENT0)
                .WithDefaultTexture(256, 128)
                .Build();

            var texture = _manager.LoadResource<Texture>("Resources.Textures.tiles.png");

            var tileset = new Tileset(texture, new Size(TILE_SIZE, TILE_SIZE));

            _map = new Tilemap(_context, _shader, tileset, 16, 8);
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
                _map2.Render();
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
