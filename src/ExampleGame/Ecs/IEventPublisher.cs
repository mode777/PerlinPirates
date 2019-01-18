using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleGame.Ecs
{
    public interface IEventPublisher
    {
        void Subscribe(string message, ISystem system);
        void Publish(Guid entity, string message);
    }
}
