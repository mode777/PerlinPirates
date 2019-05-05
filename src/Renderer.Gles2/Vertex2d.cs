using System.Runtime.InteropServices;
using Tgl.Net.Math;

namespace Renderer.Gles2
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vertex2d
    {
        public Vector2 Position;
        public Vector2 Uv;
        public Vector4 Color;
    }
}