using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Game.Abstractions
{
    public class FilesystemResourceResolver : IResourceResolver
    {
        private readonly DirectoryInfo _basePath;

        public FilesystemResourceResolver(DirectoryInfo basePath)
        {
            this._basePath = basePath;
        }

        public FilesystemResourceResolver()
        {

        }

        public Stream Resolve(string rid)
        {
            if(_basePath != null && !Path.IsPathRooted(rid))
            {
                rid = Path.Combine(_basePath.FullName, rid);
            }

            return File.OpenRead(rid);
        }
    }
}
