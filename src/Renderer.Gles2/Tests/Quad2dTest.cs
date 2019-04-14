using System;
using System.Collections.Generic;
using System.Text;
using Game.Abstractions;
using Tgl.Net;
using Tgl.Net.Abstractions;
using Tgl.Net.Bindings;
using Tgl.Net.Helpers;
using Tgl.Net.Math;

namespace Renderer.Gles2.Tests
{
    public class Quad2dTest : IRenderTest
    {
        private IDrawable _drawable;
        
        public void Init(GlContext context, ResourceManager resources)
        {
            var shader = resources.LoadResource<Shader>("Resources.Shaders.quad2d");
            var image = resources.LoadResource<IImage>("Resources.Textures.grid.png");
            var viewport = context.State.Viewport;

            var matrix = new Matrix3();
            matrix.Identity();
            matrix.Translate(-1,1);
            matrix.Scale(2.0f / viewport.Z, -2.0f /  viewport.W);

            var uv_matrix = new Matrix3();
            uv_matrix.Identity();
            uv_matrix.Scale(1.0f / image.Width, 1.0f / image.Height);

           _drawable = context.BuildDrawable()
                .UseShader(shader)
                .AddUniform("uProject", matrix)
                .AddUniform("uProject_uv", uv_matrix)
                .AddBuffer<Sprite>(b => b
                    .HasAttribute("aPosition", 2)
                    .HasAttribute("aTexcoord", 2)
                    .HasData(Sprite.FromDimensions(0,0,256,256)))
                .AddTexture("uTexture", image)
                .UseIndices(3, 0, 1, 3, 1, 2)
                .Build();
        }

        public void Render(GlContext context)
        {
            context.State.ColorClearValue = new Vector4(0,1,0,1);

            context.Clear(ClearBufferMask.GL_COLOR_BUFFER_BIT);

            context.DrawDrawable(_drawable);
        }
    }
}
