using Endobit.DomainDrivenDesign;
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
        private readonly IPublisher _publisher;

        public WorldHub(ChunkManager manager, IPublisher publisher)
        {
            _manager = manager;
            _publisher = publisher;
        }

        public async Task<ChunkDto> SubscribeChunk(int x, int y)
        {
            var chunk = await _manager.AcquireChunkAsync(x, y);

            await Groups.AddToGroupAsync(Context.ConnectionId, (x, y).ToString());

            return new ChunkDto(chunk);
        }

        //public async Task SetEntity(int chunkX, int chunkY, byte x, byte y, short typeId)
        //{
        //    var chunk = await _manager.GetChunkAsync(chunkX, chunkY);

        //    chunk.Set(x, y, typeId);

        //    await Clients.Group((chunkX, chunkY).ToString()).SendAsync("onTileChanged", chunkX, chunkY, x, y, typeId);

        //    await _publisher.Commit();
        //}

        //public async Task RemoveEntity(int chunkX, int chunkY, byte x, byte y)
        //{
        //    var chunk = await _manager.GetChunkAsync(chunkX, chunkY);

        //    var typeId = chunk.Unset(x, y);

        //    await Clients.Group((chunkX, chunkY).ToString()).SendAsync("onTileChanged", chunkX, chunkY, x, y, typeId);

        //    await _publisher.Commit();
        //}

        public void UnsubscribeChunk(int x, int y)
        {
            _manager.ReleaseChunkAsync(x,y);
        }
    }
}
