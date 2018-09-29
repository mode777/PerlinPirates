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
        private readonly PlayerService _playerService;

        public WorldHub(ChunkManager manager, PlayerService playerService)
        {
            _manager = manager;
            _playerService = playerService;
        }

        public async Task<PlayerDto> GetPlayer(string id)
        {
            var ent = await _playerService.GetPlayer(id);

            return ent != null
                ? new PlayerDto(ent)
                : null;
        }

        public async Task RegisterPlayer(string name)
        {
            _playerService.CreatePlayer(name, name);
            await _playerService.Finish();
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
