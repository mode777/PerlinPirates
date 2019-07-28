using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Game.Abstractions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddResourceLoader<TResource, TLoader>(this IServiceCollection services)
            where TLoader : ResourceLoader<TResource>
        {
            services.TryAddScoped<ResourceLoader<TResource>, TLoader>();

            return services;
        }

        public static IServiceCollection AddResourceManager(this IServiceCollection services, Action<ResourceManagerOptions> options)
        {
            services.Configure(options);

            services.TryAddSingleton<ResourceManager>();
            services.AddResourceLoader<string, StringLoader>();
            services.AddResourceLoader<byte[], BinaryLoader>();
            services.AddResourceLoader<Stream, StreamLoader>();

            return services;
        }
    }
}