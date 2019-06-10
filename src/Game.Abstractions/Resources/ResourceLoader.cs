using System.IO;

namespace Game.Abstractions
{
    public abstract class ResourceLoader<T> : IResourceLoader
    {
        public abstract T Load(string rid, Stream stream);
        public object LoadObject(string rid, Stream stream)
        {
            return Load(rid, stream);
        }
    }
}