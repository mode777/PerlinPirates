using System.Xml.Serialization;

namespace Loader.Tmx.Xml
{
    public class TiledImage
    {
        [XmlAttribute("source")] public string Source { get; set; }
        [XmlAttribute("width")] public int Width { get; set; }
        [XmlAttribute("height")] public int Height { get; set; }

    }
}