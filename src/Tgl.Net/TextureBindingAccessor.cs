using System;
using System.Collections;
using System.Collections.Generic;
using Tgl.Net.Bindings;

namespace Tgl.Net
{
    public class TextureBindingAccessor : IEnumerable<uint>
    {
        private readonly uint _maxCombinedTextureUnits;

        public TextureBindingAccessor(uint maxCombinedTextureUnits)
        {
            _maxCombinedTextureUnits = maxCombinedTextureUnits;
        }

        public uint this[TextureUnit index]
        {
            get
            {
                var prev = GL.GetInteger<TextureUnit>(GetPName.GL_ACTIVE_TEXTURE);

                try
                {
                    GL.glActiveTexture(index);
                    return GL.GetInteger<uint>(GetPName.GL_TEXTURE_BINDING_2D);
                }
                finally
                {
                    GL.glActiveTexture(prev);
                }
            }
            set
            {
                var prev = GL.GetInteger<TextureUnit>(GetPName.GL_ACTIVE_TEXTURE);

                try
                {
                    GL.glActiveTexture(index);
                    GL.glBindTexture(TextureTarget.GL_TEXTURE_2D, value);
                }
                finally
                {
                    GL.glActiveTexture(prev);
                }
            }
        }

        public IEnumerator<uint> GetEnumerator() => new TextureBindingEnumerator(this);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private class TextureBindingEnumerator : IEnumerator<uint>
        {
            private readonly TextureBindingAccessor _accessor;
            private readonly uint _max;

            private int _position = (int)TextureUnit.GL_TEXTURE0 - 1;

            internal TextureBindingEnumerator(TextureBindingAccessor accessor)
            {
                _accessor = accessor;
                _max = _accessor._maxCombinedTextureUnits + (uint)TextureUnit.GL_TEXTURE0;
            }

            public uint Current => _accessor[(TextureUnit)_position];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                return ++_position < _max;
            }

            public void Reset() => _position = (int)TextureUnit.GL_TEXTURE0 - 1;
        }
    }
}
