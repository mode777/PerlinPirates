using System;
using System.Runtime.InteropServices;

namespace Tgl.Net.Imaging
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct PixelRgba
    {
        public static PixelRgba Parse(int val)
        {
            var bytes = BitConverter.GetBytes(val);
            return new PixelRgba(bytes[0], bytes[1], bytes[2], bytes[3]);
        }

        public readonly byte R;
        public readonly byte G;
        public readonly byte B;
        public readonly byte A;

        public PixelRgba(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }
}