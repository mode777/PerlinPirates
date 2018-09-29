using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using WorldServer.Database;
using WorldServer.Entities;
using WorldServer.ValueObjects;

namespace WorldServer.Services
{
    public class PlayerService
    {
        private readonly ChunkManager _chunkManager;
        private readonly WorldContext _worldContext;

        public PlayerService(ChunkManager chunkManager, WorldContext worldContext)
        {
            _chunkManager = chunkManager;
            _worldContext = worldContext;
        }

        public Point MovePlayer(string id, int x, int y)
        {
            throw new NotImplementedException();
        }

        public async Task<PlayerEntity> GetPlayer(string id)
        {
            return await _worldContext.FindAsync<PlayerEntity>(id);
        }

        public void CreatePlayer(string id, string name)
        {
            var entity = new PlayerEntity(id, 0, 0, name);

            _worldContext.Add(entity);
        }

        public async Task Finish()
        {
            await _worldContext.SaveChangesAsync();
        }
    }
}
