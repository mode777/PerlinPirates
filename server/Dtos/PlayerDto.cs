using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldServer.Entities;
using WorldServer.ValueObjects;

namespace WorldServer.Dtos
{
    public class PlayerDto
    {
        public PlayerDto()
        {
        }

        public PlayerDto(PlayerEntity player)
        {
            Id = player.Id;
            X = player.X + player.ChunkX * WorldConstants.ChunkColumns;
            Y = player.Y + player.ChunkY * WorldConstants.ChunkRows;
            Name = player.Payload.Name;
        }

        public string Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Name { get; set; }
    }
}
