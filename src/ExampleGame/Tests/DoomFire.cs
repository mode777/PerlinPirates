using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Game.Abstractions.Events;
using Tgl.Net;
using Tgl.Net.Bindings;
using Tgl.Net.Extensions;
using Tgl.Net.Imaging;

namespace ExampleGame.Tests
{
    public class DoomFire : IHandlesLoad, IHandlesUpdate, IHandlesDraw
    {
        private readonly GlContext _context;
        private readonly Random _rand = new Random();

        private Texture _texture;
        private ImageData<ColorRgb> _data;
        private byte[] _firePixels;
        private IDrawable _drawable;

        public DoomFire(GlContext context)
        {
            _context = context;
        }

        public void Load()
        {
            _data = new ImageData<ColorRgb>(_context.DefaultViewport.Size / 2);
            _firePixels = new byte[_data.Size.Width * _data.Size.Height];
            Setup();
            _texture = _context.BuildTexture<ColorRgb>()
                .HasFiltering(TextureMinType.GL_NEAREST, TextureMagType.GL_NEAREST)
                .UseImageData(_data)
                .Build();
            _drawable = _context.CreateFullscreenDrawable(_texture);
        }

        private void Setup()
        {
            for (int i = 0; i < _firePixels.Length; i++)
            {
                _firePixels[i] = 0;
            }
            
            for (var i = 0; i < _data.Size.Width; i++)
            {
                _firePixels[(_data.Size.Height - 1) * _data.Size.Width + i] = 36;
            }
        }

        public void Update(float delta)
        {
            DoFire();

            for (int i = 0; i < _firePixels.Length; i++)
            {
                _data.Pixels[i] = _palette[_firePixels[i]];
            }
            _texture.Update(_data);
        }

        private void DoFire()
        {
            for (int x = 0; x < _data.Size.Width; x++)
            {
                for (int y = 1; y < _data.Size.Height; y++)
                {
                    SpreadFire(y * _data.Size.Width + x);        
                }
            }
        }

        private void SpreadFire(int src)
        {
            var pixel = _firePixels[src];
             
            if (pixel == 0)
            {
                _firePixels[src - _data.Size.Width] = 0;
            }
            else
            {
                var rIdx = _rand.Next(3);
                var dst = src - rIdx + 1;

                _firePixels[Math.Max(0,dst - _data.Size.Width)] = (byte)( pixel - (rIdx & 1));
            }
        }

        public void Draw()
        {
            _context.Clear(ClearBufferMask.GL_COLOR_BUFFER_BIT);
            _context.DrawDrawable(_drawable);
        }

        private readonly ColorRgb[] _palette = {
            new ColorRgb(0x07,0x07,0x07),
            new ColorRgb(0x1F,0x07,0x07),
            new ColorRgb(0x2F,0x0F,0x07),
            new ColorRgb(0x47,0x0F,0x07),
            new ColorRgb(0x57,0x17,0x07),
            new ColorRgb(0x67,0x1F,0x07),
            new ColorRgb(0x77,0x1F,0x07),
            new ColorRgb(0x8F,0x27,0x07),
            new ColorRgb(0x9F,0x2F,0x07),
            new ColorRgb(0xAF,0x3F,0x07),
            new ColorRgb(0xBF,0x47,0x07),
            new ColorRgb(0xC7,0x47,0x07),
            new ColorRgb(0xDF,0x4F,0x07),
            new ColorRgb(0xDF,0x57,0x07),
            new ColorRgb(0xDF,0x57,0x07),
            new ColorRgb(0xD7,0x5F,0x07),
            new ColorRgb(0xD7,0x5F,0x07),
            new ColorRgb(0xD7,0x67,0x0F),
            new ColorRgb(0xCF,0x6F,0x0F),
            new ColorRgb(0xCF,0x77,0x0F),
            new ColorRgb(0xCF,0x7F,0x0F),
            new ColorRgb(0xCF,0x87,0x17),
            new ColorRgb(0xC7,0x87,0x17),
            new ColorRgb(0xC7,0x8F,0x17),
            new ColorRgb(0xC7,0x97,0x1F),
            new ColorRgb(0xBF,0x9F,0x1F),
            new ColorRgb(0xBF,0x9F,0x1F),
            new ColorRgb(0xBF,0xA7,0x27),
            new ColorRgb(0xBF,0xA7,0x27),
            new ColorRgb(0xBF,0xAF,0x2F),
            new ColorRgb(0xB7,0xAF,0x2F),
            new ColorRgb(0xB7,0xB7,0x2F),
            new ColorRgb(0xB7,0xB7,0x37),
            new ColorRgb(0xCF,0xCF,0x6F),
            new ColorRgb(0xDF,0xDF,0x9F),
            new ColorRgb(0xEF,0xEF,0xC7),
            new ColorRgb(0xFF,0xFF,0xFF)
        };

    }
}
