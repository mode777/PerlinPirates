using System;

namespace Game.Abstractions
{
    public interface IPlatform : IDisposable
    {
        void SwapBuffers();
        bool PollEvent(out PlatformEvent @event);
        void Sleep(uint ms);
    }
}
