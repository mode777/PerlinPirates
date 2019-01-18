using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using Game.Abstractions;
using Tgl.Net;
using Tgl.Net.Bindings;
using Tgl.Net.Math;

namespace Renderer.Gles2
{
    public class Renderer
    {
        private readonly GlContext _context;
        private readonly ResourceManager _resources;
        private readonly Shader _shader;
        private readonly DrawableBuilder _drawable;

        private Matrix3 _projection = new Matrix3();

        public Renderer(GlContext context, ResourceManager resources)
        {
            _context = context;
            _resources = resources;
            _shader = _resources.LoadResource<Shader>("Resources.Shaders.game2d");
            _context.State.PropertyChanged += OnStateOnPropertyChanged;

            _drawable.UseShader(_shader);
        }

        private void OnStateOnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            switch (args.PropertyName)
            {
                case nameof(GlStateCache.Viewport):
                    UpdateProjectionMatrix();
                    return;
            }
        }

        private void UpdateProjectionMatrix()
        {
            var viewport = _context.State.Viewport;

            _projection.Identity();
            _projection.Translate(-1, 1);
            _projection.Scale(2.0f / viewport.Z, -2.0f / viewport.W);

            _shader.SetUniform("uProject", ref _projection);
        }

        private void SetTexture(Texture texture)
        {
            _drawable.AddTexture("uTexture", texture);
            _drawable.AddUniformSetter("uTextureSize", s
                => s.SetUniform("uTextureSize", texture.Width, texture.Height));
        }

        public void RenderSprites(SpriteBatch batch)
        {
            foreach (var (start, end, text) in batch.EnumerateSlices())
            {
                SetTexture(text);
            }
        }

    }
}
