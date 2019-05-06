using System;
using System.Collections.Generic;
using System.Text;
using Game.Abstractions;
using Tgl.Net;
using Tgl.Net.Abstractions;
using Tgl.Net.Bindings;
using Tgl.Net.Math;

namespace Renderer.Gles2.Tests
{
    public class ParticleSystemTest : IRenderTest
    {
        private const int PARTICLES = 10000;

        private readonly Vector2[] offsets = new Vector2[PARTICLES];
        private QuadBuffer2D _buffer;
        private GlContext _context;
        private Random _random = new Random();

        public void Init(GlContext context, ResourceManager manager)
        {
            _context = context;

            var image = manager.LoadResource<IImage>("Resources.Textures.particle.png");
            var texture = context.TextureFromImage(image);

            _buffer = new QuadBuffer2D(context, new Shader2d(context, manager), texture, PARTICLES);

            for (int i = 0; i < PARTICLES; i++)
            {
                ResetParticle(i);
            }

            context.State.Blend = true;
            context.State.BlendFunc(BlendingFactor.GL_ONE, BlendingFactor.GL_ONE);
        }

        private void ResetParticle(int i)
        {
            _buffer.SetQuad(i, 320 - (_buffer.Texture.Width / 2), 400 - (_buffer.Texture.Height / 2), _buffer.Texture.Width, _buffer.Texture.Height, 0, 0);
            _buffer.SetColor(i, _random.Next(255) / 255f, _random.Next(255) / 255f, _random.Next(255) / 255f, 1);
            
            offsets[i] = new Vector2
            {
                X = (_random.Next(PARTICLES) - (PARTICLES / 2)) / (PARTICLES * 0.5f),
                Y = (_random.Next(PARTICLES) - PARTICLES * 1.5f) / (PARTICLES * 0.5f)
            };
        }

        public void Render(GlContext context)
        {
            for (int i = 0; i < PARTICLES; i++)
            {
                _buffer.OffsetQuad(i, offsets[i].X, offsets[i].Y);

                // Gravity
                //offsets[i].Y += 0.01f;

                var center = _buffer.GetCenter(i);

                if (center.X < 0 || center.Y < 0 || center.X > 640 || center.Y > 480)
                {
                    ResetParticle(i);
                }
            }

            _buffer.Update();

            _context.Clear(ClearBufferMask.GL_COLOR_BUFFER_BIT);
            _buffer.Render();
        }
    }
}
