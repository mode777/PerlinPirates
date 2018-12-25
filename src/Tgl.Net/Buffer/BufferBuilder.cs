using System;
using System.Collections.Generic;
using System.Linq;
using Tgl.Net.Bindings;
using Tgl.Net.State;

namespace Tgl.Net.Buffer
{
    public class BufferBuilder
    {
        private readonly IGlState _state;
        private List<VertexAttribute> _attributes;

        public object Data { get; private set; }
        public int Vertices { get; private set; }

        public IEnumerable<VertexAttribute> Attributes
        {
            get => _attributes;
        }
        public GL.BufferUsageARB Usage { get; private set; } = GL.BufferUsageARB.GL_STATIC_DRAW;


        public BufferBuilder(IGlState state)
        {
            this._state = state;
            _attributes = new List<VertexAttribute>();
        }

        public BufferBuilder HasData(int vertices, params float[] values)
        {
            return HasData(vertices, (object)values);
        }

        public BufferBuilder HasData(int vertices, object data)
        {
            Data = data;
            Vertices = vertices;

            return this;
        }

        public BufferBuilder HasAttribute(string attribute, int components, GL.VertexAttribPointerType type = GL.VertexAttribPointerType.GL_FLOAT)
        {
            _attributes.Add(new VertexAttribute(attribute, components));

            return this;
        }

        public BufferBuilder HasAttribute(VertexAttribute attribute)
        {
            if (attribute.Order == -1)
                attribute.Order = _attributes.Count;

            _attributes.Add(attribute);

            return this;
        }

        public BufferBuilder HasAttribute(Action<VertexAttribute> config)
        {
            var attr = new VertexAttribute();
            config(attr);
            return HasAttribute(attr);
        }

        public VertexBuffer Build()
        {
            _attributes = CalculateAttributeOffsets();
            return new VertexBuffer(this._state, this);
        }

        private List<VertexAttribute> CalculateAttributeOffsets()
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
}