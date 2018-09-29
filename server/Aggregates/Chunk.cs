using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using WorldServer.Constants;
using WorldServer.Entities;
using WorldServer.Services;

namespace WorldServer.Aggregates
{
    public class Chunk
    {
        const int Rows = WorldConstants.ChunkRows;
        const int Columns = WorldConstants.ChunkColumns;
        
        private readonly TerrainType[] _generated = new TerrainType[(Rows + 1) * (Columns + 1)];
        private readonly FractalService _fractal;

        public Chunk(FractalService fractal, int x, int y)
        {
            _fractal = fractal;

            X = x;
            Y = y;

            GenerateFractal();            
        }

        public int X { get; }
        public int Y { get; }
        public int Width => Columns;
        public int Height => Rows;      

        public TerrainType[] GetData()
        {
            return _generated;
        }       
        
        public Point TryMoveRectangle(Rectangle rect, Point offset, TerrainMovement movement)
        {
            var target = rect;
            target.Offset(offset);

            // Todo: Continue...
            throw new NotImplementedException();
        }

        private void GenerateFractal()
        {
            for (int y = -1; y < Rows; y++)
            {
                for (int x = -1; x < Columns; x++)
                {
                    _generated[(x+1) + ((y+1) * (Columns+1))] = 
                        _fractal.GetTerrain(x + Columns * X, y + Rows * Y);
                }
            }
        }
    }
}
