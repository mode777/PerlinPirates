using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.PixelFormats;
using Tgl.Net.Abstractions;

namespace ImageSharpLoader
{
    internal class ImageAdapter<TPixel> : Tgl.Net.Abstractions.IImage
        where TPixel : struct, IPixel<TPixel>
    {
        public ImageAdapter(Image<TPixel> image)
        {
            var span = image.GetPixelSpan();
            var bytes = MemoryMarshal.AsBytes(span);

            Data = bytes.ToArray();
            Format = ImagePixelFormat.Rgba;
            Width = image.Width;
            Height = image.Height;
        }

        public ImagePixelFormat Format { get; }

        public byte[] Data { get; }

        public int Width { get; }

        public int Height { get; }
    }
}
