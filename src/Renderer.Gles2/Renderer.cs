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

        private Matrix3x3 _projection = new Matrix3x3();
        private Matrix3x3 _transform = new Matrix3x3();

        public Renderer(GlContext context, ResourceManager resources)
        {
            _context = context;
            _resources = resources;
            _shader = _resources.LoadResource<Shader>("Resources.Shaders.game2d");
            _context.State.PropertyChanged += OnStateOnPropertyChanged;
            UpdateProjectionMatrix();
            _transform.Identity();
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
            _projection.Scale(2.0f / viewport.Width, -2.0f / viewport.Height);
        }

        public void RenderSprites(SpriteBatch batch)
        {

            _context.State.CurrentProgram = _shader.Handle;

            _shader.SetUniform("uProject", ref _projection);
            
            _shader.SetUniform("uTransform", ref _transform);

            var buffer = batch.Buffer;

            foreach (var attribute in buffer.Attributes)
            {
                buffer.EnableAttribute(attribute.Name,
                    _shader.GetAttributeLocation(attribute.Name));
            }

            _context.State.ElementArrayBufferBinding = batch.Indices.Handle;

            foreach (var (start, end, text) in batch.EnumerateSlices())
            {
                _shader.SetUniform("uTexture", TextureUnit.GL_TEXTURE0);
                _shader.SetUniform("uTextureSize", text.Width, text.Height);
                var first = start * 6;
                var count = (end - start + 1) * 6;
                _context.DrawElements(PrimitiveType.GL_TRIANGLES, first, count);
            }
        }

    }
}
