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
    public class SpriteFontTest : IRenderTest
    {
        private const string TEXT = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod.";

        private QuadBuffer2D _buffer;
        private GlContext _context;

        public void Init(GlContext context, ResourceManager manager)
        {
            _context = context;

            var font = manager.LoadResource<SpriteFont>("Resources.Fonts.segoe.fnt");
            var texture = font.Texture;

            _buffer = new QuadBuffer2D(context, new Shader2d(context, manager), texture, TEXT.Length);

            var y = 10;
            var x = 10;
            int i = 0;
            SpriteGlyph last = null;

            foreach (var c in TEXT)
            {
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

            _context.State.ColorClearValue = new Vector4(1,1,1,1);
            _context.State.Blend = true;
            _context.State.BlendFunc(BlendingFactor.GL_SRC_ALPHA, BlendingFactor.GL_ONE_MINUS_SRC_ALPHA);
        }

        public void Render(GlContext context)
        {
            _buffer.Update();

            _context.Clear(ClearBufferMask.GL_COLOR_BUFFER_BIT);
            _buffer.Render();
        }
    }
}