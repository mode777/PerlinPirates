using System.Collections.Generic;

namespace ECS
{
    public class SystemManager
    {
        private readonly IEnumerable<ISystem> _system;

        public SystemManager(IEnumerable<ISystem> system)
        {
            _system = system;
        }

        public void Update()
        {
            foreach (var system in _system)
            {
                system.Update();
            }
        }
    }
}