using System;
using System.Collections.Generic;
using System.Text;
using Game.Abstractions;
using Tgl.Net;

namespace Renderer.Gles2.Tests
{
    public interface IRenderTest
    {
        void Init(GlState state, GlContext context);
        void Render(GlState state, GlContext context);
    }
}
