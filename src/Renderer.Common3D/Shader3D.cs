using System;
using System.Numerics;
using Game.Abstractions;
using Tgl.Net;

namespace Renderer.Common3D
{
    public class Shader3D
    {
        private readonly GlContext _context;
        private readonly int _mvpLocation;
        private readonly int _mLocation;
        private readonly int _vLocation;
        private readonly int _light1Location;
        private readonly int _light1LocationPs;

        public Shader Shader { get; }
        public Matrix4x4 ProjectionMatrix { get; private set; }
        public Matrix4x4 ViewMatrix { get; set; }
        public Matrix4x4 ModelMatrix { get; set; }
        public Light Light1 { get; set; }
        
        public Shader3D(GlContext context, ResourceManager resources)
        {
            _context = context;
            Shader = resources.LoadResource<Shader>("Resources/Shaders/shader3d");
            _mvpLocation = Shader.GetUniformLocation("MVP");
            _mLocation = Shader.GetUniformLocation("M");
            _vLocation = Shader.GetUniformLocation("V");
            _light1Location = Shader.GetUniformLocation("LightPosition_worldspace");
            _light1LocationPs = Shader.GetUniformLocation("LightPosition_worldspace_ps");


            _context.State.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(_context.State.Viewport))
                {
                    UpdateProjection();
                }
            };
            UpdateProjection();
        }

        private void UpdateProjection()
        {
            var viewport = _context.State.Viewport;

            ProjectionMatrix =
                Matrix4x4.CreatePerspectiveFieldOfView(
                    ToRadians(45),
                    (float)viewport.Width / (float)viewport.Height,
                    0.1f,
                    100);
        }

        private static float ToRadians(float angle)
        {
            return (float)(Math.PI / 180) * angle;
        }

        public void Update()
        {
            Shader.SetUniform(_mvpLocation, ModelMatrix * ViewMatrix * ProjectionMatrix);
            Shader.SetUniform(_mLocation, ModelMatrix);
            Shader.SetUniform(_vLocation, ViewMatrix);
            Shader.SetUniform(_light1Location, Light1.Position);
            Shader.SetUniform(_light1LocationPs, Light1.Position);
        }

    }
}