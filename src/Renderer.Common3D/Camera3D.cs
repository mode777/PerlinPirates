using System.Numerics;

namespace Renderer.Common3D
{
    public class Camera3D
    {
        private static readonly Vector3 Up = new Vector3(0,1,0);

        private Vector3 _position;
        private Vector3 _target;
        private bool _dirty = true;
        private Matrix4x4 _viewMatrix;

        public Camera3D(Vector3 position, Vector3 target)
        {
            _position = position;
            _target = target;
        }

        public Vector3 Position
        {
            get => _position;
            set
            {
                _position = value;
                _dirty = true;
            }
        }

        public Vector3 Target
        {
            get => _target;
            set
            {
                _target = value;
                _dirty = true;
            }
        }

        public Matrix4x4 ViewMatrix
        {
            get
            {
                if (_dirty)
                {
                    UpdateView();
                }
                return _viewMatrix;
            }
        }

        private void UpdateView()
        {
            _viewMatrix = Matrix4x4.CreateLookAt(
                _position,
                _target,
                Up);
            _dirty = false;
        }

        public void Orbit(Vector3 amount)
        {
            Position = Vector3.Transform(Position, Matrix4x4.CreateFromYawPitchRoll(amount.X,amount.Y, amount.Z));
        }

        public void OrbitX(float amount)
        {
            Position = Vector3.Transform(Position, Matrix4x4.CreateRotationX(amount, Target));
        }

        public void OrbitZ(float amount)
        {
            Position = Vector3.Transform(Position, Matrix4x4.CreateRotationZ(amount, Target));
        }
    }
}