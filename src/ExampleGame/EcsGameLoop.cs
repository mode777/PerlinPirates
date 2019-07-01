using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Game.Abstractions;
using Game.Abstractions.Events;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace ExampleGame
{
    public class EcsGameLoop : IGameLoop
    {
        private readonly IPlatform _platform;
        private readonly IServiceProvider _provider;
        private readonly IHost _host;
        private readonly InputState _input;

        private readonly List<IHandlesUpdate> _updates = new List<IHandlesUpdate>();
        private readonly List<IHandlesLoad> _loaders = new List<IHandlesLoad>();
        private readonly List<IHandlesDraw> _drawers = new List<IHandlesDraw>();
        private readonly Dictionary<object, int> _updateEveryNth = new Dictionary<object, int>();

        public EcsGameLoop(IPlatform platform, IOptions<EcsGameLoopOptions> options, IServiceProvider provider,
            IHost host, InputState input)
        {
            _platform = platform;
            _provider = provider;
            _host = host;
            _input = input;

            foreach (var config in options.Value.Systems)
            {
                var system = provider.GetService(config.SystemType);
                _updateEveryNth[system] = config.UpdateEveryNth;

                if (system == null)
                    throw new NullReferenceException($"System was not registered: {config}");

                if (system is IHandlesUpdate update)
                    _updates.Add(update);

                if (system is IHandlesLoad loader)
                    _loaders.Add(loader);

                if (system is IHandlesDraw drawer)
                    _drawers.Add(drawer);
            }
        }

        public void Run(CancellationToken token)
        {
            var updateCount = 0;

            foreach (var loader in _loaders)
            {
                loader.Load();
            }

            var sw = new Stopwatch();
            sw.Restart();
            
            while (!token.IsCancellationRequested)
            {
                while (_platform.PollEvent(out var ev))
                {
                    if (ev is QuitEvent)
                    {
                        //_dispatcher.DispatchQuit();
                        _host.StopAsync();
                    }
                    else if (ev is KeyUpEvent ku)
                        _input.OnKeyUp(ku);
                    else if (ev is KeyDownEvent kd)
                        _input.OnKeyDown(kd);
                }

                var dt = sw.Elapsed.TotalSeconds;
                
                sw.Restart();

                foreach (var handlesUpdate in _updates)
                {
                    if (updateCount % _updateEveryNth[handlesUpdate] == 0)
                    {
                        handlesUpdate.Update((float) dt);
                    }

                }

                foreach (var handlesDraw in _drawers)
                {
                    handlesDraw.Draw();
                }

                _platform.SwapBuffers();
                _platform.Sleep(0);
                updateCount++;
            }
        }
    }
}

    