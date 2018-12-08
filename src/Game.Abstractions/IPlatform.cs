using System;

namespace Game.Abstractions
{
    public interface IPlatform
    {
        IntPtr GetGlProcAddress(string name);
        void SwapBuffers();
    }
}
