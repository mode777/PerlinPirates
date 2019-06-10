using System.Collections.Generic;
using System.Drawing;

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
}