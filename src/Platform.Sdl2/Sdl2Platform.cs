using System;
using Game.Abstractions;
using SDL2;

namespace Platform.Sdl2
{
    public class Sdl2Platform : IPlatform
    {
        private readonly Sdl2Configuration _config;
        private readonly Sdl2Window _window;
        private readonly Sdl2GlContext _context;

        public Sdl2Platform(Sdl2Configuration config)
        {
            _config = config;

            if (SDL.SDL_Init(SDL.SDL_INIT_AUDIO | SDL.SDL_INIT_GAMECONTROLLER | SDL.SDL_INIT_JOYSTICK | SDL.SDL_INIT_VIDEO) < 0)
            {
                throw new Sdl2Exception("Initialization error");
            }

            SetGlParameters();

            _window = new Sdl2Window(_config.Title, _config.Width, _config.Height);
            _context = new Sdl2GlContext(_window);
        }

        public IntPtr GetGlProcAddress(string name)
        {
            return _context.GetProcAddress(name);
        }

        public void SwapBuffers()
        {
            _window.SwapBuffers();
        }

        public void Sleep(uint ms)
        {
            SDL.SDL_Delay(ms);
        }

        public bool PollEvent(out PlatformEvent @event)
        {
            var more = SDL.SDL_PollEvent(out SDL.SDL_Event ev) != 0;

            if(ev.type == SDL.SDL_EventType.SDL_QUIT)
                @event = new QuitEvent();
            else
                @event = new PlatformEvent();

            return more;
        }

        private void SetGlParameters()
        {
            SDL.SDL_GL_SetAttribute(SDL.SDL_GLattr.SDL_GL_DOUBLEBUFFER, 1);
            SDL.SDL_GL_SetAttribute(SDL.SDL_GLattr.SDL_GL_CONTEXT_MAJOR_VERSION, 2);
            SDL.SDL_GL_SetAttribute(SDL.SDL_GLattr.SDL_GL_CONTEXT_MINOR_VERSION, 0);
            SDL.SDL_GL_SetAttribute(SDL.SDL_GLattr.SDL_GL_CONTEXT_PROFILE_MASK, (int)SDL.SDL_GLprofile.SDL_GL_CONTEXT_PROFILE_ES);
        }

    }
}
