using System.IO;

namespace Game.Abstractions
{
    public abstract class BinaryLoader<T> : ResourceLoader<T>
    {
        public override T Load(string rid, Stream stream)
        {
            using (StreamReader sr = new StreamReader(stream))
            using (var memstream = new MemoryStream())
            {
                sr.BaseStream.CopyTo(memstream);
                return Load(memstream.ToArray());
            }
        }

        protected abstract T Load(byte[] bytes);
    }

    public class BinaryLoader : BinaryLoader<byte[]>
    {
        protected override byte[] Load(byte[] bytes)
        {
            return bytes;
        }
    }
}