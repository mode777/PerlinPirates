using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Game.Abstractions
{
    public interface IImageLoader
    {
        IImage LoadBmp(Stream stream, PixelFormat format);
        IImage LoadPng(Stream stream, PixelFormat format);
        IImage LoadJpg(Stream stream, PixelFormat format);
        IImage Load(string path, PixelFormat format);
        IImage Load(Stream stream, PixelFormat format);
    }
}
