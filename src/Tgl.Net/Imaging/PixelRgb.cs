using System;
using System.Runtime.InteropServices;

namespace Tgl.Net.Imaging
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct PixelRgb
    {
        public static PixelRgb Parse(int val)
        {
            var bytes = BitConverter.GetBytes(val);
            return new PixelRgb(bytes[0], bytes[1], bytes[2]);
        }

        public readonly byte R;
        public readonly byte G;
        public readonly byte B;
        
        public PixelRgb(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }
    }
}