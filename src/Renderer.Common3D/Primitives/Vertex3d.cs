using System.Numerics;
using System.Runtime.InteropServices;

namespace Renderer.Common3D.Primitives
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Vertex3d
    {
        public readonly Vector3 Position;
        public readonly Vector3 Normal;
        public readonly Vector2 Uv;

        public Vertex3d(Vector3 position, Vector3 normal, Vector2 uv)
        {
            Position = position;
            Normal = normal;
            Uv = uv;
        }
    }
}