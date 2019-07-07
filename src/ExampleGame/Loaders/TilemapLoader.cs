using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Game.Abstractions;
using Loader.Tmx.Xml;
using Renderer.Gles2;
using Tgl.Net;

namespace ExampleGame.Loaders
{
    public class TilemapLoader : ResourceLoader<Tilemap>
    {
        private readonly ResourceManager _manager;
        private readonly Context2d _context;
        private readonly XmlSerializer _serializer;

        public TilemapLoader(ResourceManager manager, Context2d context)
        {
            _manager = manager ?? throw new ArgumentNullException(nameof(manager));
            _context = context;
            _serializer = new XmlSerializer(typeof(TiledMap));
        }

        public override Tilemap Load(string rid, Stream stream)
        {
            var map = _manager.LoadResource<TiledMap>(rid + ".tmx");

            var set = map.Tilesets.First();

            Tileset tileset = null;

            if (set.Source != null)
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

            var tiles = map.Layers.First(x => x.Name == "map")
                .Decoded
                .Select(x => x.Id)
                .ToArray();

            return _context.CreateTilemap(tileset, new Size(map.Width, map.Height), tiles);
        }
    }
}