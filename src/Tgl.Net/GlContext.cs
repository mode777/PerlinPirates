using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tgl.Net.Bindings;

namespace Tgl.Net
{
    public class GlContext
    {
        public GlContext(IGlState state)
        {
            State = state;
        }

        public GlContext()
            : this(new GlStateCache())
        {
        }
        public IGlState State { get; }

        public virtual void Clear(GL.ClearBufferMask mask)
        {
            GL.glClear(mask);
        }

        public virtual void DrawArrays(GL.PrimitiveType type, int first, int count)
        {
            GL.glDrawArrays(type, first, count);
        }

        public virtual void DrawElements(GL.PrimitiveType type, int first, int count)
        {
            GL.glDrawElements(type, count, GL.DrawElementsType.GL_UNSIGNED_SHORT, first);
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

            var unit = GL.TextureUnit.GL_TEXTURE0;
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

            DrawElements(GL.PrimitiveType.GL_TRIANGLES,
                0,
                length);
        }
    }
}
