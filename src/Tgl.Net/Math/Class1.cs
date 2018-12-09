using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Tgl.Net.Math
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vertex4f
    {
        public float X;
        public float Y;
        public float Z;
        public float W;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Color
    {
        public float R;
        public float G;
        public float B;
        public float A;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vertex4i
    {
        public int X;
        public int Y;
        public int Z;
        public int W;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Rectangle
    {
        public int X;
        public int Y;
        public int W;
        public int H;
    }
}
