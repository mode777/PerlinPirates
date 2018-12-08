using System;
using SDL2;

namespace Platform.Sdl2
{
    public class Sdl2Exception : Exception
    {
        public Sdl2Exception(string message)
            :base($"{message}. SDL Error: {SDL.SDL_GetError()}")
        {
        }
    }
}
