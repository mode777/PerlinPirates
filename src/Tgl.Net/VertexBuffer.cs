using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Tgl.Net.Bindings;
using Tgl.Net.Helpers;

namespace Tgl.Net
{
    public class VertexBuffer
    {
        private readonly IGlState _state;
        private VertexAttribute[] _attributes;
        private Dictionary<string, VertexAttribute> _attributesByName;
        private GL.BufferUsageARB _usage;
        private int _byteSize;
        private int _vertexSize;
        private int _vertices;

        public VertexBuffer(IGlState state)
        {
            _state = state;

            unsafe
            {
                var handle = Handle;
                GL.glGenTextures(1, &handle);
                Handle = handle;
            }
        }

        public int VertexCount => _vertices;
        public int VertexSize => _vertexSize;
        public int Size => _byteSize;
        public IEnumerable<VertexAttribute> Attributes => _attributes;

        public uint Handle { get; }

        public void Bind()
        {
            _state.ArrayBufferBinding = Handle;
        }
        
        public void DefineAttributes(IEnumerable<VertexAttribute> attributes)
        {
            _attributes = attributes.ToArray();
            _attributesByName = new Dictionary<string, VertexAttribute>();

            foreach (var vertexAttribute in _attributes)
            {
                _attributesByName[vertexAttribute.Name] = vertexAttribute;
            }
        }

        // TODO: Check if recalculation of attributes is needed
        //private void SubData(object data, uint vertexOffset, uint vertexLength)
        //{
        //    Bind();

        //    var handle = GCHandle.Alloc(data);
        //    GL.glBufferSubData(GL.BufferTargetARB.GL_ARRAY_BUFFER, (IntPtr)(_vertexSize * vertexOffset), (uint)_vertexSize * vertexLength, GCHandle.ToIntPtr(handle));
        //    handle.Free();
        //}
        
        public void Data<T>(T[] data, GL.BufferUsageARB usage = GL.BufferUsageARB.GL_STATIC_DRAW)
            where T : struct
        {
            _usage = usage;

            _vertexSize = _attributes.Sum(x => x.AttributeSize);
            _byteSize = data.Length * Marshal.SizeOf<T>();
            _vertices = _byteSize / _vertexSize;

            Bind();
            using (var handle = new PinnedGCHandle(data))
            {
                GL.glBufferData(GL.BufferTargetARB.GL_ARRAY_BUFFER, 
                    (uint)_byteSize, 
                    handle.Pointer, 
                    _usage);
            }
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
    }

}
