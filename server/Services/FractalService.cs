using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldServer.Services
{
    public class FractalService
    {
        private readonly FastNoise _noise;

        public FractalService(IConfiguration config)
        {
            Seed = config.GetValue<int>("Seed");

            _noise = new FastNoise(Seed);

            Configure();
        }

        public int Seed { get; }

        public byte GetValue(int x, int y)
        {
            var value = Normalize(_noise.GetPerlinFractal(x, y));


            return value;
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


    }
}
