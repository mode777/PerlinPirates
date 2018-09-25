using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldServer.Extensions
{
    public static class ByteExtensions
    {
        /// <summary>
        /// Smooth mix two values together, given a ratio
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="ratio">0 means only value a, 1 means only value b</param>
        public static byte Mix(this byte a, byte b, double ratio)
        {
            return (byte)(a * (1 - ratio) + b * ratio);
        }

    }
}
