using Endobit.DomainDrivenDesign;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using WorldServer.Constants;
using WorldServer.Entities;
using WorldServer.Events;
using WorldServer.Extensions;
using WorldServer.Services;
using WorldServer.Specifications;

namespace WorldServer.Aggregates
{


    public class Chunk
    {
        const int Rows = 32;
        const int Columns = 32;
        static readonly byte[] Weights = new byte[Rows * Columns];
        static readonly byte[] Ramp = new byte[] {
            130, // deep water
            140, //shallow water
            150, // coast
            170, // woods
            195, // Mountain
            255
        };

        // generate weights
        static Chunk()
        {
            var cx = Columns / (double)2;
            var cy = Rows / (double)2;

            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Columns; x++)
                {
                    Weights[x + (y * Columns)] = (byte)(255 - Math.Clamp(
                        Math.Sqrt(
                            Math.Abs(
                                Math.Pow(x - cx, 2)) + 
                            Math.Abs(
                                Math.Pow(y - cy, 2))) 
                        * (255 / (Rows / 2)), 
                    0, 
                    255));
                }
            }
        }


        private readonly IPublisher _publisher;
        private readonly TerrainType[] _generated = new TerrainType[(Rows + 1) * (Columns + 1)];
        private readonly FractalService _fractal;

        public Chunk(FractalService fractal, IPublisher publisher, IEnumerable<WorldEntity> entities, int x, int y)
        {
            _fractal = fractal;
            _publisher = publisher;

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

        private void GenerateFractal()
        {
            for (int y = -1; y < Rows; y++)
            {
                for (int x = -1; x < Columns; x++)
                {
                    var wx = Mod(x + (Math.Abs(Y)%2 * (Columns/2)), Columns);
                    var wy = Mod(y, Rows);
                    
                    var weight = Weights[wx + (wy * Rows)] ;

                    var fract = _fractal.GetValue(X * Columns + x, Y * Rows + y);

                    var heightVal = fract.Mix(weight, 0.33);

                    for (TerrainType i = TerrainType.DeepWater; i <= TerrainType.Volcano; i++)
                    {
                        if(heightVal <= Ramp[(byte)i])
                        {
                            _generated[(x+1) + ((y+1) * Columns)] = i;
                            break;
                        }
                    }
                }
            }
        }

        // Real modulo
        private static int Mod(int a, int b)
        {
            return (Math.Abs(a * b) + a) % b;
        }
    }
}
