using System;
using System.Collections.Generic;
using System.Text;
using Game.Abstractions;
using Tgl.Net;
using Tgl.Net.Core;
using Tgl.Net.Math;

namespace Renderer.Gles2
{
    public class Gles2Renderer : IRenderer
    {
        private readonly IPlatform _platform;

        private GlState _state;
        private VertexBuffer _buffer;
        private Shader _shader;

        public Gles2Renderer(IPlatform platform)
        {
            _platform = platform;
            platform.CreateGlContext();
            GL.LoadApi(platform.GetGlProcAddress);

            Init();
        }

        public void Init()
        {
            _state = new GlState();
            _shader = _state.BuildShader()
                .WithVertexString(@"attribute vec2 aPosition;
                    void main(void)
                    {
                        gl_Position = vec4(aPosition, 1.0, 1.0);
                    }")
                .WithFragmentString(@"precision mediump float;
                    void main(void)
                    {
                        gl_FragColor = vec4(1, 1, 1, 1);
                    }")
                .Build();

            _buffer = new VertexBuffer(_state, new BufferOptions(
                new float[] { -0.5f, -0.5f, 0.5f, -0.5f, 0, 0.5f },
                3,
                new[] { new VertexAttribute("aPosition", 2) }));
        }

        public void Render()
        {
            _buffer.Bind();
            _buffer.EnableAttribute("aPosition", _shader.GetAttributeLocation("aPosition"));

            _state.ColorClearValue = new Vector4(1, 0.5f, 0, 1);
            _state.Clear(GL.ClearBufferMask.GL_COLOR_BUFFER_BIT);
            _state.DrawArrays(GL.PrimitiveType.GL_TRIANGLES, 0, 3);

            _platform.SwapBuffers();
        }
    }
}
