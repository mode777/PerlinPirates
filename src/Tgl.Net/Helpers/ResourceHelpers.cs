using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tgl.Net.Helpers
{
    public static class ResourceHelpers
    {
        public static string GetResourceString(Assembly assembly, string resource)
        {
            using (var reader = new StreamReader(GetResourceStream(assembly, resource), Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

        public static string GetResourceString(string resource)
        {
            return GetResourceString(Assembly.GetCallingAssembly(), resource);
        }

        public static Stream GetResourceStream(Assembly assembly, string resource)
        {
            var assemblyName = assembly.GetName().Name;
            //var all = assembly.GetManifestResourceNames();
            var stream = assembly.GetManifestResourceStream($"{assemblyName}.{resource}");

            if(stream == null)
                throw new KeyNotFoundException(resource);

            return stream;
        }

        public static Stream GetResourceStream(string resource)
        {
            return GetResourceStream(Assembly.GetCallingAssembly(), resource);
        }
    }
}
