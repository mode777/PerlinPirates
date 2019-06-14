using System.Runtime.InteropServices;

namespace Tgl.Net.Math
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix2x2
    {
        public float M11;
        public float M12;

        public float M21;
        public float M22;
    }
}