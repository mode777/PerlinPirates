using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Xml.Serialization;
using Game.Abstractions;
using ICSharpCode.SharpZipLib.Zip.Compression;
using Renderer.Gles2;
using Tgl.Net;

namespace Loader.Tmx
{
    public class TiledTilesetLoader : ResourceLoader<TiledTileset>
    {
        private readonly XmlSerializer _serializer;

        public TiledTilesetLoader()
        {
            _serializer = new XmlSerializer(typeof(TiledTileset));
        }

        public override TiledTileset Load(string rid, Stream stream)
        {
            return (TiledTileset)_serializer.Deserialize(stream);
        }
    }

    public class TilesetLoader : ResourceLoader<Tileset>
    {
        private readonly ResourceManager _manager;

        public TilesetLoader(ResourceManager manager)
        {
            _manager = manager;
        }

        public override Tileset Load(string rid, Stream stream)
        {
            var set = _manager.LoadResource<TiledTileset>(rid + ".tsx");

            var texturePath = Path.Combine(Path.GetDirectoryName(rid), set.Image.Source);

            var texture = _manager.LoadResource<Texture>(texturePath);

            return new Tileset(texture, new Size(set.TileWidth, set.TileHeight));
        }
    }

    public class TiledMapLoader : ResourceLoader<TiledMap>
    {
        private readonly XmlSerializer _serializer;

        public TiledMapLoader()
        {
            _serializer = new XmlSerializer(typeof(TiledMap));
        }

        public override TiledMap Load(string rid, Stream stream)
        {
            return (TiledMap)_serializer.Deserialize(stream);
        }
    }
    
    public class TilemapLoader : ResourceLoader<Tilemap>
    {
        private readonly ResourceManager _manager;
        private readonly GlContext _context;
        private readonly Shader2d _shader;
        private readonly XmlSerializer _serializer;

        public TilemapLoader(ResourceManager manager, GlContext context, Shader2d shader)
        {
            _manager = manager ?? throw new ArgumentNullException(nameof(manager));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _shader = shader ?? throw new ArgumentNullException(nameof(shader));
            _serializer = new XmlSerializer(typeof(TiledMap));
        }

        public override Tilemap Load(string rid, Stream stream)
        {
            var map = _manager.LoadResource<TiledMap>(rid + ".tmx");

            var set = map.Tilesets.First();

            Tileset tileset = null;

            if ((set as EmbeddedTileset).Source != null)
            {
                var setPath = Path.Combine(Path.GetDirectoryName(rid), map.Tilesets.First().Source);
                tileset = _manager.LoadResource<Tileset>(setPath.Replace(".tsx", ""));
            }
            else
            {
                var texturePath = Path.Combine(Path.GetDirectoryName(rid), set.Image.Source);
                var texture = _manager.LoadResource<Texture>(texturePath);
                tileset = new Tileset(texture, new Size(set.TileWidth, set.TileHeight));
            }

            var raw = map.Layers.First().Data.Encoded.Trim();
            var compressed = Convert.FromBase64String(raw);
            var bodyLength = compressed.Length - 6;
            byte[] bodyData = new byte[bodyLength];
            Array.Copy(compressed, 2, bodyData, 0, bodyLength);

            var bodyStream = new MemoryStream(bodyData, false);
            var data = new DeflateStream(bodyStream, CompressionMode.Decompress);

            int[] tiles = null;

            using (var br = new BinaryReader(data))
            {
                tiles = Enumerable.Repeat(0, map.Width * map.Height)
                    .Select(x => br.ReadInt32())
                    .ToArray();
            }

            return new Tilemap(_context, _shader, tileset, map.Width, map.Height, tiles);
        }
    }

    [XmlRoot("map")]
    public class TiledMap
    {
        [XmlAttribute("version")] public string Version { get; set; }
        [XmlAttribute("tiledversion")] public string TiledVersion { get; set; }
        [XmlAttribute("orientation")] public string Orientation { get; set; }
        [XmlAttribute("renderorder")] public string RenderOrder { get; set; }
        [XmlAttribute("width")] public int Width { get; set; }
        [XmlAttribute("height")] public int Height { get; set; }
        [XmlAttribute("tilewidth")] public int TileWidth { get; set; }
        [XmlAttribute("tileheight")] public int TileHeight { get; set; }
        [XmlAttribute("hexsidelength")] public int HexSideLength { get; set; }
        [XmlAttribute("staggeraxis")] public string StaggerAxis { get; set; }
        [XmlAttribute("staggerindex")] public string StaggerIndex { get; set; }
        [XmlAttribute("backgroundcolor")] public string BackgroundColor { get; set; }
        [XmlAttribute("nextlayerid")] public int NextLayerId { get; set; }
        [XmlAttribute("nextobjectid")] public int NextObjectId { get; set; }
        [XmlArray("properties")] public Property[] Properties { get; set; }
        [XmlElement("layer")]  public Layer[] Layers { get; set; }
        [XmlElement("tileset")] public EmbeddedTileset[] Tilesets { get; set; }
    }

    public abstract class CommonTileset
    {
        [XmlAttribute("name")] public string Name { get; set; }
        [XmlAttribute("tilewidth")] public int TileWidth { get; set; }
        [XmlAttribute("tileheight")] public int TileHeight { get; set; }
        [XmlAttribute("spacing")] public int Spacing { get; set; }
        [XmlAttribute("margin")] public int Margin { get; set; }
        [XmlAttribute("tilecount")] public int TileCount { get; set; }
        [XmlAttribute("columns")] public int Columns { get; set; }
        [XmlElement("image")] public TiledImage Image { get; set; }
    }

    public class TiledImage
    {
        [XmlAttribute("source")] public string Source { get; set; }
        [XmlAttribute("width")] public int Width { get; set; }
        [XmlAttribute("height")] public int Height { get; set; }

    }

    public class EmbeddedTileset : CommonTileset
    {
        [XmlAttribute("firstgid")] public int FirstGid { get; set; }
        [XmlAttribute("source")] public string Source { get; set; }
    }

    [XmlRoot("tileset")]
    public class TiledTileset : CommonTileset
    {
        [XmlAttribute("version")] public string Version { get; set; }
        [XmlAttribute("tiledversion")] public string TiledVersion { get; set; }
    }

    public class Layer
    {
        [XmlAttribute("id")] public int Id { get; set; }
        [XmlAttribute("name")] public string Name { get; set; }
        [XmlAttribute("width")] public int Width { get; set; }
        [XmlAttribute("height")] public int Height { get; set; }
        [XmlAttribute("opacity")] public double Opacity { get; set; } = 1;
        [XmlAttribute("visible")] public bool Visible { get; set; } = true;
        [XmlAttribute("offsetx")] public int OffsetX { get; set; }
        [XmlAttribute("offsety")] public int OffsetY { get; set; }
        [XmlElement("data")] public LayerData Data { get; set; }
    }

    public class LayerData
    {
        [XmlAttribute("encoding")] public string Encoding { get; set; }
        [XmlAttribute("compression")] public string Compression { get; set; }
        [XmlText] public string Encoded { get; set; }
    }

    public class Property
    {
    }
}