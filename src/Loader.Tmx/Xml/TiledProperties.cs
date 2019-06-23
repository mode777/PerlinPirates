using System.Xml.Serialization;

namespace Loader.Tmx.Xml
{
    public class TiledProperties
    {
        [XmlElement("property")] public Property[] Properties { get; set; }
    }
}