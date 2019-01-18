using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleGame.Ecs
{
    public class System : ISystem
    {
        private readonly Queue<(Guid, string)> _messageQueue = new Queue<(Guid, string)>();



        public void EnqueueMessage(Guid entity, string message)
        {
            _messageQueue.Enqueue((entity, message));
        }

        protected bool DequeueMessage(out (Guid, string) message)
        {
            return _messageQueue.TryDequeue(out message);
        }

        protected void PublishMessage(Guid entity, string message)
        {

        }
        
        public virtual string[] SubscribeTo()
        {
            return new string[0];
        }

        public virtual void Update()
        {
        }
    }
}
