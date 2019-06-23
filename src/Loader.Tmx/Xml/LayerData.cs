using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Xml.Serialization;

namespace Loader.Tmx.Xml
{
    public class LayerData
    {
        [XmlAttribute("encoding")] public string Encoding { get; set; }
        [XmlAttribute("compression")] public string Compression { get; set; }
        [XmlText] public string Encoded { get; set; }


    }
}