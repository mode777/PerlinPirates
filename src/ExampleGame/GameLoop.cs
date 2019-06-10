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
        private readonly IGameComponent _game;
        private readonly ILogger<IGameLoop> _logger;

        public GameLoop(IHost host, IPlatform platform, IGameComponent game, ILogger<IGameLoop> logger)
        {
            _host = host;
            _platform = platform;
            _game = game;
            _logger = logger;
        }

        public void Run(CancellationToken token)
        {
            _game.Load();

            var sw = new Stopwatch();
            double dt = 0;

            while (!token.IsCancellationRequested)
            {
                sw.Restart();
                while (_platform.PollEvent(out var ev))
                {
                    if (ev is QuitEvent){
                        _game.Quit();
                        _host.StopAsync();
                    }
                }

                dt = sw.Elapsed.TotalSeconds;
                sw.Restart();

                _game.Update((float)dt);                
                _game.Draw();

                _platform.SwapBuffers();

                _platform.Sleep(1);
            }
        }
    }
}