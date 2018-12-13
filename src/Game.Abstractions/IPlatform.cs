using System;

namespace Game.Abstractions
{
    public interface IPlatform
    {
        IntPtr GetGlProcAddress(string name);
        void SwapBuffers();
        void Sleep(uint ms);
        bool PollEvent(out PlatformEvent @event);
    }
}
