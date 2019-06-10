using System;
using Microsoft.Extensions.DependencyInjection;

namespace Game.Abstractions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddResourceLoader<TResource, TLoader>(this IServiceCollection services)
            where TLoader : ResourceLoader<TResource>
        {
            services.AddScoped<ResourceLoader<TResource>, TLoader>();
            return services;
        }

        public static IServiceCollection AddResourceManager(this IServiceCollection services, Action<ResourceManagerOptions> options)
        {
            services.Configure(options);

            services.AddSingleton<ResourceManager>();
            services.AddResourceLoader<string, StringLoader>();
            services.AddResourceLoader<byte[], BinaryLoader>();

            return services;
        }
    }
}