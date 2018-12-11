using System;
using Tgl.Net.Math;
using static Tgl.Net.GL;
using Vector4 = Tgl.Net.Math.Vector4;

namespace Tgl.Net.Core
{
    public interface IAccessor<T>
    {
        event EventHandler<T> Changed;
        void Set(T value, bool cacheOnly = false);
        T Get();
    }

    public class TglState
    {
        public TglState()
        {

            GetInteger<int>(GetPName.GL_ACTIVE_TEXTURE, out var textureUnit);
            ActiveTexture = new Accessor<uint>((uint)textureUnit - (uint)TextureUnit.GL_TEXTURE0, v => glActiveTexture((TextureUnit)((uint)TextureUnit.GL_TEXTURE0 + v)));

            GetFloat<Vector4>(GetPName.GL_COLOR_CLEAR_VALUE, out var clearColor);
            ClearColor = new Accessor<Vector4>(clearColor, v => glClearColor(v.X, v.Y, v.Z, v.W));

            GetInteger<Rectangle>(GetPName.GL_VIEWPORT, out var viewport);
            Viewport = new Accessor<Rectangle>(viewport, v => glViewport(v.X, v.Y, v.W, v.H));

            BlendingEnabled = new Accessor<bool>(glIsEnabled(EnableCap.GL_BLEND), v => SetFeature(EnableCap.GL_BLEND, v));
            FaceCullingEnabled = new Accessor<bool>(glIsEnabled(EnableCap.GL_CULL_FACE), v => SetFeature(EnableCap.GL_CULL_FACE, v));
            DepthTestEnabled = new Accessor<bool>(glIsEnabled(EnableCap.GL_DEPTH_TEST), v => SetFeature(EnableCap.GL_DEPTH_TEST, v));
            ScissorTestEnabled = new Accessor<bool>(glIsEnabled(EnableCap.GL_SCISSOR_TEST), v => SetFeature(EnableCap.GL_SCISSOR_TEST, v));
            StencilTestEnabled = new Accessor<bool>(glIsEnabled(EnableCap.GL_STENCIL_TEST), v => SetFeature(EnableCap.GL_STENCIL_TEST, v));
            Texture = new TextureAccessor(ActiveTexture, 0, v => glBindTexture(TextureTarget.GL_TEXTURE_2D, v));
            Framebuffer = new Accessor<uint>(0, v => glBindFramebuffer(FramebufferTarget.GL_FRAMEBUFFER, v));
            VertexBuffer = new Accessor<uint>(0, v => glBindBuffer(BufferTargetARB.GL_ARRAY_BUFFER, v));
            IndexBuffer = new Accessor<uint>(0, v => glBindBuffer(BufferTargetARB.GL_ELEMENT_ARRAY_BUFFER, v));
            Program = new Accessor<uint>(0, v => glUseProgram(v));
            Renderbuffer = new Accessor<uint>(0, v => glBindRenderbuffer(RenderbufferTarget.GL_RENDERBUFFER, v));
        }

        public IAccessor<uint> ActiveTexture { get; }
        public IAccessor<Vector4> ClearColor { get; }
        public IAccessor<Rectangle> Viewport { get; }
        public IAccessor<bool> BlendingEnabled { get; }
        public IAccessor<bool> FaceCullingEnabled { get; }
        public IAccessor<bool> DepthTestEnabled { get; }
        public IAccessor<bool> ScissorTestEnabled { get; }
        public IAccessor<bool> StencilTestEnabled { get; }
        public IAccessor<uint> Texture { get; }
        public IAccessor<uint> Framebuffer { get; }
        public IAccessor<uint> VertexBuffer { get; }
        public IAccessor<uint> IndexBuffer { get; }
        public IAccessor<uint> Program { get; }
        public IAccessor<uint> Renderbuffer { get; }

        private class Accessor<T> : IAccessor<T>
        {
            private T _value;
            private readonly Action<T> _setter;

            public Accessor(T initialValue, Action<T> setter)
            {
                _value = initialValue;
                _setter = setter;
            }

            public event EventHandler<T> Changed;

            public void Set(T value, bool cacheOnly = false)
            {
                if (!value.Equals(_value))
                {
                    if (!cacheOnly)
                        _setter(value);

                    _value = value;
                    Changed?.Invoke(this, _value);
                }
            }

            public T Get() => _value;
        }

        private class TextureAccessor : IAccessor<uint>
        {
            private readonly IAccessor<uint> _unitAccessor;
            private readonly Action<uint> _setter;
            private uint[] _values;

            public TextureAccessor(IAccessor<uint> unitAccessor, uint initialValue, Action<uint> setter)
            {
                GetInteger<int>(GetPName.GL_MAX_COMBINED_TEXTURE_IMAGE_UNITS, out var maxUnits);
                _values = new uint[maxUnits];

                _unitAccessor = unitAccessor;
                _values[unitAccessor.Get()] = initialValue;
                _setter = setter;
            }

            public event EventHandler<uint> Changed;

            public uint Get() => _values[_unitAccessor.Get()];

            public void Set(uint value, bool cacheOnly = false)
            {
                var active = _unitAccessor.Get();

                if (!value.Equals(_values[active]))
                {
                    if (!cacheOnly)
                        _setter(value);

                    _values[active] = value;
                    Changed?.Invoke(this, value);
                }
            }
        }
    }
}
