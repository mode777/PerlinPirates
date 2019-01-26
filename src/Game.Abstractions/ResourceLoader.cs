using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Game.Abstractions
{
    public abstract class ResourceLoader<T> : IResourceLoader<T>
        where T : class
    {
        public ResourceLoader(IResourceResolver resolver)
        {
            Resolver = resolver;
        }

        private IResourceResolver Resolver { get; }

        protected Stream ResolveResourceId(string resourceId)
        {
            return Resolver.Resolve(resourceId);
        }

        public abstract Task<T> LoadAsync(string key);
        public abstract T Load(string key);
        
        public async Task<T1> LoadAsync<T1>(string key)
            where T1 : class
        {
            return (await LoadAsync(key)) as T1;
        }

        public T1 Load<T1>(string key) 
            where T1 : class
        {
            return Load(key) as T1;
        }
    }
}
