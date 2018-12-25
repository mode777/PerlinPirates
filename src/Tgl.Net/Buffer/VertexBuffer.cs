using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Tgl.Net.Bindings;
using Tgl.Net.State;

namespace Tgl.Net.Buffer
{
    public class VertexBuffer
    {
        private readonly IGlState _state;
        private readonly VertexAttribute[] _attributes;
        private readonly Dictionary<string, VertexAttribute> _attributesByName = new Dictionary<string, VertexAttribute>();
        private readonly GL.BufferUsageARB _usage;
        private readonly uint _handle;
        private int _byteSize;
        private int _vertexSize;
        private int _vertices;

        public VertexBuffer(IGlState state, BufferBuilder options)
        {
            _state = state;
            _usage = options.Usage;
            
            _attributes = options.Attributes.ToArray();
            foreach (var vertexAttribute in _attributes)
            {
                _attributesByName[vertexAttribute.Name] = vertexAttribute;
            }

            unsafe
            {
                var arr = new uint[1];

                fixed (uint* ptr = arr)
                {
                    GL.glGenBuffers(arr.Length, ptr);
                    _handle = arr[0];
                }
            }

            Data(options.Data, options.Vertices);
        }

        public int VertexCount => _vertices;
        public int VertexSize => _vertexSize;
        public int Size => _byteSize;

        public void Bind()
        {
            _state.ArrayBufferBinding = _handle;
        }

        private void SubData(object data, uint vertexOffset, uint vertexLength)
        {
            Bind();

            var handle = GCHandle.Alloc(data);
            GL.glBufferSubData(GL.BufferTargetARB.GL_ARRAY_BUFFER, (IntPtr)(_vertexSize * vertexOffset), (uint)_vertexSize * vertexLength, GCHandle.ToIntPtr(handle));
            handle.Free();
        }

        public void Data(object data, int vertexLength)
        {
            Bind();
            CalculateSize(vertexLength);

            var handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            GL.glBufferData(GL.BufferTargetARB.GL_ARRAY_BUFFER, (uint)_byteSize, handle.AddrOfPinnedObject(), _usage);
            handle.Free();
        }

        public void EnableAttribute(string name, int location)
        {
            Bind();
            var a = _attributesByName[name];

            GL.glEnableVertexAttribArray((uint)location);
            GL.glVertexAttribPointer(
                (uint)location,
                (int)a.Components,
                a.DataType,
                a.Normalized,
                (int)_vertexSize,
                (IntPtr)a.Offset);
        }
        
        private void CalculateSize(int vertices)
        {
            _vertices = vertices;
            _vertexSize = _attributes.Sum(x => x.AttributeSize);
            _byteSize = _vertexSize * _vertices;
        }
    }

}
