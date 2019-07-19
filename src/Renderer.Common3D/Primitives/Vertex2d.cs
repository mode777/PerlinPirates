using System.Numerics;
using System.Runtime.InteropServices;

namespace Renderer.Common3D.Primitives
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vertex3d
    {
        public Vector3 Position;
        public Vector3 Normal;
        public Vector2 Uv;
    }
}