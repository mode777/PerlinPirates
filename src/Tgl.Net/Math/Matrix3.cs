﻿using System.Runtime.InteropServices;

namespace Tgl.Net.Math
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix3
    {
        public float M00;
        public float M01;
        public float M02;

        public float M10;
        public float M11;
        public float M12;

        public float M20;
        public float M21;
        public float M22;
    }
}