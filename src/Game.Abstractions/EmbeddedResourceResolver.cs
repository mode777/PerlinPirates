using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Game.Abstractions
{
    public class EmbeddedResourceResolver : IResourceResolver
    {
        private readonly Assembly _assembly;

        public EmbeddedResourceResolver(Assembly assembly)
        {
            _assembly = assembly;
        }

        public Stream Resolve(string rid)
        {
            return ResourceHelpers.GetResourceStream(_assembly, rid);
        }
    }
}
