using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Game.Abstractions
{
    public class ResourceManager
    {
        private readonly IOptions<ResourceManagerOptions> _options;
        private readonly IServiceProvider _provider;

        private readonly ConcurrentDictionary<string, object> _resources
            = new ConcurrentDictionary<string, object>();

        public ResourceManager(IOptions<ResourceManagerOptions> options, IServiceProvider provider)
        {
            _options = options;
            _provider = provider;
        }
        
        public T LoadResource<T>(string key)
            where T : class
        {
            return (T)_resources.GetOrAdd(key, k =>
            {
                var loader = _provider.GetRequiredService<ResourceLoader<T>>();

                if(loader == null)
                    throw new InvalidOperationException($"No loader registered for {typeof(T)}");

                Stream stream = null;

                foreach (var resolver in _options.Value.Resolvers)
                {
                    stream = resolver.Resolve(k);
                    if (stream != null)
                        break;
                }

                return loader.LoadObject(key, stream);
            });
        }
    }
}
