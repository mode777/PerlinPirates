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
        
        public SpriteBatch(IGlState state, int size)
        {
            _textures = new Texture[size];
            _sprites = new Sprite[size];
            Buffer = new BufferBuilder<Sprite>(state)
                .HasAttribute("aPosition", 2)
                .HasAttribute("aTexcoord", 2)
                .HasData(_sprites)
                .Build();
            Indices = CreateIndexBuffer(state);
        }

        internal VertexBuffer Buffer { get; }
        internal IndexBuffer Indices { get; }

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

        public void Push(Texture texture, float x, float y)
        {
            _sprites[Size].SetTexture(texture, x, y);
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

        private IndexBuffer CreateIndexBuffer(IGlState state)
        {
            var indexData = new ushort[6 * _sprites.Length];

            int vertex = 0;

            for (var i = 0; i < indexData.Length; i += 6)
            {
                indexData[i] =     (ushort)(vertex + 0);
                indexData[i + 1] = (ushort)(vertex + 1);
                indexData[i + 2] = (ushort)(vertex + 2);

                indexData[i + 3] = (ushort)(vertex + 0);
                indexData[i + 4] = (ushort)(vertex + 3);
                indexData[i + 5] = (ushort)(vertex + 1);

                vertex += 4;
            }

            return new IndexBuffer(state, indexData);
        }
    }
}
