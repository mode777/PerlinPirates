using System;
using System.Collections.Generic;
using System.Text;
using SDL2;

namespace SdlGame.Platform.Sdl2
{
    internal class Sdl2Window : IDisposable
    {
        private readonly IntPtr _handle;

        public Sdl2Window(string title, int w, int h)
        {
            _handle = SDL.SDL_CreateWindow(title, 
                SDL.SDL_WINDOWPOS_CENTERED, 
                SDL.SDL_WINDOWPOS_CENTERED, 
                w, 
                h, 
                SDL.SDL_WindowFlags.SDL_WINDOW_OPENGL);

            if(_handle == IntPtr.Zero)
            {
                throw new Sdl2Exception("Unable to initialize window");
            }
        }

        ~Sdl2Window()
        {
            Dispose(false);
        }

        internal IntPtr Handle => _handle;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
            }

            SDL.SDL_DestroyWindow(_handle);
        }
    }
}
