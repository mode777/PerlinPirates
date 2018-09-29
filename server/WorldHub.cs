using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldServer.Database;
using WorldServer.Dtos;
using WorldServer.Entities;
using WorldServer.Services;
using WorldServer.ValueObjects;

namespace WorldServer
{
    public class WorldHub : Hub
    {
        private readonly ChunkManager _manager;
        private readonly WorldContext _context;

        public WorldHub(ChunkManager manager, WorldContext context)
        {
            _manager = manager;
            _context = context;
        }

        public async Task<PlayerDto> GetPlayer(string id)
        {
            var entity = await _context.FindAsync<GameEntity<Player>>(id);

            if (entity == null)
                return null;

            return new PlayerDto(entity);
        }

        public async Task RegisterPlayer(string name)
        {
            var entity = new GameEntity<Player>(name, 0, 0, new Player(name));

            _context.Add(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<ChunkDto> SubscribeChunk(int x, int y)
        {
            var chunk = await _manager.AcquireChunkAsync(x, y);

            await Groups.AddToGroupAsync(Context.ConnectionId, (x, y).ToString());

            return new ChunkDto(chunk);
        }

        public void UnsubscribeChunk(int x, int y)
        {
            _manager.ReleaseChunkAsync(x,y);
        }
    }
}
