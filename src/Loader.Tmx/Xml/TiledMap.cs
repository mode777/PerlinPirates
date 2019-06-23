using System.Xml.Serialization;

namespace Loader.Tmx.Xml
{
    [XmlRoot("map")]
    public class TiledMap
    {
        [XmlAttribute("version")] public string Version { get; set; }
        [XmlAttribute("tiledversion")] public string TiledVersion { get; set; }
        [XmlAttribute("orientation")] public string Orientation { get; set; }
        [XmlAttribute("renderorder")] public string RenderOrder { get; set; }
        [XmlAttribute("width")] public int Width { get; set; }
        [XmlAttribute("height")] public int Height { get; set; }
        [XmlAttribute("tilewidth")] public int TileWidth { get; set; }
        [XmlAttribute("tileheight")] public int TileHeight { get; set; }
        [XmlAttribute("hexsidelength")] public int HexSideLength { get; set; }
        [XmlAttribute("staggeraxis")] public string StaggerAxis { get; set; }
        [XmlAttribute("staggerindex")] public string StaggerIndex { get; set; }
        [XmlAttribute("backgroundcolor")] public string BackgroundColor { get; set; }
        [XmlAttribute("nextlayerid")] public int NextLayerId { get; set; }
        [XmlAttribute("nextobjectid")] public int NextObjectId { get; set; }
        [XmlElement("properties")] public TiledProperties Properties { get; set; }
        [XmlElement("layer")]  public Layer[] Layers { get; set; }
        [XmlElement("tileset")] public EmbeddedTileset[] Tilesets { get; set; }
    }
}