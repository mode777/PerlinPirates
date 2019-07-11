﻿using System;
using System.Numerics;
using Game.Abstractions;
using Game.Abstractions.Events;
using Microsoft.Extensions.Logging;
using Renderer.Common2D.Primitives;
using Tgl.Net;
using Tgl.Net.Bindings;

namespace ExampleGame.Tests
{
    public class ParticleSystemTest : IHandlesLoad, IHandlesDraw, IHandlesUpdate
    {
        private readonly GlContext _context;
        private readonly ResourceManager _manager;
        private readonly ILogger<IGameComponent> _logger;
        private readonly Shader2d _shader;
        private const int PARTICLES = 10000;

        private readonly Vector2[] offsets = new Vector2[PARTICLES];
        private QuadBuffer2D _buffer;
        private Random _random = new Random();

        public ParticleSystemTest(GlContext context, ResourceManager manager, ILogger<IGameComponent> logger, Shader2d shader)
        {
            _context = context;
            _manager = manager;
            _logger = logger;
            _shader = shader;
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

        void IHandlesLoad.Load()
        {
            var texture = _manager.LoadResource<Texture>("Resources.Textures.particle.png");

            _buffer = new QuadBuffer2D(_context, _shader, texture, PARTICLES);

            for (int i = 0; i < PARTICLES; i++)
            {
                ResetParticle(i);
            }

            _context.State.Blend = true;
            _context.State.BlendFunc(BlendingFactor.GL_ONE, BlendingFactor.GL_ONE);
        }

        void IHandlesDraw.Draw()
        {
            _context.Clear(ClearBufferMask.GL_COLOR_BUFFER_BIT);
            _buffer.Render();
        }

        void IHandlesUpdate.Update(float delta)
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
        }
    }
}
