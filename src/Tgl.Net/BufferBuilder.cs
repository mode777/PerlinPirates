using System;
using System.Collections.Generic;
using System.Linq;
using Tgl.Net.Bindings;

namespace Tgl.Net
{
    public abstract class BufferBuilder
    {
        protected readonly IGlState _state;
        protected List<VertexAttribute> _attributes;

        public IEnumerable<VertexAttribute> Attributes => _attributes;

        public BufferUsageARB Usage { get; private set; } = BufferUsageARB.GL_STATIC_DRAW;
        
        public BufferBuilder(IGlState state)
        {
            _state = state;
            _attributes = new List<VertexAttribute>();
        }

        protected List<VertexAttribute> CalculateAttributeOffsets()
        {
            int offset = 0;

            return _attributes
                .OrderBy(x => x.Order)
                .Select(x =>
                {
                    var res = new VertexAttribute
                    {
                        Name = x.Name,
                        Components = x.Components,
                        Normalized = x.Normalized,
                        Offset = x.Offset != -1 ? x.Offset : offset
                    };

                    offset += res.AttributeSize;

                    return res;
                }).ToList();
        }

    }

    public class BufferBuilder<T> : BufferBuilder
        where T : struct
    {
        public BufferBuilder(IGlState state) 
            : base(state)
        {
        }

        public T[] Data { get; private set; }

        public BufferBuilder<T> HasData(params T[] values)
        {
            Data = values;
            return this;
        }

        public BufferBuilder<T> HasAttribute(string attribute, int components, VertexAttribPointerType type = VertexAttribPointerType.GL_FLOAT)
        {
            _attributes.Add(new VertexAttribute(attribute, components));

            return this;
        }

        public BufferBuilder<T> HasAttribute(VertexAttribute attribute)
        {
            if (attribute.Order == -1)
                attribute.Order = _attributes.Count;

            _attributes.Add(attribute);

            return this;
        }

        public BufferBuilder<T> HasAttribute(Action<VertexAttribute> config)
        {
            var attr = new VertexAttribute();
            config(attr);
            return HasAttribute(attr);
        }

        public VertexBuffer Build()
        {
            var buffer = new VertexBuffer(_state);

            _attributes = CalculateAttributeOffsets();
            buffer.DefineAttributes(_attributes);

            if (Data != null)
            {
                buffer.Data(Data, Usage);
            }

            return buffer;
        }
    }
}