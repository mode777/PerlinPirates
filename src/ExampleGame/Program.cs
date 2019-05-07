using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading;
using System.Threading.Tasks;
using Game.Abstractions;
using ImageSharpLoader;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Platform.Sdl2;
using Renderer.Gles2;
using Tgl.Net.Abstractions;

namespace ExampleGame
{
    


    class Program
    {
        private static string[] _args;

        public static async Task Main(string[] args)
        {
            _args = args;

            var host = new HostBuilder()
                .ConfigureServices(ConfigureServices)
                .ConfigureHostConfiguration(ConfigureHost)
                .ConfigureAppConfiguration(ConfigureApp)
                .ConfigureLogging(ConfigureLogging)
                .UseConsoleLifetime()
                .Build();

            await host.RunAsync();
        }

        private static void ConfigureLogging(HostBuilderContext hostContext, ILoggingBuilder configLogging)
        {
            configLogging.AddConsole();
            configLogging.AddDebug();
        }

        private static void ConfigureApp(HostBuilderContext hostContext, IConfigurationBuilder configApp)
        {
            configApp.AddJsonFile("appsettings.json", optional: true);
            configApp.AddJsonFile(
                $"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json",
                optional: true);
        }

        private static void ConfigureHost(IConfigurationBuilder configHost)
        {
            configHost.SetBasePath(Directory.GetCurrentDirectory());
            configHost.AddEnvironmentVariables(prefix: "COREGAME_");
            configHost.AddCommandLine(_args);
        }

        private static void ConfigureServices(HostBuilderContext hostContext, IServiceCollection services)
        {
            services.AddHostedService<GameHost>();
        }

    }
}
