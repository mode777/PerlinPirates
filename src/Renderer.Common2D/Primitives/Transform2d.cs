using System;
using System.Numerics;

namespace Renderer.Common2D.Primitives
{
    public class Transform2d
    {
        private float _rotation = 0;
        private float _sin = 0;
        private float _cos = 1;

        public Matrix3x2 Matrix;
        
        public Transform2d()
        {
            Matrix = Matrix3x2.Identity;
        }
        
        public float X { get; set; }

        public float Y { get; set; }

        public float OriginX { get; set; }

        public float OriginY { get; set; }

        public float Rotation
        {
            get => _rotation;
            set
            {
                _rotation = value;
                _cos = (float) Math.Cos(value);
                _sin = (float) Math.Sin(value);
            }
        }

        public float ScaleX { get; set; } = 1;
        public float ScaleY { get; set; } = 1;

        public void UpdateMatrix()
        {
            Matrix.M11 = ScaleX * _cos;
            Matrix.M12 = ScaleX * _sin;

            Matrix.M21 = ScaleY * -_sin;
            Matrix.M22 = ScaleY * _cos;

            Matrix.M31 = -OriginX * ScaleX * _cos + -OriginY * ScaleY * -_sin + X;
            Matrix.M32 = -OriginX * ScaleX * _sin + -OriginY * ScaleY * _cos + Y;
        }
    }
}
