using System;
using System.Collections.Generic;
using System.Text;
using Game.Abstractions.Events;

namespace Game.Abstractions
{
    public interface IEventDispatcher
    {
        void DispatchLoad();
        void DispatchQuit();
        void DispatchDraw();
        void DispatchKeyDown(KeyDownEvent ev);
        void DispatchKeyUp(KeyUpEvent ev);
        void DispatchUpdate(float delta);
    }

    public interface IEventSource
    {
        event Action Load;
        event Action Quit;
        event Action Draw;
        event Action<KeyDownEvent> KeyDown;
        event Action<KeyUpEvent> KeyUp;
        event Action<float> Update;
    }

    public class EventsProvider : IEventDispatcher, IEventSource
    {
        public void DispatchLoad()
        {
            Load?.Invoke();
        }

        public void DispatchQuit()
        {
            Quit?.Invoke();
        }

        public void DispatchDraw()
        {
            Draw?.Invoke();
        }

        public void DispatchKeyDown(KeyDownEvent ev)
        {
            KeyDown?.Invoke(ev);
        }

        public void DispatchKeyUp(KeyUpEvent ev)
        {
            KeyUp?.Invoke(ev);
        }

        public void DispatchUpdate(float delta)
        {
            Update?.Invoke(delta);
        }

        public event Action Load;
        public event Action Quit;
        public event Action Draw;
        public event Action<KeyDownEvent> KeyDown;
        public event Action<KeyUpEvent> KeyUp;
        public event Action<float> Update;
    }
}
