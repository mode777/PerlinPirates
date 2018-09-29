using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using WorldServer.ValueObjects;

namespace WorldServer.Entities
{
    public class PlayerEntity : GameEntity<Player>
    {

        public PlayerEntity(string id, int x, int y, string name) 
            : base(id, x, y, new Player(name))
        {
            UpdateHitbox();
        }

        public int PixelX => (X + ChunkX * WorldConstants.ChunkColumns) * WorldConstants.TileWidth + Payload.Px;
        public int PixelY => (Y + ChunkY * WorldConstants.TileHeight) * WorldConstants.TileHeight + Payload.Py;

        public Rectangle Hitbox { get; private set; }

        public void Move(int x, int y)
        {
            SetPixelPosition(PixelX + x, PixelY + y);
        }

        private void UpdateHitbox()
        {
            Hitbox = WorldConstants.PlayerHitbox;
            Hitbox.Offset(PixelX, PixelY);
        }

        private void SetPixelPosition(int x, int y)
        {
            Payload.Px = x % WorldConstants.TileWidth;
            Payload.Py = y % WorldConstants.TileHeight;

            X = (byte)((x / WorldConstants.TileWidth) % WorldConstants.ChunkColumns);
            Y = (byte)((x / WorldConstants.TileHeight) % WorldConstants.ChunkRows);

            ChunkX = x / (WorldConstants.TileWidth * WorldConstants.ChunkColumns);
            ChunkY = y / (WorldConstants.TileHeight * WorldConstants.ChunkRows);

            UpdateHitbox();
        }
    }
}
