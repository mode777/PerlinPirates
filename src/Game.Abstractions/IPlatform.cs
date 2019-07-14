using System;
using System.Drawing;

namespace Game.Abstractions
{
    public interface IPlatform : IDisposable
    {
        void SwapBuffers();
        bool PollEvent(out PlatformEvent @event);
        void Sleep(uint ms);
        Size WindowSize { get; }
        Point GetMousePosition();
        void SetMousePosition(Point p);
    }
}
