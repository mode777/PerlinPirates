using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Game.Abstractions
{
    public interface IResourceLoader
    {
        Task<T> LoadAsync<T>(string key) where T : class;
        T Load<T>(string key) where T : class;
    }

    public interface IResourceLoader<T> : IResourceLoader
        where T : class
    {
        Task<T> LoadAsync(string key);
        T Load(string key);
    }
}
