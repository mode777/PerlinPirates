using System;
using System.Collections.Generic;
using System.Text;
using Game.Abstractions;
using Tgl.Net;

namespace Renderer.Gles2.Tests
{
    public interface IRenderTest
    {
        void Init(GlContext context, ResourceManager manager);
        void Render(GlContext context);
    }
}
