using System;
using System.IO;
using Tgl.Net.Bindings;
using PixelFormat = Tgl.Net.Bindings.PixelFormat;

namespace Tgl.Net
{
    public class TextureBuilder<T>
        where T : struct
    {
        private readonly IGlState _state;

        public T[] Data { get; private set; } = null;
        public int Width { get; private set; } = 1;
        public int Height { get; private set; } = 1;
        public PixelFormat PixelFormat { get; private set; } = PixelFormat.GL_RGBA;
        public InternalFormat InternalFormat { get; private set; } = InternalFormat.GL_RGBA;
        public PixelType PixelType { get; private set; } = PixelType.GL_UNSIGNED_BYTE;
        public TextureMagType FilterMagnify { get; private set; } = TextureMagType.GL_LINEAR;
        public TextureMinType FilterMinify { get; private set; } = TextureMinType.GL_LINEAR;
        public TextureWrapMode WrapX { get; private set; } = TextureWrapMode.GL_REPEAT;
        public TextureWrapMode WrapY { get; private set; } = TextureWrapMode.GL_REPEAT;
        public bool GenerateMipmaps { get; private set; } = false;

        public TextureBuilder(IGlState state)
        {
            _state = state;
        }

        public TextureBuilder<T> HasData(params T[] data)
        {
            Data = data;

            return this;
        }

        public TextureBuilder<T> HasPixelFormat(PixelFormat format)
        {
            PixelFormat = format;

            return this;
        }

        public TextureBuilder<T> HasPixelType(PixelType type)
        {
            PixelType = type;

            return this;
        }

        public TextureBuilder<T> HasInternalFormat(InternalFormat internalFormat)
        {
            InternalFormat = internalFormat;

            return this;
        }

        public TextureBuilder<T> HasSize(int width, int height)
        {
            Width = width;
            Height = height;

            return this;
        }

        public TextureBuilder<T> HasFiltering(TextureMinType minify, TextureMagType magnify)
        {
            FilterMinify = minify;
            FilterMagnify = magnify;

            return this;
        }

        public TextureBuilder<T> HasWrapping(TextureWrapMode x, TextureWrapMode y)
        {
            WrapX = x;
            WrapY = y;

            return this;
        }

        public TextureBuilder<T> HasMipmaps(bool useMipmaps = true)
        {
            GenerateMipmaps = useMipmaps;

            return this;
        }

        public Texture Build()
        {
            var texture = new Texture(_state);
            
            texture.TexImage2d(Width, Height, Data, PixelFormat, InternalFormat, PixelType, 0);

            texture.FilterMagnify = FilterMagnify;
            texture.FilterMinify = FilterMinify;
            texture.WrapX = WrapX;
            texture.WrapY = WrapY;

            if(GenerateMipmaps)
            {
                texture.GenerateMipmaps();
            }

            return texture;
        }
    }
}
