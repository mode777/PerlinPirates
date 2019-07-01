using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ExampleGame.Components
{
    public class GameMap
    {
        private readonly GameTile[] _tiles;
        public int Width { get; }
        public int Height { get; }

        public GameMap(int width, int height, GameTile[] tiles)
        {
            _tiles = tiles;
            Width = width;
            Height = height;
        }

        public GameTile GetTile(Point p)
        {
            return _tiles[p.Y * Width + p.X];
        }
    }
}
