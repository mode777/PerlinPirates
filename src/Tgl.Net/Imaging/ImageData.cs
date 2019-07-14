using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Tgl.Net.Imaging
{
    public class ImageData<TPixel>
        where TPixel : struct
    {
        public readonly TPixel[] Pixels;
        public Size Size { get; }

        public ImageData(Size size)
        {
            Size = size;
            Pixels = new TPixel[Size.Width * Size.Height];
        }

        public void SetPixel(int x, int y, TPixel pixel)
        {
            Pixels[(y * Size.Width) + x] = pixel;
        }

        public void SetPixels(Func<int,int, TPixel> provider)
        {
            var width = Size.Width;

            for (int i = 0; i < Pixels.Length; i++)
            {
                Pixels[i] = provider(i % width, i / width);
            }
        }
    }
}
