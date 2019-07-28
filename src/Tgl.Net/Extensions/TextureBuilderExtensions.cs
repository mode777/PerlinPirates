using Tgl.Net.Bindings;
using Tgl.Net.Imaging;

namespace Tgl.Net.Extensions
{
    public static class TextureBuilderExtensions
    {
        public static TextureBuilder<ColorRgba> UseImageData(this TextureBuilder<ColorRgba> builder, ImageData<ColorRgba> imageData)
        {
            return builder.HasSize(imageData.Size.Width, imageData.Size.Height)
                .HasPixelFormat(PixelFormat.GL_RGBA)
                .HasInternalFormat(InternalFormat.GL_RGBA)
                .HasData(imageData.Pixels);
        }

        public static TextureBuilder<ColorRgb> UseImageData(this TextureBuilder<ColorRgb> builder, ImageData<ColorRgb> imageData)
        {
            return builder.HasSize(imageData.Size.Width, imageData.Size.Height)
                .HasPixelFormat(PixelFormat.GL_RGB)
                .HasInternalFormat(InternalFormat.GL_RGB)
                .HasData(imageData.Pixels);
        }
    }
}