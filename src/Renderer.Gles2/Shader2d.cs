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
        private Texture _texture;
        private Shader _shader;

        public Shader2d(GlContext context, ResourceManager resources)
        {
            _shader = resources.LoadResource<Shader>("Resources.Shaders.quad2d");
            
            _state = context.State;
            _state.PropertyChanged += StateOnPropertyChanged;
            
        }

        public Texture Texture
        {
            get => _texture;
            set
            {
                if (_texture.Handle == value.Handle)
                    return;

                _texture = value;
                UpdateUvMatrix();
            }
        }

        private void StateOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Viewport")
            {
                UpdateProjectionMatrix();
            }
            // TODO: Detect texture change
        }

        private void UpdateProjectionMatrix()
        {
            _projectionMatrix.Identity();
            _projectionMatrix.Translate(-1, 1);
            _projectionMatrix.Scale(2.0f / _state.Viewport.Z, -2.0f / _state.Viewport.W);

            _shader.SetUniform("uProject", ref _uvMatrix);
        }

        private void UpdateUvMatrix()
        {
            _uvMatrix.Identity();
            _uvMatrix.Scale(1.0f / _texture.Width, 1.0f / _texture.Height);

            _shader.SetUniform("uProject_uv", ref _uvMatrix);
        }

        
    }
}
