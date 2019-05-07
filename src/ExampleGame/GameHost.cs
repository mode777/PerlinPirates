using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Game.Abstractions;
using Microsoft.Extensions.Hosting;
using Platform.Sdl2;
using Renderer.Gles2;

namespace ExampleGame
{
    class GameHost : IHostedService
    {
        private CancellationTokenSource _tcs;
        private Task _main;

        public GameHost()
        {
            _tcs = new CancellationTokenSource();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _main = Task.Run(() =>
            {
                var platform = new Sdl2Platform(new Sdl2Configuration());
                platform.CreateWindow();

                var resourceManager = new ResourceManager();

                var renderer = new TestRunner(platform, resourceManager);

                var quit = false;
                var sw = new Stopwatch();

                while (!quit && !_tcs.IsCancellationRequested)
                {
                    sw.Restart();
                    while (platform.PollEvent(out var ev))
                    {
                        if (ev is QuitEvent)
                            quit = true;
                    }

                    renderer.Render();

                    platform.Sleep((uint)Math.Max(0, 17 - sw.ElapsedMilliseconds));
                }

            }, cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _tcs.Cancel();
            await _main;
        }
    }
}
