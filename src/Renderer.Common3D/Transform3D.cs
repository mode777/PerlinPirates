using System.Numerics;

namespace Renderer.Common3D
{
    public class Transform3D
    {
        private Vector3 _rotation = Vector3.Zero;
        private Vector3 _scale = Vector3.One;
        private Vector3 _origin = Vector3.Zero;
        private Vector3 _translation = Vector3.Zero;
        public Matrix4x4 Matrix { get; private set; }

        public Transform3D()
        {
            Matrix = Matrix4x4.Identity;
        }

        public Vector3 Rotation
        {
            get => _rotation;
            set
            {
                _rotation = value;
                UpdateMatrix();
            }
        }

        public Vector3 Scale
        {
            get => _scale;
            set => _scale = value;
        }

        public Vector3 Origin
        {
            get => _origin;
            set => _origin = value;
        }

        public Vector3 Translation
        {
            get => _translation;
            set => _translation = value;
        }

        private void UpdateMatrix()
        {
            Matrix = Matrix4x4.CreateFromYawPitchRoll(_rotation.X, _rotation.Y, _rotation.Z);
        }

        public void Rotate(float yaw, float pitch, float roll)
        {
            Rotation = _rotation + new Vector3(yaw, pitch, roll);
            UpdateMatrix();
        }
    }
}