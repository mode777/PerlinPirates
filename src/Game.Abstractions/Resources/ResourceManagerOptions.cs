using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Game.Abstractions
{
    public class ResourceManagerOptions
    {
        private readonly List<IResourceResolver> _resolvers = new List<IResourceResolver>();

        public IEnumerable<IResourceResolver> Resolvers => _resolvers.AsReadOnly();

        public void AddFilesystem(DirectoryInfo basePath)
        {
            _resolvers.Add(new FilesystemResourceResolver(basePath));
        }

        public void AddEmbeddedAssembly(Assembly assembly)
        {
            _resolvers.Add(new EmbeddedResourceResolver(assembly));
        }
    }
}