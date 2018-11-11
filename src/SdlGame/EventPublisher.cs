using SdlGame.Shared;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;

namespace SdlGame
{
    public class EventPublisher : IEventPublisher
    {
        private readonly ConcurrentDictionary<Type, object> subjects
            = new ConcurrentDictionary<Type, object>();

        public IObservable<TEvent> GetEvent<TEvent>()
        {
            var subject =
                (ISubject<TEvent>)subjects.GetOrAdd(typeof(TEvent),
                t => new Subject<TEvent>());
            return subject.AsObservable();
        }

        public void Publish<TEvent>(TEvent sampleEvent)
        {
            object subject;
            if (subjects.TryGetValue(typeof(TEvent), out subject))
            {
                ((ISubject<TEvent>)subject)
                    .OnNext(sampleEvent);
            }
        }
    }
}
