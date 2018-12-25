using System;
using System.Collections.Generic;
using System.Text;
using Game.Abstractions;
using Renderer.Gles2.Tests;
using Tgl.Net;
using Tgl.Net.Bindings;
using Tgl.Net.Buffer;
using Tgl.Net.Math;
using Tgl.Net.Shader;
using Tgl.Net.State;

namespace Renderer.Gles2
{
    public class Gles2Renderer : IRenderer
    {
        private readonly IPlatform _platform;
        private readonly IRenderTest _test;

        private GlStateCache _state;
        
        public Gles2Renderer(IPlatform platform)
        {
            _platform = platform;
            platform.CreateGlContext();
            GL.LoadApi(platform.GetGlProcAddress);

            //_test = new SimpleTriangle();            
            _test = new TextureChecker();            

            Init();
        }

        public void Init()
        {
            _state = new GlStateCache();

            _state.PropertyChanged += (s, args) => Console.WriteLine(args.PropertyName);

            _test.Init(_state);
        }

        public void Render()
        {
            _test.Render(_state);

            _platform.SwapBuffers();
        }
    }
}
