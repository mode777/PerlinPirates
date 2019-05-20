using System.Diagnostics;
using System.Threading;
using Game.Abstractions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ExampleGame
{
    public class GameLoop : IGameLoop
    {
        private readonly IHost _host;
        private readonly IPlatform _platform;
        private readonly IGame _game;
        private readonly ILogger<IGameLoop> _logger;

        public GameLoop(IHost host, IPlatform platform, IGame game, ILogger<IGameLoop> logger)
        {
            _host = host;
            _platform = platform;
            _game = game;
            _logger = logger;
        }

        public void Run(CancellationToken token)
        {
            _game.Initialize();

            var sw = new Stopwatch();

            while (!token.IsCancellationRequested)
            {
                sw.Restart();
                while (_platform.PollEvent(out var ev))
                {
                    if (ev is QuitEvent)
                        _host.StopAsync();
                }

                _game.Render();
                _platform.SwapBuffers();
            }
        }
    }
}