using SDL2;
using System;
using System.Collections.Generic;
using System.Text;

namespace SdlGame.Platform.Sdl2
{
    public class Sdl2Exception : Exception
    {
        public Sdl2Exception(string message)
            :base($"{message}. SDL Error: {SDL.SDL_GetError()}")
        {
        }
    }
}
