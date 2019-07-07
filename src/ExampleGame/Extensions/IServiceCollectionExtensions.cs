using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleGame.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection RegisterSystem<T>(this IServiceCollection services, int updateEveryNth = 1)
            where T : class
        {
            services.Configure<GameLoopOptions>(x => x.AddSystem<T>(updateEveryNth));
            services.AddSingleton<T>();

            return services;
        }
    }
}
