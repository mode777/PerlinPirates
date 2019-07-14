using Tgl.Net.Bindings;
using Tgl.Net.Imaging;

namespace Tgl.Net.Extensions
{
    public static class TextureBuilderExtensions
    {
        public static TextureBuilder<PixelRgba> UseImageData(this TextureBuilder<PixelRgba> builder, ImageData<PixelRgba> imageData)
        {
            return builder.HasSize(imageData.Size.Width, imageData.Size.Height)
                .HasPixelFormat(PixelFormat.GL_RGBA)
                .HasInternalFormat(InternalFormat.GL_RGBA)
                .HasData(imageData.Pixels);
        }

        public static TextureBuilder<PixelRgb> UseImageData(this TextureBuilder<PixelRgb> builder, ImageData<PixelRgb> imageData)
        {
            return builder.HasSize(imageData.Size.Width, imageData.Size.Height)
                .HasPixelFormat(PixelFormat.GL_RGB)
                .HasInternalFormat(InternalFormat.GL_RGB)
                .HasData(imageData.Pixels);
        }
    }
}