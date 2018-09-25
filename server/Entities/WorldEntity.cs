using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldServer.Entities
{
    public class WorldEntity
    {
        private WorldEntity()
        {

        }

        public WorldEntity(int chunkX, int chunkY, byte x, byte y, short entityId, object payload = null)
        {
            ChunkX = chunkX;
            ChunkY = chunkY;
            X = x;
            Y = y;
            EntityId = entityId;

            if (payload != null)
                JsonConvert.SerializeObject(payload);
        }

        public int ChunkX { get; private set; }
        public int ChunkY { get; private set; }
        public byte X { get; private set; }
        public byte Y { get; private set; }
        public short EntityId { get; private set; }
        public string Payload { get; private set; }

        public void Update(short entityId, object payload = null)
        {
            EntityId = entityId;

            if (payload != null)
                JsonConvert.SerializeObject(payload);
        }
    }
}
