using System;
using System.IO;

namespace Game.Abstractions
{
    public class StreamLoader : ResourceLoader<Stream>
    {
        public override Stream Load(string rid, Stream stream)
        {
            return stream ?? throw new NullReferenceException(rid);
        }
    }
}