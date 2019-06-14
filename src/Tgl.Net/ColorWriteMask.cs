using System.Runtime.InteropServices;

namespace Tgl.Net
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ColorWriteMask
    {
        public bool R;
        public bool G;
        public bool B;
        public bool A;
    }
}
