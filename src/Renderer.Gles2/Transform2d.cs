using System;
using System.Collections.Generic;
using System.Text;
using Tgl.Net.Math;

namespace Renderer.Gles2
{
    public class Transform2d
    {
        private float _rotation = 0;
        private float _sin = 0;
        private float _cos = 1;

        public Matrix3 Matrix;
        
        public Transform2d()
        {
            Matrix = new Matrix3();
            Matrix.Identity();
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
            Matrix.M00 = ScaleX * _cos;
            Matrix.M01 = ScaleX * _sin;

            Matrix.M10 = ScaleY * -_sin;
            Matrix.M11 = ScaleY * _cos;

            Matrix.M20 = -OriginX * ScaleX * _cos + -OriginY * ScaleY * -_sin + X;
            Matrix.M21 = -OriginX * ScaleX * _sin + -OriginY * ScaleY * _cos + Y;
        }
    }
}
