using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ExampleGame.Components
{
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
}
