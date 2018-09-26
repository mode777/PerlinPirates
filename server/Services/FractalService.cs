using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldServer.Constants;

namespace WorldServer.Services
{
    public class FractalService
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
        static FractalService()
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

        private readonly FastNoise _noise;

        public FractalService(IConfiguration config)
        {
            Seed = config.GetValue<int>("Seed");

            _noise = new FastNoise(Seed);

            Configure();
        }

        public int Seed { get; }

        private byte GetValue(int x, int y)
        {
            var value = Normalize(_noise.GetPerlinFractal(x, y));
            return value;
        }

        // public (int, int) GetStartPosition(){
        //     var r = new Random();
            
        //     int x,y;

        //     var cx = r.Next(1000);
        //     var cy = r.Next(1000);

        //     if(cy % 2 == 0)
        //         x = Mod(x + Columns/2, Columns);
        // }

        public TerrainType GetTerrain(int x, int y)
        {
            var cx = x / Columns;
            var cy = y / Rows;

            var wx = Mod(x + (Math.Abs(cy)%2 * (Columns/2)), Columns);
            var wy = Mod(y, Rows);
            
            var weight = Weights[wx + (wy * Rows)] ;

            var fract = GetValue(x,y);

            var heightVal = Mix(fract, weight, 0.33);

            for (TerrainType i = TerrainType.DeepWater; i <= TerrainType.Volcano; i++)
            {
                if(heightVal <= Ramp[(byte)i])
                    return i;
            }

            return TerrainType.DeepWater;
        }

        private void Configure()
        {
            _noise.SetFrequency(0.16f);
            _noise.SetFractalType(FastNoise.FractalType.FBM);
        }

        private static byte Normalize(float f)
        {
            return (byte)(((f + 1.2)/2.2) * 255);
        }

        // Real modulo
        private static int Mod(int a, int b)
        {
            return (Math.Abs(a * b) + a) % b;
        }

        private static byte Mix(byte a, byte b, double ratio)
        {
            return (byte)(a * (1 - ratio) + b * ratio);
        }
    }
}
