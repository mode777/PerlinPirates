using System;
using System.Collections.Generic;
using System.Text;
using Tgl.Net.Bindings;
using Tgl.Net.Buffer;
using Tgl.Net.Math;
using Tgl.Net.Shader;
using Tgl.Net.State;
using Tgl.Net.Texture;

namespace Renderer.Gles2.Tests
{
    public class TextureChecker : IRenderTest
    {
        private Shader _shader;
        private VertexBuffer _buffer;
        private IndexBuffer _indexBuffer;
        private Texture _texture;

        public void Init(GlState state)
        {
            _shader = state.BuildShader()
                .HasVertexResource("Resources.Shaders.texture_checker_vertex.glsl")
                .HasFragmentResource("Resources.Shaders.texture_checker_fragment.glsl")
                .Build();

            _buffer = state.BuildBuffer<float>()
                .HasData(
                    -0.5f, -0.5f, 0, 0,
                    0.5f, -0.5f, 1, 0,
                    0.5f, 0.5f, 1, 1,
                    -0.5f, 0.5f, 0, 1)
                .HasAttribute("aPosition", 2)
                .HasAttribute("aTexcoord", 2)
                .Build();

            _indexBuffer = state.CreateIndexBuffer(3, 0, 1, 3, 1, 2);

            _texture = state.BuildTexture()
                .HasSize(2, 2)
                .HasFiltering(GL.TextureMinType.GL_NEAREST, GL.TextureMagType.GL_NEAREST)
                .HasData(
                    GL.PixelFormat.GL_RGBA,
                    GL.InternalFormat.GL_RGBA,
                    0, 0, 255, 255,
                    255, 255, 0, 255,
                    255, 255, 0, 255,
                    0, 0, 255, 255)
                .Build();
        }

        public void Render(GlState state)
        {
            _buffer.EnableAttribute("aPosition", _shader.GetAttributeLocation("aPosition"));
            _buffer.EnableAttribute("aTexcoord", _shader.GetAttributeLocation("aTexcoord"));
            _shader.SetUniform(_shader.GetUniformLocation("uTexture"), state.ActiveTexture);

            state.ColorClearValue = new Vector4(0,1,0,1);

            state.Clear(GL.ClearBufferMask.GL_COLOR_BUFFER_BIT);

            state.DrawElements(GL.PrimitiveType.GL_TRIANGLES, 0, _indexBuffer.Length);
        }
    }
}
