using System.Diagnostics;
using System.Threading;
using Game.Abstractions;
using Game.Abstractions.Events;
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
            double tc = 0;
            int fc = 0;

            sw.Restart();
            while (!token.IsCancellationRequested)
            {
                while (_platform.PollEvent(out var ev))
                {
                    if (ev is QuitEvent){
                        _game.Quit();
                        _host.StopAsync();
                    }
                    else if(ev is KeyUpEvent ku)
                        _game.KeyUp(ku.Key, ku.ScanCode);
                    else if(ev is KeyDownEvent kd)
                        _game.KeyDown(kd.Key, kd.ScanCode, kd.IsRepeat);
                }

                dt = sw.Elapsed.TotalSeconds;
                tc += dt;


                sw.Restart();

                _game.Update((float)dt);                
                _game.Draw();
                fc++;

                if (tc > 1)
                {
                    //_logger.LogInformation(fc + "fps");
                    tc -= 1;
                    fc = 0;
                }


                _platform.SwapBuffers();

                _platform.Sleep(1);
            }
        }
    }
}