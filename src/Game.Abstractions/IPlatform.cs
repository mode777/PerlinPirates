using System;

namespace Game.Abstractions
{
    public interface IPlatform : IDisposable
    {
        void CreateWindow();
        void CreateGlContext();
        IntPtr GetGlProcAddress(string name);
        void SwapBuffers();
        bool PollEvent(out PlatformEvent @event);
        void Sleep(uint ms);
    }
}
