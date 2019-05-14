using System;

namespace Game.Abstractions
{
    public interface IPlatform : IDisposable
    {
        IWindow Init();
        IntPtr GetGlProcAddress(string name);
        void SwapBuffers();
        bool PollEvent(out PlatformEvent @event);
        void Sleep(uint ms);
    }
}
