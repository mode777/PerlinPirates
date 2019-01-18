using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleGame.Ecs
{
    public interface ISystem
    {
        void EnqueueMessage(Guid entity, string message);
        void Update();
        string[] SubscribeTo();
    }
}
