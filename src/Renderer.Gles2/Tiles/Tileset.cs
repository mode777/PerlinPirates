using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Tgl.Net;

namespace Renderer.Gles2
{
    public class Tileset
    {
        public Texture Texture { get; }
        public Size TileSize { get; }
        public int Columns { get; }
        public int Rows { get; }

        public Tileset(Texture texture, Size tileSize)
        {
            Texture = texture;
            TileSize = tileSize;
            Columns = texture.Width / tileSize.Width;
            Rows = texture.Height / tileSize.Height;
        }

        public Rectangle GetTile(int id)
        {
            if(id < 1 || id > (Columns * Rows)-1)
                throw new IndexOutOfRangeException("Invalid TileId: "+id);

            var p = new Point(((id-1) % Columns) * TileSize.Width, ((id-1) / Columns) * TileSize.Height);
            return new Rectangle(p, TileSize);
        }
    }
}
