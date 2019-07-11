using System;
using System.IO;
using System.Runtime.InteropServices;
using Game.Abstractions;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using Tgl.Net;

namespace Loader.ImageSharp
{
    public class TextureLoader : ResourceLoader<Texture>
    {
        private readonly GlContext _context;

        public TextureLoader(GlContext context)
        {
            _context = context;
        }

        public override Texture Load(string rid, Stream stream)
        {
            if(stream == null)
                throw new InvalidOperationException($"Could not load texture '{rid}'");

            using (var image = Image.Load(stream))
            {
                var span = image.GetPixelSpan();
                var bytes = MemoryMarshal
                        .AsBytes(span)
                        .ToArray();

                return _context.TextureFromPixels(bytes, 
                    image.Width, 
                    image.Height, 
                    ImagePixelFormat.Rgba);
            }
        }
    }
}
