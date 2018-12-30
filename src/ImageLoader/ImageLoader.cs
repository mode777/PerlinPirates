﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using Game.Abstractions;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Formats.Bmp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using IImage = Game.Abstractions.IImage;

namespace ImageSharpLoader
{
    public class ImageLoader : IImageLoader
    {
        public IImage Load(string path, PixelFormat format)
        {
            using (var stream = File.Open(path, FileMode.Open))
            {
                return Load(stream, format);
            }
        }

        public IImage Load(Stream stream, PixelFormat format)
        {
            using (var pixels = Image.Load(stream))
            {
                return new ImageAdapter<Rgba32>(pixels);
            }
        }

        public IImage LoadBmp(Stream stream, PixelFormat format)
        {
            using (var image = Image.Load<Rgba32>(stream, new BmpDecoder()))
            {
                return new ImageAdapter<Rgba32>(image);
            }
        }

        public IImage LoadJpg(Stream stream, PixelFormat format)
        {
            using (var image = Image.Load<Rgba32>(stream, new JpegDecoder()))
            {
                return new ImageAdapter<Rgba32>(image);
            }
        }

        public IImage LoadPng(Stream stream, PixelFormat format)
        {
            using (var image = Image.Load<Rgba32>(stream, new PngDecoder()))
            {
                return new ImageAdapter<Rgba32>(image);
            }
        }
    }
}
