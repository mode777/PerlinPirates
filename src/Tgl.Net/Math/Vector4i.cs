using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Tgl.Net.Math
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector4i
    {
        public int X;
        public int Y;
        public int Z;
        public int W;
    }
}
