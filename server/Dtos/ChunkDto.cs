using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldServer.Aggregates;

namespace WorldServer.Dtos
{
    public class ChunkDto
    {       

        public ChunkDto(Chunk chk)
        {
            var bytes = (byte[])(object)chk.GetData();

            unsafe
            {
                fixed (byte* raw = bytes)
                {
                    X = chk.X;
                    Y = chk.Y;
                    Width = chk.Width;
                    Height = chk.Height;
                    Data = Convert.ToBase64String(new ReadOnlySpan<byte>(raw, bytes.Length));
                }
            }
        }

        public int X { get; private set;  }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public string Data { get; private set; }
    }
}
