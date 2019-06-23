using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExampleGame.Entites
{
    public enum TerrainType : byte
    {
        None = 0,
        Ground,
        Solid,
        Hole
    }

    public enum EntityType : byte
    {
        None = 0,
        Player
    }

    public readonly struct GameTile
    {
        public readonly TerrainType Terrain;

        public GameTile(TerrainType terrain)
        {
            Terrain = terrain;
        }
    }

    public class GameMap
    {
        private readonly GameTile[] _tiles;
        private readonly Dictionary<int, GameEntity> _entities;
        public int Width { get; }
        public int Height { get; }

        public GameMap(int width, int height, GameTile[] tiles, GameEntity[] entities)
        {
            _tiles = tiles;
            _entities = entities.ToDictionary(x => x.Id);
            Width = width;
            Height = height;
        }

        public GameTile GetTile(Point p)
        {
            return _tiles[p.Y * Width + p.X];
        }

        public GameEntity GetEntity(int id)
        {
            return _entities[id];
        }

        public IEnumerable<GameEntity> GetEntities(EntityType type)
        {
            return _entities.Values.Where(x => x.Type == type);
        }
    }

    public struct GameEntity
    {
        public readonly int Id;
        public readonly EntityType Type;
        public int X;
        public int Y;

        public GameEntity(int id, EntityType type, int x, int y)
        {
            Id = id;
            Type = type;
            X = x;
            Y = y;
        }
    }
}
