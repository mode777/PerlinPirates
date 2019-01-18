using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Game.Abstractions;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Formats.Bmp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using Tgl.Net.Abstractions;
using IImage = Tgl.Net.Abstractions.IImage;

namespace ImageSharpLoader
{
    public class ImageLoader : ResourceLoader<IImage>
    {
        public ImageLoader(IResourceResolver resolver) : base(resolver)
        {
        }

        public IImage Load(string path, ImagePixelFormat format)
        {
            using (var stream = File.Open(path, FileMode.Open))
            {
                return Load(stream, format);
            }
        }

        public IImage Load(Stream stream, ImagePixelFormat format)
        {
            using (var pixels = Image.Load(stream))
            {
                return new ImageAdapter<Rgba32>(pixels);
            }
        }

        public override Task<IImage> Load(string key)
        {
            using(var stream = ResolveResourceId(key))
            {
                return Task.FromResult(Load(stream, ImagePixelFormat.Rgba));
            }
        }

        public IImage LoadBmp(Stream stream, ImagePixelFormat format)
        {
            using (var image = Image.Load<Rgba32>(stream, new BmpDecoder()))
            {
                return new ImageAdapter<Rgba32>(image);
            }
        }

        public IImage LoadJpg(Stream stream, ImagePixelFormat format)
        {
            using (var image = Image.Load<Rgba32>(stream, new JpegDecoder()))
            {
                return new ImageAdapter<Rgba32>(image);
            }
        }

        public IImage LoadPng(Stream stream, ImagePixelFormat format)
        {
            using (var image = Image.Load<Rgba32>(stream, new PngDecoder()))
            {
                return new ImageAdapter<Rgba32>(image);
            }
        }
    }
}
