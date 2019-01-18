using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Game.Abstractions
{
    public class ResourceManager
    {
        private readonly ConcurrentDictionary<Type, IResourceLoader> _loaders 
            = new ConcurrentDictionary<Type, IResourceLoader>();

        private readonly ConcurrentDictionary<string, Task<object>> _resources
            = new ConcurrentDictionary<string, Task<object>>();

        public void RegisterLoader<T>(IResourceLoader<T> loader, IResourceResolver resolver = null)
            where T : class
        {
            _loaders.TryAdd(typeof(T), loader);
        } 

        public async Task<T> LoadResourceAsync<T>(string key)
            where T : class
        {
            return (T) await _resources.GetOrAdd(key, async k =>
            {
                if (_loaders.TryGetValue(typeof(T), out var loader))
                {                    
                    return await loader.Load<T>(k);
                }
                else
                {
                    throw new KeyNotFoundException($"No loader registered for type {typeof(T).Name}");
                }
            });
        }

        public T LoadResource<T>(string key)
            where T : class
        {
            return (T)_resources.GetOrAdd(key, async k =>
            {
                if (_loaders.TryGetValue(typeof(T), out var loader))
                {
                    return await loader.Load<T>(k);
                }
                else
                {
                    throw new KeyNotFoundException($"No loader registered for type {typeof(T).Name}");
                }
            }).Result;
        }
    }
}
