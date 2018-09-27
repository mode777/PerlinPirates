using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldServer.Entities
{
    public class WorldEntity
    {
        private string _json;

        protected WorldEntity()
        {

        }

        protected WorldEntity(string id, int chunkX, int chunkY, byte x, byte y, object payload = null)
        {
            Id = id;
            ChunkX = chunkX;
            ChunkY = chunkY;
            X = x;
            Y = y;

            if (payload != null)
                Update(payload);
        }

        public string Id { get; private set; }
        public int ChunkX { get; private set; }
        public int ChunkY { get; private set; }
        public byte X { get; private set; }
        public byte Y { get; private set; }
        
        protected T GetPayload<T>(){
            return JsonConvert.DeserializeObject<T>(_json);
        }        

        public void Update(object payload = null)
        {
            if (payload != null)
                _json = JsonConvert.SerializeObject(payload);
        }
    }
}
