using System.Drawing;
using System.IO;
using Game.Abstractions;
using Loader.Tmx.Xml;
using Renderer.Gles2;
using Tgl.Net;

namespace ExampleGame.Loaders
{
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
}