using System.IO;
using System.Xml.Serialization;
using Game.Abstractions;
using Loader.Tmx.Xml;

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
}