using System;
using System.Collections.Generic;
using System.Linq;
using Game.Abstractions;
using Game.Abstractions.Constants;
using Microsoft.Extensions.Options;

namespace ExampleGame
{
    public class SceneManager : IGameComponent
    {
        private readonly IGameComponent[] _components;

        public SceneManager(IServiceProvider provider, IOptions<SceneManagerConfiguration> config)
        {
            _components = config.Value.Types.Select(x => (IGameComponent) provider.GetService(x)).ToArray();
        }

        public void Load()
        {
            foreach (var component in _components)
            {
                component.Load();
            }
        }

        public void Quit()
        {
            foreach (var component in _components.Reverse())
            {
                component.Quit();
            }
        }

        public void Draw()
        {
            foreach (var component in _components)
            {
                component.Draw();
            }
        }

        public void KeyDown(KeyCode key, ScanCode code, bool isRepeat)
        {
            foreach (var component in _components)
            {
                component.KeyDown(key, code, isRepeat);
            }
        }

        public void KeyUp(KeyCode key, ScanCode code)
        {
            foreach (var component in _components)
            {
                component.KeyUp(key, code);
            }
        }

        public void Update(float delta)
        {
            foreach (var component in _components)
            {
                component.Update(delta);
            }
        }
    }
}