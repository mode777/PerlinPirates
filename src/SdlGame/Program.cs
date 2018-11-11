using Microsoft.Extensions.Configuration;
using SdlGame.Platform.Sdl2;
using System;
using System.IO;
using System.Threading;

namespace SdlGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var configuration = builder.Build();
            var publisher = new EventPublisher();

            var renderer = new Sdl2PlatformModule(configuration, publisher);

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
