using System.Numerics;

namespace Renderer.Common3D
{
    public class Light
    {
        public Light(Vector3 position, Vector3 color, float power)
        {
            Position = position;
            Color = color;
            Power = power;
        }

        public Vector3 Position { get; set; }
        public Vector3 Color { get; set; }
        public float Power { get; set; }
    }
}