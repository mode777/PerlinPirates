using System;
using System.Reflection;
using SDL2;

namespace Platform.Sdl2
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

        public IntPtr GetProcAddress(string name)
        {
            var ptr = SDL.SDL_GL_GetProcAddress(name);

            if (ptr == IntPtr.Zero)
            {
                throw new NotSupportedException(name);
            }

            return ptr;
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
