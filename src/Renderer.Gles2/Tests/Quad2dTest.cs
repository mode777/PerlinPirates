﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Abstractions;
using Tgl.Net;
using Tgl.Net.Abstractions;
using Tgl.Net.Bindings;
using Tgl.Net.Helpers;
using Tgl.Net.Math;

namespace Renderer.Gles2.Tests
{
    public class Quad2dTest : IRenderTest
    {
        private IDrawable _drawable;
        private Transform2d _transform;
        private Quad quad1;
        private Quad[] quads;
        
        public void Init(GlContext context, ResourceManager resources)
        {
            var shader = resources.LoadResource<Shader>("Resources.Shaders.quad2d");
            var image = resources.LoadResource<IImage>("Resources.Textures.grid.png");
            var viewport = context.State.Viewport;

            var matrix = new Matrix3();
            matrix.Identity();
            matrix.Translate(-1,1);
            matrix.Scale(2.0f / viewport.Z, -2.0f /  viewport.W);

            var uv_matrix = new Matrix3();
            uv_matrix.Identity();
            uv_matrix.Scale(1.0f / image.Width, 1.0f / image.Height);

            quad1 = Quad.FromDimensions(0, 0, 128, 128);

            quads = new Quad[]
            {
                quad1,
                Quad.FromDimensions(0, 0, 128, 128, 128, 128)
            };

            _transform = new Transform2d
            {
                OriginX = 64,
                OriginY = 64,
                Rotation = 1,
                X = 200,
                Y = 200,
                ScaleX = 0.7f
            };
            _transform.UpdateMatrix();

            quads[0].Transform(ref _transform.Matrix);

           _drawable = context.BuildDrawable()
                .UseShader(shader)
                .AddUniform("uProject", matrix)
                .AddUniform("uProject_uv", uv_matrix)
                .AddBuffer<Quad>(b => b
                    .HasAttribute("aPosition", 2)
                    .HasAttribute("aTexcoord", 2)
                    .HasData(quads))
                .AddTexture("uTexture", image)
                .UseIndices(CreateQuadIndices(quads.Length))
                .Build();
        }

        private ushort[] CreateQuadIndices(int length)
        {
            var indices = new List<ushort>(length);

            for (int i = 0; i < length; i++)
            {
                var offset = i * 4;

                indices.Add((ushort)(offset + 3));
                indices.Add((ushort)(offset + 0));
                indices.Add((ushort)(offset + 1));
                indices.Add((ushort)(offset + 3));
                indices.Add((ushort)(offset + 1));
                indices.Add((ushort)(offset + 2));
            }

            return indices.ToArray();
        }

        public void Render(GlContext context)
        {
            _transform.Rotation += 0.01f;
            _transform.UpdateMatrix();
            quads[0] = quad1;
            quads[0].Transform(ref _transform.Matrix);
            
            var buffer = _drawable.Buffers.First();

            buffer.SubData(quads, 0, (uint) buffer.VertexCount);

            context.State.ColorClearValue = new Vector4(0,1,0,1);

            context.Clear(ClearBufferMask.GL_COLOR_BUFFER_BIT);

            context.DrawDrawable(_drawable);
        }
    }
}
