using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldServer.Dtos;
using WorldServer.Services;

namespace WorldServer
{
    public class WorldHub : Hub
    {
        private readonly ChunkManager _manager;

        public WorldHub(ChunkManager manager)
        {
            _manager = manager;
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
