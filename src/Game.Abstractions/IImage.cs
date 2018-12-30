using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Abstractions
{
    public interface IImage
    {
        PixelFormat Format { get; }
        byte[] Data { get; }
        int Width { get; }
        int Height { get; }
    }
}
