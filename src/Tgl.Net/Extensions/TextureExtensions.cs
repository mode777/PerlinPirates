using System;
using System.Collections.Generic;
using System.Text;
using Tgl.Net.Imaging;

namespace Tgl.Net.Extensions
{
    public static class TextureExtensions
    {
        public static void Update<TPixel>(this Texture texture, ImageData<TPixel> data)
            where TPixel : struct
        {
            texture.SubImage2d(0, 0, data.Size.Width, data.Size.Height, data.Pixels, texture.PixelFormat, texture.PixelType);
        }
    }
}
