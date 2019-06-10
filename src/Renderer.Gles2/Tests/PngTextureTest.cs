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
    public class PngTextureTest : IRenderTest
    {
        private IDrawable _drawable;
        
        public void Init(GlContext context, ResourceManager resources)
        {
            var shader = resources.LoadResource<Shader>("Resources.Shaders.texture_checker");
            var texture = resources.LoadResource<Texture>("Resources.Textures.grid.png");

            _drawable = context.BuildDrawable()
                .UseShader(shader)
                .AddBuffer<float>(b => b
                    .HasAttribute("aPosition", 2)
                    .HasAttribute("aTexcoord", 2)
                    .HasData(
                        -1, -1, 0, 1,
                        1, -1, 1, 1,
                        1, 1, 1, 0,
                        -1, 1, 0, 0))
                .AddTexture("uTexture", texture)
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
