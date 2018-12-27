using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Tgl.Net.Bindings;
using Tgl.Net.Helpers;

namespace Tgl.Net
{
    public class Texture : IDisposable
    {
        private readonly IGlState _state;
        private GL.TextureWrapMode _wrapX;
        private GL.TextureWrapMode _wrapY;
        private GL.TextureMinType _filterMinify;
        private GL.TextureMagType _filterMagnify;

        internal Texture(IGlState state)
        {
            _state = state;

            unsafe
            {
                var handle = Handle;
                GL.glGenTextures(1, &handle);
                Handle = handle;
            }
        }

        public uint Handle { get; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public GL.PixelFormat PixelFormat { get; private set; }
        public GL.PixelType PixelType { get; private set; }
        public GL.InternalFormat InternalFormat { get; private set; }
        public bool HasMipmaps { get; private set; }
        public GL.TextureWrapMode WrapX
        {
            get => _wrapX;
            set
            {
                if (_wrapX != value)
                {
                    Bind();

                    GL.glTexParameteri(GL.TextureTarget.GL_TEXTURE_2D,
                        GL.TextureParameterName.GL_TEXTURE_WRAP_S,
                        (int)value);

                    _wrapX = value;
                }
            }
        }
        public GL.TextureWrapMode WrapY
        {
            get => _wrapY;
            set
            {
                Bind();

                if (_wrapY != value)
                {
                    GL.glTexParameteri(GL.TextureTarget.GL_TEXTURE_2D,
                        GL.TextureParameterName.GL_TEXTURE_WRAP_T,
                        (int)value);

                    _wrapY = value;
                }
            }
        }
        public GL.TextureMinType FilterMinify
        {
            get => _filterMinify;
            set
            {
                if (_filterMinify != value)
                {
                    Bind();

                    GL.glTexParameteri(GL.TextureTarget.GL_TEXTURE_2D,
                        GL.TextureParameterName.GL_TEXTURE_MIN_FILTER,
                        (int) value);

                    _filterMinify = value;
                }
            }
        }
        public GL.TextureMagType FilterMagnify
        {
            get => _filterMagnify;
            set
            {
                if (_filterMagnify != value)
                {
                    Bind();

                    GL.glTexParameteri(GL.TextureTarget.GL_TEXTURE_2D,
                        GL.TextureParameterName.GL_TEXTURE_MAG_FILTER,
                        (int)value);

                    _filterMagnify = value;
                } 
            }
        }

        public void TexImage2d<T>(
            int width,
            int height,
            T[] data,
            GL.PixelFormat format = GL.PixelFormat.GL_RGBA,
            GL.InternalFormat internalFormat = GL.InternalFormat.GL_RGBA,
            GL.PixelType type = GL.PixelType.GL_UNSIGNED_BYTE,
            int lod = 0)
            where T : struct
        {
            Bind();

            using (var handle = new PinnedGCHandle(data))
            {
                GL.glTexImage2D(
                    GL.TextureTarget.GL_TEXTURE_2D,
                    lod,
                    internalFormat,
                    width,
                    height,
                    lod,
                    format,
                    type,
                    handle.Pointer);
            }

            if (lod == 0)
            {
                InternalFormat = internalFormat;
                PixelFormat = format;
                PixelType = type;
                Width = width;
                Height = height;
            }
        }

        public void Bind()
        {
            _state.TextureBinding2D = Handle;
        }

        public void SetWrapping(GL.TextureWrapMode wrap)
        {
            WrapX = wrap;
            WrapY = wrap;
        }

        public void SetFilter(GL.TextureMagType filter)
        {
            FilterMagnify = filter;
            FilterMinify = (GL.TextureMinType) filter;
        }

        public void GenerateMipmaps()
        {
            Bind();

            GL.glGenerateMipmap(GL.TextureTarget.GL_TEXTURE_2D);
        }

        public void Dispose()
        {
            unsafe
            {
                var handle = (uint)Handle;
                GL.glDeleteTextures(1, &handle);
            }
        }
    }
}
