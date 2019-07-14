using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Tgl.Net.Bindings;
using Tgl.Net.Helpers;
using static Tgl.Net.Bindings.GL;

namespace Tgl.Net
{
    public class Texture : IDisposable
    {
        private static readonly ConcurrentDictionary<uint, Texture> _register = new ConcurrentDictionary<uint, Texture>();

        public static Texture GetInstanceForHandle(uint handle)
        {
            _register.TryGetValue(handle, out var text);

            return text;
        }

        private readonly IGlState _state;
        private TextureWrapMode _wrapX;
        private TextureWrapMode _wrapY;
        private TextureMinType _filterMinify;
        private TextureMagType _filterMagnify;

        internal Texture(IGlState state)
        {
            _state = state;

            unsafe
            {
                var handle = Handle;
                glGenTextures(1, &handle);
                Handle = handle;
            }

            _register.TryAdd(Handle, this);
        }

        public uint Handle { get; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public PixelFormat PixelFormat { get; private set; }
        public PixelType PixelType { get; private set; }
        public InternalFormat InternalFormat { get; private set; }
        public bool HasMipmaps { get; private set; }
        public TextureWrapMode WrapX
        {
            get => _wrapX;
            set
            {
                if (_wrapX != value)
                {
                    Bind();

                    glTexParameteri(TextureTarget.GL_TEXTURE_2D,
                        TextureParameterName.GL_TEXTURE_WRAP_S,
                        (int)value);

                    _wrapX = value;
                }
            }
        }
        public TextureWrapMode WrapY
        {
            get => _wrapY;
            set
            {
                Bind();

                if (_wrapY != value)
                {
                    glTexParameteri(TextureTarget.GL_TEXTURE_2D,
                        TextureParameterName.GL_TEXTURE_WRAP_T,
                        (int)value);

                    _wrapY = value;
                }
            }
        }
        public TextureMinType FilterMinify
        {
            get => _filterMinify;
            set
            {
                if (_filterMinify != value)
                {
                    Bind();

                    glTexParameteri(TextureTarget.GL_TEXTURE_2D,
                        TextureParameterName.GL_TEXTURE_MIN_FILTER,
                        (int) value);

                    _filterMinify = value;
                }
            }
        }
        public TextureMagType FilterMagnify
        {
            get => _filterMagnify;
            set
            {
                if (_filterMagnify != value)
                {
                    Bind();

                    glTexParameteri(TextureTarget.GL_TEXTURE_2D,
                        TextureParameterName.GL_TEXTURE_MAG_FILTER,
                        (int)value);

                    _filterMagnify = value;
                } 
            }
        }

        public void SubImage2d<T>(
            int offsetX,
            int offsetY,
            int width,
            int height,
            T[] data,
            PixelFormat format = PixelFormat.GL_RGBA,
            PixelType type = PixelType.GL_UNSIGNED_BYTE,
            int lod = 0)
            where T : struct
        {
            Bind();

            if (width + offsetX > Width || height + offsetY > Height)
            {
                throw new InvalidOperationException("Subimage is to large");
            }

            using (var handle = new PinnedGCHandle(data))
            {
                glTexSubImage2D(
                    TextureTarget.GL_TEXTURE_2D,
                    lod, 
                    offsetX, 
                    offsetY, 
                    width,
                    height,
                    format,
                    type,
                    handle.Pointer);
            }

            if (lod == 0)
            {
                PixelFormat = format;
                PixelType = type;
            }
        }

        public void Image2d<T>(
            int width,
            int height,
            T[] data,
            PixelFormat format = PixelFormat.GL_RGBA,
            InternalFormat internalFormat = InternalFormat.GL_RGBA,
            PixelType type = PixelType.GL_UNSIGNED_BYTE,
            int lod = 0)
            where T : struct
        {
            Bind();

            using (var handle = new PinnedGCHandle(data))
            {
                glTexImage2D(
                    TextureTarget.GL_TEXTURE_2D,
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

        public void SetWrapping(TextureWrapMode wrap)
        {
            WrapX = wrap;
            WrapY = wrap;
        }

        public void SetFilter(TextureMagType filter)
        {
            FilterMagnify = filter;
            FilterMinify = (TextureMinType) filter;
        }
        
        public void GenerateMipmap()
        {
            Bind();

            glGenerateMipmap(TextureTarget.GL_TEXTURE_2D);
        }

        public void Dispose()
        {
            unsafe
            {
                var handle = (uint)Handle;
                glDeleteTextures(1, &handle);
            }
        }
    }
}
