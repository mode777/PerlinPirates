using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Game.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Renderer.Common.Extensions;
using Renderer.Common2D.Primitives;
using Tgl.Net;

namespace Renderer.Common2D.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection Add2dRendering(this IServiceCollection services)
        {
            services.AddGles2();
            services.Configure<ResourceManagerOptions>(x =>
                x.AddProvider(new EmbeddedFileProvider(typeof(ServiceCollectionExtensions).Assembly)));

            services.AddSingleton<Shader2d>();
            services.AddSingleton<Context2d>();

            return services;
        }
    }
}
