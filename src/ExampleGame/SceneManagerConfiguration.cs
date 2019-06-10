using System;
using System.Collections.Generic;
using Game.Abstractions;

namespace ExampleGame
{
    public class SceneManagerConfiguration
    {
        private readonly List<Type> _types = new List<Type>();

        public IEnumerable<Type> Types => _types;

        public void AddComponent<T>() where T : IGameComponent
        {
            _types.Add(typeof(T));
        }
    }
}