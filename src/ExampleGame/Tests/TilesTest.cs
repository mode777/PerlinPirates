using System;
using System.Drawing;
using ECS;
using ExampleGame.Components;
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
        private readonly World _world;

        private Framebuffer _fb;
        private IDrawable _fbDrawable;

        public TilesTest(GlContext context, ResourceManager manager, EventsProvider provider, Shader2d shader, World world)
        {
            _context = context;
            _manager = manager;
            _provider = provider;
            _shader = shader;
            _world = world;

            _provider.Load += Load;
            _provider.Draw += Draw;
            _provider.Update += Update;
        }

        private void Load()
        {
            var gamemap = _manager.LoadResource<GameMap>("Resources/Tilemaps/level");
            var tilemap = _manager.LoadResource<Tilemap>("Resources/Tilemaps/level");

            var worldEntity = _world.CreateEntity();
            _world.AddComponent(worldEntity, gamemap);
            _world.AddComponent(worldEntity, tilemap);
            
            _fb = _context.BuildFramebuffer()
                .HasAttachment(FramebufferAttachment.GL_COLOR_ATTACHMENT0)
                .WithDefaultTexture(256, 128)
                .Build();

            _fbDrawable = _context.CreateFullscreenTexture(_fb.ColorAttachment);

        }

        private void Draw()
        {
            using (var context = _fb.StartDrawing())
            {
                _context.Clear(ClearBufferMask.GL_COLOR_BUFFER_BIT);
                foreach (var (entity, tilemap) in _world.Enumerate<Tilemap>())
                {
                    tilemap.Render();
                }
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
