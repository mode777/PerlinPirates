using System;
using System.Collections.Generic;
using System.Linq;
using Tgl.Net;

namespace Renderer.Common2D.Fonts
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
