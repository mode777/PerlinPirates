using System.Xml.Serialization;

namespace Loader.Tmx.Xml
{
    [XmlRoot("tileset")]
    public class TiledTileset : CommonTileset
    {
        [XmlAttribute("version")] public string Version { get; set; }
        [XmlAttribute("tiledversion")] public string TiledVersion { get; set; }
    }
}