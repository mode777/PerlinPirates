using System.Xml.Serialization;

namespace Loader.Tmx.Xml
{
    public class EmbeddedTileset : CommonTileset
    {
        [XmlAttribute("firstgid")] public int FirstGid { get; set; }
        [XmlAttribute("source")] public string Source { get; set; }
    }
}