using System;
using System.Collections.Generic;
using System.Text;
using Tgl.Net.Bindings;
using Tgl.Net.State;

namespace Tgl.Net.Texture
{
    public class TextureBuilder
    {
        private readonly IGlState _state;

        public object Source { get; private set; } = null;
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

        public TextureBuilder HasData(object source, 
            GL.PixelFormat format = GL.PixelFormat.GL_RGBA, 
            GL.InternalFormat internalFormat = GL.InternalFormat.GL_RGBA, 
            GL.PixelType type = GL.PixelType.GL_UNSIGNED_BYTE)
        {
            Source = source;
            PixelFormat = format;
            PixelType = type;
            InternalFormat = internalFormat;

            return this;
        }

        public TextureBuilder HasData(
            GL.PixelFormat format, 
            GL.InternalFormat internalFormat,
            params byte[] bytes)
        {
            return HasData(bytes, format, internalFormat);
        }

        public TextureBuilder HasSize(int width, int height)
        {
            Width = width;
            Height = height;

            return this;
        }

        public TextureBuilder HasFiltering(GL.TextureMinType minify, GL.TextureMagType magnify)
        {
            FilterMinify = minify;
            FilterMagnify = magnify;

            return this;
        }

        public TextureBuilder HasWrapping(GL.TextureWrapMode x, GL.TextureWrapMode y)
        {
            WrapX = x;
            WrapY = y;

            return this;
        }

        public TextureBuilder HasMipmaps(bool useMipmaps = true)
        {
            GenerateMipmaps = useMipmaps;

            return this;
        }

        public Texture Build()
        {
            return new Texture(_state, this);
        }
    }
}
