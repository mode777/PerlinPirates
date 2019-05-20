using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Game.Abstractions;
using Tgl.Net;
using Tgl.Net.Abstractions;

namespace Renderer.Gles2
{
    public class SpriteFontLoader : ResourceLoader<SpriteFont>
    {
        private readonly GlContext _context;
        private readonly ResourceLoader<IImage> _imageLoader;

        public SpriteFontLoader(GlContext context, ResourceLoader<IImage> imageLoader, IResourceResolver resolver) 
            : base(resolver)
        {
            _context = context;
            _imageLoader = imageLoader;
        }

        private Texture LoadTexture(XDocument doc)
        {
            var textureKey = doc.Descendants("page").First().Attribute("file").Value;
            return _context.TextureFromImage(_imageLoader.Load(textureKey));
        }

        private async Task<Texture> LoadTextureAsync(XDocument doc)
        {
            var textureKey = doc.Descendants("page").First().Attribute("file").Value;
            return _context.TextureFromImage(await _imageLoader.LoadAsync(textureKey));
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

        public override async Task<SpriteFont> LoadAsync(string key)
        {
            using (var stream = ResolveResourceId(key))
            {
                var doc = XDocument.Load(stream);
                var texture = await LoadTextureAsync(doc);
                return LoadFromXml(doc, texture);
            }
        }

        public override SpriteFont Load(string key)
        {
            using(var stream = ResolveResourceId(key))
            {
                var doc = XDocument.Load(stream);
                var texture = LoadTexture(doc);
                return LoadFromXml(doc, texture);
            }
        }
    }
}
