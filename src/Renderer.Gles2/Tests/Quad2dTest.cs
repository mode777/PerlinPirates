using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using Game.Abstractions;
using Tgl.Net;
using Tgl.Net.Bindings;
using Tgl.Net.Helpers;
using Tgl.Net.Math;

namespace Renderer.Gles2.Tests
{
    public class Quad2dTest : IRenderTest
    {
        private Transform2d _transform;
        private Sprite sprite;
        private QuadBuffer2D _buffer;
        private Texture _texture;

        public void Init(GlContext context, ResourceManager resources)
        {
            //var shader = resources.LoadResource<Shader>("Resources.Shaders.quad2d");
            var shader = new Shader2d(context, resources);
            
            _texture = resources.LoadResource<Texture>("Resources/Textures/grid.png");

            _buffer = new QuadBuffer2D(context, shader, _texture, 2);

            sprite = new Sprite(_texture, 
                RectangleF.FromLTRB(0,0,128,128),
                new Transform2d
                {
                    OriginX = 64,
                    OriginY = 64,
                    Rotation = 1,
                    X = 200,
                    Y = 200,
                    ScaleX = 0.7f
                });

            _buffer.SetQuad(1, 0,0,128,128,128,128);
        }

        public void Render(GlContext context)
        {
            sprite.Transform.Rotation += 0.01f;
            _buffer.SetQuad(0, ref sprite.BaseQuad2D, sprite.Transform);

            _buffer.Update();

            context.State.ColorClearValue = new Vector4(0,1,0,1);

            context.Clear(ClearBufferMask.GL_COLOR_BUFFER_BIT);

            _buffer.Render();
        }
    }
}
