using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Game.Abstractions;
using Tgl.Net;
using Tgl.Net.Bindings;
using Tgl.Net.Math;

namespace Renderer.Gles2
{
    public class Shader2d
    {
        private Matrix3 _projectionMatrix = new Matrix3();
        private Matrix3 _uvMatrix = new Matrix3();
        private readonly GlStateCache _state;

        public Shader Shader { get; }

        public Shader2d(GlContext context, ResourceManager resources)
        {
            Shader = resources.LoadResource<Shader>("Resources.Shaders.quad2d");

            _state = context.State;
            _state.PropertyChanged += StateOnPropertyChanged;
            UpdateProjectionMatrix();

        }

        private void StateOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_state.Viewport))
            {
                UpdateProjectionMatrix();
            }
        }

        private void UpdateProjectionMatrix()
        {
            _projectionMatrix.Identity();
            _projectionMatrix.Translate(-1, 1);
            _projectionMatrix.Scale(2.0f / _state.Viewport.Z, -2.0f / _state.Viewport.W);

            Shader.SetUniform("uProject", ref _projectionMatrix);
        }

        public void UpdateUvMatrix(Texture texture)
        {
            if (texture == null)
                return;

            _uvMatrix.Identity();
            _uvMatrix.Scale(1.0f / texture.Width, 1.0f / texture.Height);

            Shader.SetUniform("uProject_uv", ref _uvMatrix);
        }


    }
}
