using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Game.Abstractions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Platform.Sdl2;
using Renderer.Gles2;

namespace ExampleGame
{
    class GameHost : IHostedService
    {
        private readonly IHost _host;
        private readonly IPlatform _platform;
        private readonly IRenderer _renderer;
        private readonly ILogger<GameHost> _logger;
        private CancellationTokenSource _tcs;
        private Task _main;

        public GameHost(IHost host, IPlatform platform, IRenderer renderer, ILogger<GameHost> logger)
        {
            _host = host;
            _platform = platform;
            _renderer = renderer;
            _logger = logger;
            _tcs = new CancellationTokenSource();

        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _main = Task.Run(() =>
            {
                _logger.LogInformation($"Starting GameHost using platform '{_platform.GetType().Name}'.");
                _logger.LogDebug($"Creating window...");
                using (var window = _platform.Init())
                {
                    var resourceManager = new ResourceManager();

                    _logger.LogDebug($"Creating renderer...");
                    _renderer.Initialize();

                    var sw = new Stopwatch();

                    while (!_tcs.IsCancellationRequested)
                    {
                        sw.Restart();
                        while (_platform.PollEvent(out var ev))
                        {
                            if (ev is QuitEvent)
                                _host.StopAsync();
                        }

                        _renderer.Render();
                        _platform.SwapBuffers();

                        _platform.Sleep((uint)Math.Max(0, 17 - sw.ElapsedMilliseconds));
                    }
                    _logger.LogInformation($"Closing window...");
                }
            }, cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _tcs.Cancel();
            _logger.LogInformation($"Shutting down GameHost...");
            await _main;
        }
    }
}
