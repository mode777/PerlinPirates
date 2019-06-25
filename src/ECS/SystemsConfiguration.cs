using System;
using System.Collections.Generic;
using System.Text;

namespace ECS
{
    public class SystemsConfiguration
    {
        private readonly List<Type> _systems;

        public IEnumerable<Type> Systems => _systems;

        public SystemsConfiguration AddSystem<T>()
        {
            _systems.Add(typeof(T));

            return this;
        }

    }
}
