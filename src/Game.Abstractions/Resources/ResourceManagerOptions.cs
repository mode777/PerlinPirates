using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.FileProviders;

namespace Game.Abstractions
{
    public class ResourceManagerOptions
    {
        private readonly List<IFileProvider> _providers = new List<IFileProvider>();

        public void AddProvider(IFileProvider provider)
        {
            _providers.Add(provider);
        }
        
        public IFileProvider CreateFileProvider()
        {
            return new CompositeFileProvider(_providers);
        }
    }
}