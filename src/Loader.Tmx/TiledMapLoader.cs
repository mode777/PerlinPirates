using System.IO;
using System.Xml.Serialization;
using Game.Abstractions;
using Loader.Tmx.Xml;

namespace Loader.Tmx
{
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
}