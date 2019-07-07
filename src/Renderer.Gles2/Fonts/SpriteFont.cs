using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Tgl.Net;

namespace Renderer.Gles2
{
    public class SpriteFont
    {
        private readonly Dictionary<char, SpriteGlyph> _glyps;

        public SpriteFont(Texture texture, int lineHeight, IEnumerable<SpriteGlyph> glyps)
        {
            Texture = texture;
            LineHeight = lineHeight;
            _glyps = glyps.ToDictionary(x => x.Char);
        }

        public Texture Texture { get; }
        public int LineHeight { get; set; }

        public SpriteGlyph GetGlyph(char glyphChar)
        {
            if (_glyps.TryGetValue(glyphChar, out var glyph))
            {
                return glyph;
            }

            throw new ArgumentException($"Char not found: {glyphChar}");
        }


    }
}
