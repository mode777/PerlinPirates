using System.Xml.Serialization;

namespace Loader.Tmx.Xml
{
    public class Property
    {
        [XmlAttribute("name")] public string Name { get; set; }
        [XmlAttribute("value")] public string Value { get; set; }
    }
}