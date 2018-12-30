using System;
using System.Collections.Generic;
using System.Text;
using Game.Abstractions;
using Tgl.Net;
using Tgl.Net.Bindings;
using Tgl.Net.Helpers;
using Tgl.Net.Math;

namespace Renderer.Gles2.Tests
{
    public class PngTexture : IRenderTest
    {
        private readonly IImageLoader _loader;
        private IDrawable _drawable;

        public PngTexture(IImageLoader loader)
        {
            _loader = loader;
        }

        public void Init(GlState state, GlContext context)
        {
            _drawable = new DrawableBuilder(state)
                .UseShader(s => s
                    .HasVertexResource("Resources.Shaders.texture_checker_vertex.glsl")
                    .HasFragmentResource("Resources.Shaders.texture_checker_fragment.glsl"))
                .AddBuffer<float>(b => b
                    .HasAttribute("aPosition", 2)
                    .HasAttribute("aTexcoord", 2)
                    .HasData(
                        -1, -1, 0, 1,
                        1, -1, 1, 1,
                        1, 1, 1, 0,
                        -1, 1, 0, 0))
                .AddTexture<byte>("uTexture", t => t
                    .HasSize(256, 256)
                    .HasData(_loader.Load(ResourceHelpers.GetResourceStream("Resources.Textures.grid.png"), PixelFormat.Rgba).Data))
                .UseIndices(3, 0, 1, 3, 1, 2)
                .Build();
        }

        public void Render(GlState state, GlContext context)
        {
            state.ColorClearValue = new Vector4(0,1,0,1);

            context.Clear(GL.ClearBufferMask.GL_COLOR_BUFFER_BIT);

            context.DrawDrawable(_drawable);
        }
    }
}
