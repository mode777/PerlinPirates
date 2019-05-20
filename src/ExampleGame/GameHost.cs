using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Game.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Platform.Sdl2;
using Renderer.Gles2;

namespace ExampleGame
{
    class GameHost : IHostedService
    {
        private readonly ILogger<GameHost> _logger;
        private readonly IServiceScopeFactory _scopeFactory;
        private CancellationTokenSource _tcs;
        private Task _main;

        public GameHost(ILogger<GameHost> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
            _tcs = new CancellationTokenSource();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Starting GameHost...");
            _main = Task.Run(() =>
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var loop = scope.ServiceProvider.GetRequiredService<IGameLoop>();
                    loop.Run(_tcs.Token);
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
