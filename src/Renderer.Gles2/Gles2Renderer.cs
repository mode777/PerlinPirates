using System;
using System.Collections.Generic;
using System.Text;
using Game.Abstractions;
using GlMatrix.Net;
using Tgl.Net;

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
            GL.glClearColor(0.5f, 1, 0, 1);
            GL.glClear(GL.ClearBufferMask.GL_COLOR_BUFFER_BIT);

            //GL.GetInteger<Vertex4i>(GL.GetPName.GL_VIEWPORT, out var i);
            GL.GetFloat<Vector4>(GL.GetPName.GL_COLOR_CLEAR_VALUE, out var color);

            Vector4.Add(ref color, ref color, ref color);
            
            _platform.SwapBuffers();
        }
    }
}
