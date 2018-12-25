using System;
using System.Collections.Generic;
using System.Text;
using Game.Abstractions;
using Tgl.Net.State;

namespace Renderer.Gles2.Tests
{
    public interface IRenderTest
    {
        void Init(GlState state);
        void Render(GlState state);
    }
}
