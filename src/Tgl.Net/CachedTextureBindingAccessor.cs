using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tgl.Net.Bindings;

namespace Tgl.Net
{
    public class CachedTextureBindingAccessor : IEnumerable<uint>
    {
        private readonly uint[] _bindings;

        public CachedTextureBindingAccessor(TextureBindingAccessor accessor)
        {
            _bindings = accessor.ToArray();
        }

        public uint this[GL.TextureUnit index]
        {
            get => _bindings[index - GL.TextureUnit.GL_TEXTURE0];
            set => _bindings[index - GL.TextureUnit.GL_TEXTURE0] = value;
        }

        public IEnumerator<uint> GetEnumerator()
        {
            return (IEnumerator<uint>)_bindings.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _bindings.GetEnumerator();
        }
    }
}
