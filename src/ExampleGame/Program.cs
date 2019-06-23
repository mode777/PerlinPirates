using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using System.Threading;
using System.Threading.Tasks;
using ExampleGame.Entites;
using ExampleGame.Loaders;
using ExampleGame.Tests;
using Game.Abstractions;
using ImageSharpLoader;
using Loader.Tmx;
using Loader.Tmx.Xml;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Platform.RaspberryPi;
using Platform.Sdl2;
using Renderer.Gles2;
using Renderer.Gles2.Tests;
using Tgl.Net;

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
            configLogging.AddConfiguration((IConfiguration)hostContext.Configuration.GetSection("Logging"));
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
            services.AddResourceManager(o => o.AddProvider(new EmbeddedFileProvider(Assembly.GetEntryAssembly())));
            services.AddResourceLoader<Texture, TextureLoader>();
            services.AddResourceLoader<Shader, ShaderLoader>();
            services.AddResourceLoader<SpriteFont, SpriteFontLoader>();

            services.AddResourceLoader<Tilemap, TilemapLoader>();
            services.AddResourceLoader<Tileset, TilesetLoader>();
            services.AddResourceLoader<TiledMap, TiledMapLoader>();
            services.AddResourceLoader<TiledTileset, TiledTilesetLoader>();

            services.AddResourceLoader<GameMap, GameMapLoader>();

            services.AddSdl2(x => hostContext.Configuration.Bind("Platform", x));
            
            services.AddSingleton(x => 
                new GlContext(x.GetRequiredService<IGlLoader>().GetGlProcAddress));
            services.AddSingleton<Shader2d>();

            services.AddSingleton<IGameComponent, TilesTest>();
            //services.RegisterGameComponent<Input>();

            services.AddSingleton<EventsProvider>();
            services.AddSingleton<IEventSource>(x => x.GetRequiredService<EventsProvider>());
            services.AddSingleton<IEventDispatcher>(x => x.GetRequiredService<EventsProvider>());
            
            services.AddScoped<IGameLoop, GameLoop>();
            services.AddHostedService<GameHost>();
        }

        
    }
}

// for reference
//public static IWebHostBuilder CreateDefaultBuilder(string[] args)
//{
//    WebHostBuilder hostBuilder = new WebHostBuilder();
//    if (string.IsNullOrEmpty(hostBuilder.GetSetting(WebHostDefaults.ContentRootKey)))
//        hostBuilder.UseContentRoot(Directory.GetCurrentDirectory());
//    if (args != null)
//        hostBuilder.UseConfiguration((IConfiguration)new ConfigurationBuilder().AddCommandLine(args).Build());
//    hostBuilder.UseKestrel((Action<WebHostBuilderContext, KestrelServerOptions>)((builderContext, options) => options.Configure((IConfiguration)builderContext.Configuration.GetSection("Kestrel")))).ConfigureAppConfiguration((Action<WebHostBuilderContext, IConfigurationBuilder>)((hostingContext, config) =>
//    {
//        IHostingEnvironment hostingEnvironment = hostingContext.HostingEnvironment;
//        config.AddJsonFile("appsettings.json", true, true).AddJsonFile("appsettings." + hostingEnvironment.EnvironmentName + ".json", true, true);
//        if (hostingEnvironment.IsDevelopment())
//        {
//            Assembly assembly = Assembly.Load(new AssemblyName(hostingEnvironment.ApplicationName));
//            if (assembly != (Assembly)null)
//                config.AddUserSecrets(assembly, true);
//        }
//        config.AddEnvironmentVariables();
//        if (args == null)
//            return;
//        config.AddCommandLine(args);
//    })).ConfigureLogging((Action<WebHostBuilderContext, ILoggingBuilder>)((hostingContext, logging) =>
//    {
//        logging.AddConfiguration((IConfiguration)hostingContext.Configuration.GetSection("Logging"));
//        logging.AddConsole();
//        logging.AddDebug();
//        logging.AddEventSourceLogger();
//    })).ConfigureServices((Action<WebHostBuilderContext, IServiceCollection>)((hostingContext, services) =>
//    {
//        services.PostConfigure<HostFilteringOptions>((Action<HostFilteringOptions>)(options =>
//        {
//            if (options.AllowedHosts != null && options.AllowedHosts.Count != 0)
//                return;
//            string str = hostingContext.Configuration["AllowedHosts"];
//            string[] strArray1;
//            if (str == null)
//                strArray1 = (string[])null;
//            else
//                strArray1 = str.Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
//            string[] strArray2 = strArray1;
//            HostFilteringOptions filteringOptions = options;
//            string[] strArray3;
//            if (strArray2 == null || strArray2.Length == 0)
//                strArray3 = new string[1] { "*" };
//            else
//                strArray3 = strArray2;
//            filteringOptions.AllowedHosts = (IList<string>)strArray3;
//        }));
//        services.AddSingleton<IOptionsChangeTokenSource<HostFilteringOptions>>((IOptionsChangeTokenSource<HostFilteringOptions>)new ConfigurationChangeTokenSource<HostFilteringOptions>(hostingContext.Configuration));
//        services.AddTransient<IStartupFilter, HostFilteringStartupFilter>();
//    })).UseIIS().UseIISIntegration().UseDefaultServiceProvider((Action<WebHostBuilderContext, ServiceProviderOptions>)((context, options) => options.ValidateScopes = context.HostingEnvironment.IsDevelopment()));
//    return (IWebHostBuilder)hostBuilder;
//}
