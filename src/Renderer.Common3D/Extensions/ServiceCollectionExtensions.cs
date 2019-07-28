using Game.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Renderer.Common.Extensions;

namespace Renderer.Common3D.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection Add3dRendering(this IServiceCollection services)
        {
            services.AddGles2();
            services.Configure<ResourceManagerOptions>(x =>
                x.AddProvider(new EmbeddedFileProvider(typeof(ServiceCollectionExtensions).Assembly)));

            return services;
        }
    }
}
