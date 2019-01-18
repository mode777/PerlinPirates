using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleGame.Ecs
{
    public class EventPublisher : IEventPublisher
    {
        private readonly Dictionary<string, List<ISystem>> _subscribers 
            = new Dictionary<string, List<ISystem>>(256);

        public void Publish(Guid entity, string message)
        {
            if(_subscribers.TryGetValue(message, out var systems))
            {
                foreach (var system in systems)
                {
                    system.EnqueueMessage(entity, message);
                }
            }
        }

        public void Subscribe(string message, ISystem system)
        {

        }
    }
}
