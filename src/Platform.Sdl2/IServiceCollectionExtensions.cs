using System;
using Game.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Platform.Sdl2
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSdl2(this IServiceCollection services, Action<Sdl2Options> configureOptions)
        {
            services.Configure(configureOptions);
            services.TryAddSingleton<Sdl2Platform>();
            services.TryAddSingleton<IPlatform>(x => x.GetRequiredService<Sdl2Platform>());
            services.TryAddSingleton<IGlLoader>(x => x.GetRequiredService<Sdl2Platform>());

            return services;
        }

    }
}