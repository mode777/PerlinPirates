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

        private GlStateCache _state;
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
            _state = new GlStateCache();

            _state.PropertyChanged += (s, args) => Console.WriteLine(args.PropertyName);

            _shader = _state.BuildShader()
                .WithVertexResource("Resources.Shaders.minimal_vertex.glsl")
                .WithFragmentResource("Resources.Shaders.minimal_fragment.glsl")
                .Build();

            _buffer = _state.BuildBuffer()
                .WithData(3, -0.5f, -0.5f, 0.5f, -0.5f, 0, 0.5f)
                .HasAttribute("aPosition", 2)
                .Build();
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
