using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Tgl.Net;

namespace Renderer.Gles2
{
    public class SpriteBatch
    {
        private readonly Texture[] _textures;
        private readonly Sprite[] _sprites;
        private readonly Stack<int> _freeList;

        public SpriteBatch(IGlState state, int size)
        {
            _textures = new Texture[size];
            _sprites = new Sprite[size];
            Buffer = new BufferBuilder<Sprite>(state)
                .HasAttribute("aPosition", 2)
                .HasAttribute("aTexcoord", 2)
                .HasData(_sprites)
                .Build();
        }

        internal VertexBuffer Buffer { get; }
        public int Size { get; private set; }

        public void Clear()
        {
            Size = 0;
        }

        public void Push(ref Sprite sprite, Texture texture)
        {
            _sprites[Size] = sprite;
            _textures[Size] = texture;

            Size++;
        }
        
        public void Update()
        {
            Buffer.SubData(_sprites, 0, (uint)Size);
        }

        public IEnumerable<(int, int, Texture)> EnumerateSlices()
        {
            var lower = 0;
            var lowerTexture = _textures[lower];

            for (int i = 0; i < Size; i++)
            {
                if(lowerTexture == _textures[i])
                    continue;

                yield return (lower, i - 1, lowerTexture);

                lower = i;
                lowerTexture = _textures[i];
            }
        }
    }
}
