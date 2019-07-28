using System;
using System.Runtime.InteropServices;

namespace Tgl.Net.Imaging
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ColorRgb
    {
        public static ColorRgb Parse(int val)
        {
            var bytes = BitConverter.GetBytes(val);
            return new ColorRgb(bytes[0], bytes[1], bytes[2]);
        }

        public readonly byte R;
        public readonly byte G;
        public readonly byte B;
        
        public ColorRgb(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }
    }
}