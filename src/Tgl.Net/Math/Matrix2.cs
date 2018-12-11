using System.Runtime.InteropServices;

namespace Tgl.Net.Math
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix2
    {
        public float M00;
        public float M10;

        public float M01;
        public float M11;
    }
}