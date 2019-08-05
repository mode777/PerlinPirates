using System.Numerics;
using System.Transactions;

namespace Renderer.Common3D
{
    public class Transform3D
    {
        private Vector3 _rotation = Vector3.Zero;
        private Vector3 _scale = Vector3.One;
        private Vector3 _origin = Vector3.Zero;
        private Vector3 _translation = Vector3.Zero;
        private bool _dirty = true;
        private Matrix4x4 _matrix;

        public Matrix4x4 Matrix
        {
            get
            {

                if (_dirty)
                {
                    UpdateMatrix();
                }
                return _matrix;
            }
        }

        public Transform3D()
        {
            _matrix = Matrix4x4.Identity;
        }

        public Vector3 Rotation
        {
            get => _rotation;
            set
            {
                _rotation = value;
                _dirty = true;
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
            _matrix = Matrix4x4.CreateFromYawPitchRoll(_rotation.X, _rotation.Y, _rotation.Z);
            _dirty = false;
        }

        public void Rotate(float yaw, float pitch, float roll)
        {
            Rotation = _rotation + new Vector3(yaw, pitch, roll);
            _dirty = true;
        }
    }
}