using System;

namespace Game.Abstractions
{
    public interface IGlLoader
    {
        IntPtr GetGlProcAddress(string name);
    }
}