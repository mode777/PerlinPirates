﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Tgl.Net.Abstractions;
using Tgl.Net.Bindings;
using Tgl.Net.Helpers;
using ImagePixelFormat = Tgl.Net.Abstractions.ImagePixelFormat;

namespace Tgl.Net
{
    public class GlContext
    {
        public GlContext(Func<string, IntPtr> apiLoader)
        {
            GL.LoadApi(apiLoader);

            State = new GlStateCache();
        }

        public GlStateCache State { get; }

        public virtual void Clear(ClearBufferMask mask)
        {
            GL.glClear(mask);
        }

        public virtual void DrawArrays(PrimitiveType type, int first, int count)
        {
            GL.glDrawArrays(type, first, count);
        }

        public virtual void DrawElements(PrimitiveType type, int first, int count)
        {
            GL.glDrawElements(type, count, DrawElementsType.GL_UNSIGNED_SHORT, first);
        }

        public virtual void DrawDrawable(IDrawable drawable)
        {
            foreach (var buffer in drawable.Buffers)
            {
                foreach (var attribute in buffer.Attributes)
                {
                    buffer.EnableAttribute(attribute.Name,
                        drawable.Shader.GetAttributeLocation(attribute.Name));
                }
            }

            foreach (var pair in drawable.UniformSetters)
            {
                pair.Value(drawable.Shader);
            }

            var unit = TextureUnit.GL_TEXTURE0;
            foreach (var pair in drawable.Textures)
            {
                State.ActiveTexture = unit;
                State.TextureBinding2D = pair.Value.Handle;
                drawable.Shader.SetUniform(drawable.Shader.GetUniformLocation(pair.Key), unit);

                unit++;
            }

            State.ElementArrayBufferBinding = drawable.IndexBuffer.Handle;

            var length = drawable.IndexBuffer == null
                ? drawable.Buffers.First().VertexCount
                : drawable.IndexBuffer.Length;

            DrawElements(PrimitiveType.GL_TRIANGLES,
                0,
                length);
        }

        public ShaderBuilder BuildShader()
        {
            return new ShaderBuilder(State);
        }

        public TextureBuilder<T> BuildTexture<T>()
            where T : struct
        {
            return new TextureBuilder<T>(State);
        }

        public BufferBuilder<T> BuildBuffer<T>()
            where T : struct
        {
            return new BufferBuilder<T>(State);
        }

        public DrawableBuilder BuildDrawable()
        {
            return new DrawableBuilder(this);
        }

        public IndexBuffer CreateIndexBuffer(params ushort[] indices)
        {
            return new IndexBuffer(State, indices);
        }

        public Texture TextureFromImage(IImage image)
        {
            return new TextureBuilder<byte>(State)
                .HasSize(image.Width, image.Height)
                .HasData(image.Data)
                .Build();
        }
    }
}
