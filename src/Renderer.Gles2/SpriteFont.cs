using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using Tgl.Net;

namespace Renderer.Gles2
{
    public class SpriteGlyph
    {
        public char Char;
        public Rectangle Source;
        public Point Offset;
        public int XAdvance;

        public Dictionary<char, int> Kernings { get; set; } = new Dictionary<char, int>();

        public int GetDistanceTo(char next)
        {
            if (Kernings.TryGetValue(next, out var kerning))
            {
                return XAdvance + kerning;
            }

            return XAdvance;
        }
    }
    
    public class SpriteFont
    {
        private readonly Dictionary<char, SpriteGlyph> _glyps;

        public SpriteFont(Texture texture, int lineHeight, IEnumerable<SpriteGlyph> glyps)
        {
            Texture = texture;
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
