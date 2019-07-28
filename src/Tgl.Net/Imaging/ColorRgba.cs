using System;
using System.Runtime.InteropServices;

namespace Tgl.Net.Imaging
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ColorRgba
    {
        public static ColorRgba Parse(uint val)
        {
            var bytes = BitConverter.GetBytes(val);
            return new ColorRgba(bytes[3], bytes[2], bytes[1], bytes[0]);
        }

        public readonly byte R;
        public readonly byte G;
        public readonly byte B;
        public readonly byte A;

        public ColorRgba(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }
}