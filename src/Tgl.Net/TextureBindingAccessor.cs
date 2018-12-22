using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Tgl.Net.Core;

namespace Tgl.Net
{
    public class TextureBindingAccessor : IEnumerable<uint>
    {
        private readonly uint _maxCombinedTextureUnits;

        public TextureBindingAccessor(uint maxCombinedTextureUnits)
        {
            _maxCombinedTextureUnits = maxCombinedTextureUnits;
        }

        public uint this[GL.TextureUnit index]
        {
            get
            {
                GL.glActiveTexture(index);
                return GL.GetInteger<uint>(GL.GetPName.GL_TEXTURE_BINDING_2D);
            }
            set
            {
                GL.glActiveTexture(index);
                GL.glBindTexture(GL.TextureTarget.GL_TEXTURE_2D, value);
            }
        }

        public IEnumerator<uint> GetEnumerator() => new TextureBindingEnumerator(this);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private class TextureBindingEnumerator : IEnumerator<uint>
        {
            private readonly TextureBindingAccessor _accessor;
            private readonly uint _max;

            private int _position = (int)GL.TextureUnit.GL_TEXTURE0 - 1;

            internal TextureBindingEnumerator(TextureBindingAccessor accessor)
            {
                _accessor = accessor;
                _max = _accessor._maxCombinedTextureUnits + (uint)GL.TextureUnit.GL_TEXTURE0;
            }

            public uint Current => _accessor[(GL.TextureUnit)_position];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                Console.WriteLine(_position +";"+ _max);
                return ++_position < _max;
            }

            public void Reset() => _position = (int)GL.TextureUnit.GL_TEXTURE0 - 1;
        }
    }
}
