using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using static Tgl.Net.GL;

namespace Tgl.Net.Core
{
    public class VertexBuffer
    {
        private readonly IGlState _state;
        private readonly VertexAttribute[] _attributes;
        private readonly Dictionary<string, VertexAttribute> _attributesByName = new Dictionary<string, VertexAttribute>();
        private readonly BufferUsageARB _usage;
        private readonly uint _handle;
        private uint _byteSize;
        private uint _vertexSize;
        private uint _vertices;

        public VertexBuffer(IGlState state, BufferOptions options)
        {
            _state = state;
            _usage = options.Usage;

            uint offset = 0;

            _attributes = options.Attributes.Select(x =>
            {
                var res = new VertexAttribute(x.Name, x.Components)
                {
                    Normalized = x.Normalized,
                    Offset = x.Offset.HasValue ? x.Offset : offset
                };

                offset += GetComponentSize(x.DataType) * x.Components;

                _attributesByName[res.Name] = res;
                return res;
            }).ToArray();

            unsafe
            {
                var arr = new uint[1];

                fixed (uint* ptr = arr)
                {
                    glGenBuffers(arr.Length, ptr);
                    _handle = arr[0];
                }
            }

            Data(options.Data, options.Vertices);
        }

        public uint VertexCount => _vertices;
        public uint VertexSize => _vertexSize;
        public uint Size => _byteSize;

        public void Bind()
        {
            _state.ArrayBufferBinding = _handle;
        }

        private void SubData(object data, uint vertexOffset, uint vertexLength)
        {
            Bind();

            var handle = GCHandle.Alloc(data);
            glBufferSubData(BufferTargetARB.GL_ARRAY_BUFFER, (IntPtr)(_vertexSize * vertexOffset), _vertexSize * vertexLength, GCHandle.ToIntPtr(handle));
            handle.Free();
        }

        public void Data(object data, uint vertexLength)
        {
            Bind();
            CalculateSize(vertexLength);

            var handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            glBufferData(BufferTargetARB.GL_ARRAY_BUFFER, _byteSize, handle.AddrOfPinnedObject(), _usage);
            handle.Free();
        }

        public void EnableAttribute(string name, int location)
        {
            Bind();
            var a = _attributesByName[name];

            glEnableVertexAttribArray((uint)location);
            glVertexAttribPointer(
                (uint)location,
                (int)a.Components,
                a.DataType,
                a.Normalized,
                (int)_vertexSize,
                (IntPtr)a.Offset);
        }

        private uint GetComponentSize(VertexAttribPointerType type)
        {
            switch (type)
            {
                case VertexAttribPointerType.GL_BYTE:
                case VertexAttribPointerType.GL_UNSIGNED_BYTE:
                    return 1;
                case VertexAttribPointerType.GL_SHORT:
                case VertexAttribPointerType.GL_UNSIGNED_SHORT:
                    return 2;
                case VertexAttribPointerType.GL_INT:
                case VertexAttribPointerType.GL_UNSIGNED_INT:
                case VertexAttribPointerType.GL_FLOAT:
                    return 4;
                default:
                    throw new NotSupportedException($"DataType {type} is not supported.");
            }
        }

        private void CalculateSize(uint vertices)
        {
            _vertices = vertices;
            _vertexSize = (uint)_attributes.Sum(x => GetComponentSize(x.DataType) * x.Components);
            _byteSize = _vertexSize * _vertices;
        }
    }

}
