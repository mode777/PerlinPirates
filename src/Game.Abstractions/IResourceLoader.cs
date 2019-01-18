using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Game.Abstractions
{
    public interface IResourceLoader
    {
        Task<T> Load<T>(string key) where T : class;
    }

    public interface IResourceLoader<T> : IResourceLoader
        where T : class
    {
        Task<T> Load(string key);
    }
}
