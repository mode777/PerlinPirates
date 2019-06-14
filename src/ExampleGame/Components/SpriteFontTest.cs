﻿using System;
using System.Collections.Generic;
using System.Text;
using Game.Abstractions;
using Tgl.Net;
using Tgl.Net.Abstractions;
using Tgl.Net.Bindings;
using Tgl.Net.Math;

namespace Renderer.Gles2.Tests
{
    public class SpriteFontTest : GameComponent
    {
        private const string TEXT = "Lorem ipsum dolor sit amet, consetfdfffffffffffffffffffffffffffhhhhhhhhhhhhhhhetur sadipscing elitr, sed diam nonumy eirmod.";

        private readonly GlContext _context;
        private readonly ResourceManager _manager;

        private QuadBuffer2D _buffer;

        public SpriteFontTest(GlContext context, ResourceManager manager)
        {
            _context = context;
            _manager = manager;
        }

        public override void Load()
        {
            var font = _manager.LoadResource<SpriteFont>("Resources.Fonts.segoe.fnt");
            var texture = font.Texture;

            _buffer = new QuadBuffer2D(_context, new Shader2d(_context, _manager), texture, TEXT.Length);

            const int width = 200;

            var y = 10;
            var x = 10;
            int i = 0;
            int wordstart = -1;

            SpriteGlyph last = null;

            var chars = TEXT.ToCharArray();

            while (i < chars.Length)
            {
                if (x > width)
                {
                    x = 0;
                    y += font.LineHeight;
                    i = wordstart == -1
                        ? i - 1
                        : wordstart;
                    wordstart = -1;
                }

                var c = chars[i];

                if (c == ' ')
                    wordstart = i + 1;

                var glyph = font.GetGlyph(c);

                if (last != null)
                {
                    x += last.GetDistanceTo(c);
                }

                _buffer.SetQuad(i,
                    x + glyph.Offset.X,
                    y + glyph.Offset.Y,
                    glyph.Source.Width,
                    glyph.Source.Height,
                    glyph.Source.X,
                    glyph.Source.Y);
                _buffer.SetColor(i, 0, 0, 0, 1);

                last = glyph;
                i++;
            }

            _context.State.ColorClearValue = new Vector4(1, 1, 1, 1);
            _context.State.Blend = true;
            _context.State.BlendFunc(BlendingFactor.GL_SRC_ALPHA, BlendingFactor.GL_ONE_MINUS_SRC_ALPHA);
        }

        public override void Update(float delta)
        {
            _buffer.Update();
        }

        public override void Draw()
        {
            _context.Clear(ClearBufferMask.GL_COLOR_BUFFER_BIT);
            _buffer.Render();
        }
    }
}