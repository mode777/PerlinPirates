using SDL2;
using System;
using System.Collections.Generic;
using System.Text;

namespace SdlGame.Platform.Sdl2
{
    internal class Sdl2GlContext : IDisposable
    {
        private readonly IntPtr _handle;

        public Sdl2GlContext(Sdl2Window window)
        {
            _handle = SDL.SDL_GL_CreateContext(window.Handle);

            if (_handle == IntPtr.Zero)
            {
                throw new Sdl2Exception("Unable to initialize GL Context");
            }
        }

        ~Sdl2GlContext()
        {
            Dispose(false);
        }

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
        }
    }
}
