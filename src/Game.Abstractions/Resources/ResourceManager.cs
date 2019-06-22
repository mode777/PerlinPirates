using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;

namespace Game.Abstractions
{
    public class ResourceManager
    {
        private readonly IServiceProvider _provider;
        private readonly IFileProvider _fileProvider;

        private readonly ConcurrentDictionary<(Type, string), object> _resources
            = new ConcurrentDictionary<(Type, string), object>();

        public ResourceManager(IServiceProvider provider, IOptions<ResourceManagerOptions> options)
        {
            _provider = provider;
            _fileProvider = options.Value.CreateFileProvider();
        }
        
        public T LoadResource<T>(string key)
            where T : class
        {
            return (T)_resources.GetOrAdd((typeof(T), key), tuple =>
            {
                var loader = _provider.GetRequiredService<ResourceLoader<T>>();

                if(loader == null)
                    throw new InvalidOperationException($"No loader registered for {typeof(T)}");

                var file = _fileProvider.GetFileInfo(tuple.Item2);

                return loader.LoadObject(key, file.Exists 
                    ? file.CreateReadStream() 
                    : null);

            });
        }
    }
}
