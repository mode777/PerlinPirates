using System;
using System.Collections.Generic;
using System.Text;
using Game.Abstractions;
using Tgl.Net;
using Tgl.Net.Bindings;
using Tgl.Net.Math;

namespace Renderer.Gles2.Tests
{
    public class TextureChecker : IRenderTest
    {
        private IDrawable _drawable;

        public void Init(GlContext context, ResourceManager res)
        {
            var shader = res.LoadResource<Shader>("Resources.Shaders.texture_checker");

            _drawable = context.BuildDrawable()
                .UseShader(shader)
                .AddBuffer<float>(b => b
                    .HasAttribute("aPosition", 2)
                    .HasAttribute("aTexcoord", 2)
                    .HasData(
                        -0.5f, -0.5f, 0, 0,
                        0.5f, -0.5f, 5, 0,
                        0.5f, 0.5f, 5, 5,
                        -0.5f, 0.5f, 0, 5))
                .AddTexture<byte>("uTexture", t => t
                    .HasSize(2, 2)
                    .HasFiltering(TextureMinType.GL_NEAREST, TextureMagType.GL_NEAREST)
                    .HasData(
                        0, 0, 255, 255,
                        255, 255, 0, 255,
                        255, 255, 0, 255,
                        0, 0, 255, 255))
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
