using System;
using System.Collections.Generic;
using System.Text;
using Game.Abstractions;
using Tgl.Net;
using Tgl.Net.Math;

namespace Renderer.Gles2
{
    public class Gles2Renderer : IRenderer
    {
        private readonly IPlatform _platform;

        public Gles2Renderer(IPlatform platform)
        {
            _platform = platform;
            GL.LoadApi(platform.GetGlProcAddress);
        }

        public void Render()
        {
            GL.glClearColor(1, 1, 0, 1);
            GL.glClear(GL.ClearBufferMask.GL_COLOR_BUFFER_BIT);

            GL.glGetInteger<Vertex4i>(GL.GetPName.GL_VIEWPORT, out var i);

            _platform.SwapBuffers();
        }
    }
}
