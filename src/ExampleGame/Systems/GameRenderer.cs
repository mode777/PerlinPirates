using ECS;
using ExampleGame.Components;
using Game.Abstractions.Events;
using Renderer.Gles2;
using Tgl.Net;
using Tgl.Net.Bindings;

namespace ExampleGame.Systems
{
    public class GameRenderer : IHandlesDraw, IHandlesLoad, IHandlesUpdate
    {
        private readonly World _world;
        private readonly GlContext _context;

        private Framebuffer _fb;
        private IDrawable _screen;

        public GameRenderer(World world, GlContext context)
        {
            _world = world;
            _context = context;
        }
        
        public void Load()
        {
            _fb = _context.BuildFramebuffer()
                .HasAttachment(FramebufferAttachment.GL_COLOR_ATTACHMENT0)
                .WithDefaultTexture(256, 128)
                .Build();

            _screen = _context.CreateFullscreenTexture(_fb.ColorAttachment);
        }

        public void Draw()
        {
            using (var renderHandle = _fb.StartDrawing())
            {
                _context.Clear(ClearBufferMask.GL_COLOR_BUFFER_BIT);

                var map =_world.Component<Tilemap>(_world.IdForName("map"));
                map.Render();

                foreach (var (id, sprite) in _world.Enumerate<TileSprite>())
                {
                    sprite.Render();
                }
            }

            _context.Clear(ClearBufferMask.GL_COLOR_BUFFER_BIT);
            _context.DrawDrawable(_screen);
        }

        public void Update(float delta)
        {
            foreach (var (id, sprite,position) in _world.Enumerate<TileSprite, PositionComponent>())
            {
                sprite.SetPosition(position.Value);
            }
        }
    }
}