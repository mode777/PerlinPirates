﻿using System.ComponentModel;
using Game.Abstractions;
using Tgl.Net;
using Tgl.Net.Math;

namespace Renderer.Common2D.Primitives
{
    public class Shader2d
    {
        private Matrix3x3 _projectionMatrix = new Matrix3x3();
        private Matrix3x3 _uvMatrix = new Matrix3x3();
        private readonly GlStateCache _state;

        public Shader Shader { get; }

        public Shader2d(GlContext context, ResourceManager resources)
        {
            Shader = resources.LoadResource<Shader>("Resources/Shaders/quad2d");

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
            _projectionMatrix.Scale(2.0f / _state.Viewport.Width, -2.0f / _state.Viewport.Height);

            Shader.SetUniform("uProject", _projectionMatrix);
        }

        public void UpdateUvMatrix(Texture texture)
        {
            if (texture == null)
                return;

            _uvMatrix.Identity();
            _uvMatrix.Scale(1.0f / texture.Width, 1.0f / texture.Height);

            Shader.SetUniform("uProject_uv", _uvMatrix);
        }


    }
}