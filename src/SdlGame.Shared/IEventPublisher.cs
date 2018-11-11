using System;
using System.Collections.Generic;
using System.Text;

namespace SdlGame.Shared
{
    public interface IEventPublisher
    {
        void Publish<TEvent>(TEvent sampleEvent);
        IObservable<TEvent> GetEvent<TEvent>();
    }
}
