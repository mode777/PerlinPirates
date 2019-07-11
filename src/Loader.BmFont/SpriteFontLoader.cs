using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Game.Abstractions;
using Renderer.Common2D.Fonts;
using Tgl.Net;

namespace Loader.BmFont
{
    public class SpriteFontLoader : ResourceLoader<SpriteFont>
    {
        private readonly ResourceManager _manager;

        public SpriteFontLoader(ResourceManager manager) 
        {
            _manager = manager;
        }

        private Texture LoadTexture(string path, XDocument doc)
        {
            var textureFile = doc.Descendants("page").First().Attribute("file").Value;
            var texturePath = Path.Combine(Path.GetDirectoryName(path), textureFile);

            return _manager.LoadResource<Texture>(texturePath);
        }

        private SpriteFont LoadFromXml(XDocument doc, Texture texture)
        {
            var val = doc.Descendants("common").First().Attribute("lineHeight").Value;
            var lineHeight = int.Parse(val);

            var kernings = doc.Descendants("kerning").GroupBy(x => x.Attribute("first").Value)
                .ToDictionary(
                    x => (char)int.Parse(x.Key),
                    x => x.Select(y =>
                    {
                        return ((char) int.Parse(y.Attribute("second").Value),
                                int.Parse(y.Attribute("amount").Value));
                    }));

            var glyphs = doc.Descendants("char").Select(el =>
            {
                var c = (char)int.Parse(el.Attribute("id").Value);
                kernings.TryGetValue(c, out var tuples);
                var glyphKernings = (tuples ?? Enumerable.Empty<(char, int)>())
                    .ToDictionary(x => x.Item1, x => x.Item2);

                return new SpriteGlyph
                {
                    Char = c,
                    Offset = new Point(
                        int.Parse(el.Attribute("xoffset").Value),
                        int.Parse(el.Attribute("yoffset").Value)),
                    Source = new Rectangle(
                        int.Parse(el.Attribute("x").Value),
                        int.Parse(el.Attribute("y").Value),
                        int.Parse(el.Attribute("width").Value),
                        int.Parse(el.Attribute("height").Value)),
                    XAdvance = int.Parse(el.Attribute("xadvance").Value),
                    Kernings = glyphKernings,
                };
            });

            return new SpriteFont(texture, lineHeight, glyphs);
        }
        
        public override SpriteFont Load(string rid, Stream stream)
        {
            var doc = XDocument.Load(stream);
            var texture = LoadTexture(rid, doc);
            return LoadFromXml(doc, texture);
        }
    }
}
