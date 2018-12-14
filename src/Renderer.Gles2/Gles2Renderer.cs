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
        private readonly TglContext _context;

        private VertexBuffer buffer;
        private Shader shader;

        public Gles2Renderer(IPlatform platform)
        {
            _platform = platform;
            platform.CreateGlContext();
            _context = new TglContext(platform.GetGlProcAddress);

            Init();
        }

        public void Init()
        {
            var vertex1 = @"attribute vec2 aPosition;

            void main(void)
            {
                gl_Position = vec4(aPosition, 1.0, 1.0);
            }";

            var fragment1 = @"precision mediump float;

            void main(void)
            {
                gl_FragColor = vec4(1, 1, 1, 1);
            }";

            shader = new Shader(_context, new ShaderOptions(vertex1, fragment1));

            buffer = new VertexBuffer(_context, new BufferOptions(
                new float[] { -0.5f, -0.5f, 0.5f, -0.5f, 0, 0.5f },
                3,
                new[] { new VertexAttribute("aPosition", 2) }));
        }

        public void Render()
        {
            buffer.Bind();
            buffer.EnableAttribute("aPosition", shader.GetAttributeLocation("aPosition"));

            _context.Clear(GL.ClearBufferMask.GL_COLOR_BUFFER_BIT,
                new Vector4(1, 0.5f, 0, 1));

            GL.glDrawArrays(GL.PrimitiveType.GL_TRIANGLES, 0, 3);

            _platform.SwapBuffers();
        }
    }
}
