using System.Numerics;

namespace Renderer.Common3D
{
    public class Camera3D
    {
        private static readonly Vector3 Up = new Vector3(0,1,0);

        private Vector3 _position;
        private Vector3 _target;

        public Camera3D(Vector3 position, Vector3 target)
        {
            _position = position;
            _target = target;
            UpdateView();
        }

        public Vector3 Position
        {
            get => _position;
            set
            {
                _position = value;
                UpdateView();
            }
        }

        public Vector3 Target
        {
            get => _target;
            set
            {
                _target = value;
                UpdateView();
            }
        }

        public Matrix4x4 ViewMatrix { get; private set; }

        private void UpdateView()
        {
            ViewMatrix = Matrix4x4.CreateLookAt(
                _position,
                _target,
                Up);
        }

    }
}