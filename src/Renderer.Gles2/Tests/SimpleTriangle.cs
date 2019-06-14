using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Game.Abstractions;
using Tgl.Net;
using Tgl.Net.Bindings;
using Tgl.Net.Math;

namespace Renderer.Gles2.Tests
{
    public class SimpleTriangle : IRenderTest
    {
        private IDrawable _drawable;
        
        public void Init(GlContext context, ResourceManager manager)
        {
            var shader = manager.LoadResource<Shader>("Resources.Shaders.minimal");

            _drawable = context.BuildDrawable()
                .UseShader(shader)
                .AddBuffer<float>(b => b
                    .HasAttribute("aPosition", 2)
                    .HasData(-0.5f, -0.5f, 0.5f, -0.5f, 0, 0.5f))
                .Build();
        }

        public void Render(GlContext context)
        {
            context.State.ColorClearValue = new Vector4(1, 0.5f, 0, 1);

            context.Clear(ClearBufferMask.GL_COLOR_BUFFER_BIT);
            context.DrawDrawable(_drawable);
        }
    }
}
