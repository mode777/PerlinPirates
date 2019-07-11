using System.Numerics;
using System.Runtime.InteropServices;

namespace Renderer.Common2D.Primitives
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vertex2d
    {
        public Vector2 Position;
        public Vector2 Uv;
        public Vector4 Color;
    }
}