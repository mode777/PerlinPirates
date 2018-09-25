using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldServer.Constants
{
    public enum TerrainType : byte
    {
        DeepWater = 0,
        ShallowWater = 1,
        Coast = 2,
        Wood = 3,
        Mountain = 4,
        Volcano = 5
    }
}
