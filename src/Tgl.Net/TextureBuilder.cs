using Tgl.Net.Bindings;

namespace Tgl.Net
{
    public class TextureBuilder<T>
        where T : struct
    {
        private readonly IGlState _state;

        public T[] Data { get; private set; } = null;
        public int Width { get; private set; } = 1;
        public int Height { get; private set; } = 1;
        public GL.PixelFormat PixelFormat { get; private set; } = GL.PixelFormat.GL_RGBA;
        public GL.InternalFormat InternalFormat { get; private set; } = GL.InternalFormat.GL_RGBA;
        public GL.PixelType PixelType { get; private set; } = GL.PixelType.GL_UNSIGNED_BYTE;
        public GL.TextureMagType FilterMagnify { get; private set; } = GL.TextureMagType.GL_LINEAR;
        public GL.TextureMinType FilterMinify { get; private set; } = GL.TextureMinType.GL_LINEAR;
        public GL.TextureWrapMode WrapX { get; private set; } = GL.TextureWrapMode.GL_REPEAT;
        public GL.TextureWrapMode WrapY { get; private set; } = GL.TextureWrapMode.GL_REPEAT;
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

        public TextureBuilder<T> HasPixelFormat(GL.PixelFormat format)
        {
            PixelFormat = format;

            return this;
        }

        public TextureBuilder<T> HasPixelType(GL.PixelType type)
        {
            PixelType = type;

            return this;
        }

        public TextureBuilder<T> HasInternalFormat(GL.InternalFormat internalFormat)
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

        public TextureBuilder<T> HasFiltering(GL.TextureMinType minify, GL.TextureMagType magnify)
        {
            FilterMinify = minify;
            FilterMagnify = magnify;

            return this;
        }

        public TextureBuilder<T> HasWrapping(GL.TextureWrapMode x, GL.TextureWrapMode y)
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
            if (Data != null)
            {
                texture.TexImage2d(Width, Height, Data, PixelFormat, InternalFormat, PixelType, 0);
            }

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
