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

        public async Task<GameEntity<Player>> CreatePlayer(string id, Player player, int x, int y)
        {
            var entity = new GameEntity<Player>(id,x,y,player);

            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
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
