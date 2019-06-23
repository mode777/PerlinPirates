using System;
using System.ComponentModel.Design;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Loader.Tmx.Xml
{
    public class Layer
    {
        private readonly Lazy<Tile[]> _decodedLazy;

        public Layer()
        {
           _decodedLazy = new Lazy<Tile[]>(Decode);
        }

        [XmlAttribute("id")] public int Id { get; set; }
        [XmlAttribute("name")] public string Name { get; set; }
        [XmlAttribute("width")] public int Width { get; set; }
        [XmlAttribute("height")] public int Height { get; set; }
        [XmlAttribute("opacity")] public double Opacity { get; set; } = 1;
        [XmlAttribute("visible")] public bool Visible { get; set; } = true;
        [XmlAttribute("offsetx")] public int OffsetX { get; set; }
        [XmlAttribute("offsety")] public int OffsetY { get; set; }
        [XmlElement("data")] public LayerData Data { get; set; }

        [XmlIgnore] public Tile[] Decoded => _decodedLazy.Value;

        private Tile[] Decode()
        {
            // XML
            if (Data.Encoding == null)
            {
                throw new NotImplementedException();
            }
            else if (Data.Encoding == "csv")
            {
                return Data.Encoded
                    .Trim()
                    .Split(',')
                    .Select(x => new Tile(uint.Parse(x)))
                    .ToArray();
            }
            else if (Data.Encoding == "base64")
            {
                var bytes = Convert.FromBase64String(Data.Encoded);

                if (Data.Compression == null)
                {
                    var size = bytes.Length / sizeof(int);
                    var ints = new Tile[size];
                    for (var index = 0; index < size; index++)
                    {
                        ints[index] = new Tile(BitConverter.ToUInt32(bytes, index * sizeof(int)));
                    }

                    return ints;
                }
                else if (Data.Compression == "zlib")
                {
                    var bodyLength = bytes.Length - 6;
                    byte[] bodyData = new byte[bodyLength];
                    Array.Copy(bytes, 2, bodyData, 0, bodyLength);

                    var bodyStream = new MemoryStream(bodyData, false);
                    var data = new DeflateStream(bodyStream, CompressionMode.Decompress);

                    using (var br = new BinaryReader(data))
                    {
                        return Enumerable.Repeat(0, Width * Height)
                            .Select(x => new Tile(br.ReadUInt32()))
                            .ToArray();
                    }
                }
                else if (Data.Compression == "gzip")
                {
                    throw new NotImplementedException();
                }
                else
                {
                    throw new InvalidOperationException("Unknown compression");
                }
            }
            else
            {
                throw new InvalidOperationException("Unknown encoding");
            }
        }


    }
}