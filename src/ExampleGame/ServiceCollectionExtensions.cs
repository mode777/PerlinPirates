using Game.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleGame
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterGameComponent<T>(this IServiceCollection services) where T : GameComponent
        {
            services.AddScoped(typeof(T));
            services.Configure<SceneManagerConfiguration>(x => x.AddComponent<T>());
        }
    }
}