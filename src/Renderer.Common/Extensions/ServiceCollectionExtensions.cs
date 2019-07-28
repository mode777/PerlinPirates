using System;
using System.Collections.Generic;
using System.Text;
using Game.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Tgl.Net;

namespace Renderer.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGles2(this IServiceCollection services)
        {
            services.AddResourceLoader<Shader, ShaderLoader>();

            services.TryAddSingleton(x =>
                new GlContext(x.GetRequiredService<IGlLoader>().GetGlProcAddress));

            return services;
        }
    }
}
