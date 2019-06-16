using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Tgl.Net.Bindings;

namespace Tgl.Net
{
    public class GlContext
    {
        public GlContext(Func<string, IntPtr> apiLoader)
        {
            GL.LoadApi(apiLoader);
            Info = new GlInfo();
            State = new GlStateCache(Info);
        }

        public GlInfo Info { get; }

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

            foreach (var pair in drawable.FloatUniforms)
            {
                drawable.Shader.SetUniform(pair.Key, pair.Value);
            }

            foreach (var pair in drawable.Vector2Uniforms)
            {
                drawable.Shader.SetUniform(pair.Key, pair.Value.X, pair.Value.Y);
            }

            foreach (var pair in drawable.Vector3Uniforms)
            {
                drawable.Shader.SetUniform(pair.Key, pair.Value);
            }

            foreach (var pair in drawable.Vector4Uniforms)
            {
                drawable.Shader.SetUniform(pair.Key, pair.Value);
            }

            foreach (var pair in drawable.Matrix2Uniforms)
            {
                drawable.Shader.SetUniform(pair.Key, pair.Value);
            }

            foreach (var pair in drawable.Matrix3Uniforms)
            {
                drawable.Shader.SetUniform(pair.Key, pair.Value);
            }

            foreach (var pair in drawable.Matrix4Uniforms)
            {
                drawable.Shader.SetUniform(pair.Key, pair.Value);
            }

            var unit = TextureUnit.GL_TEXTURE0;
            foreach (var pair in drawable.Textures)
            {
                State.ActiveTexture = unit;
                State.TextureBinding2D = pair.Value.Handle;
                drawable.Shader.SetUniform(drawable.Shader.GetUniformLocation(pair.Key), unit);

                unit++;
            }


            if(drawable.IndexBuffer != null){
                State.ElementArrayBufferBinding = drawable.IndexBuffer.Handle;
                DrawElements(PrimitiveType.GL_TRIANGLES,
                    0,
                    drawable.IndexBuffer.Length);
            }
            else {
                DrawArrays(PrimitiveType.GL_TRIANGLES, 0, drawable.Buffers.First().VertexCount);
            }            
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

        public Texture TextureFromPixels(byte[] data, int width, int height, ImagePixelFormat format)
        {
            return new TextureBuilder<byte>(State)
                .HasSize(width, height)
                .HasData(data)
                .Build();
        }
    }
}
