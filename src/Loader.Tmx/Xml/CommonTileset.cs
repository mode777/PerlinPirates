using System.Xml.Serialization;

namespace Loader.Tmx.Xml
{
    public abstract class CommonTileset
    {
        [XmlAttribute("name")] public string Name { get; set; }
        [XmlAttribute("tilewidth")] public int TileWidth { get; set; }
        [XmlAttribute("tileheight")] public int TileHeight { get; set; }
        [XmlAttribute("spacing")] public int Spacing { get; set; }
        [XmlAttribute("margin")] public int Margin { get; set; }
        [XmlAttribute("tilecount")] public int TileCount { get; set; }
        [XmlAttribute("columns")] public int Columns { get; set; }
        [XmlElement("image")] public TiledImage Image { get; set; }
        [XmlElement("tile")] public TilesetTile[] Tiles { get; set; }
    }

    public class TilesetTile
    {
        [XmlAttribute("id")] public int Id { get; set; }
        [XmlElement("properties")] public TiledProperties Properties { get; set; }
    }
}