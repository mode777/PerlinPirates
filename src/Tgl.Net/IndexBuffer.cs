using System.Runtime.InteropServices;
using Tgl.Net.Bindings;

namespace Tgl.Net
{
    public class IndexBuffer
    {
        private readonly IGlState _state;

        internal IndexBuffer(IGlState state, ushort[] data)
        {
            _state = state;

            unsafe
            {
                var handle = Handle;
                GL.glGenBuffers(1, &handle);
                Handle = handle;

                Bind();

                var pinned = GCHandle.Alloc(data, GCHandleType.Pinned);
                GL.glBufferData(GL.BufferTargetARB.GL_ELEMENT_ARRAY_BUFFER,
                    (uint)data.Length * sizeof(ushort),
                    pinned.AddrOfPinnedObject(),
                    GL.BufferUsageARB.GL_STATIC_DRAW);
                pinned.Free();
            }

            Length = data.Length;
        }

        public uint Handle { get; private set; }
        public int Length { get; }

        public void Bind()
        {
            _state.ElementArrayBufferBinding = Handle;
        }
    }
}
