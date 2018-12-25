using System;
using System.Collections.Generic;
using System.Text;
using Tgl.Net.Bindings;
using Tgl.Net.Buffer;
using Tgl.Net.Math;
using Tgl.Net.Shader;
using Tgl.Net.State;

namespace Renderer.Gles2.Tests
{
    public class SimpleTriangle : IRenderTest
    {
        private VertexBuffer _buffer;
        private Shader _shader;
        
        public void Init(GlState state)
        {
            _shader = state.BuildShader()
                .HasVertexResource("Resources.Shaders.minimal_vertex.glsl")
                .HasFragmentResource("Resources.Shaders.minimal_fragment.glsl")
                .Build();

            _buffer = state.BuildBuffer()
                .HasData(3, -0.5f, -0.5f, 0.5f, -0.5f, 0, 0.5f)
                .HasAttribute("aPosition", 2)
                .Build();
        }

        public void Render(GlState state)
        {
            _buffer.Bind();
            _buffer.EnableAttribute("aPosition", _shader.GetAttributeLocation("aPosition"));
            
            state.ColorClearValue = new Vector4(1, 0.5f, 0, 1);
            state.Clear(GL.ClearBufferMask.GL_COLOR_BUFFER_BIT);
            state.DrawArrays(GL.PrimitiveType.GL_TRIANGLES, 0, 3);
        }
    }
}
