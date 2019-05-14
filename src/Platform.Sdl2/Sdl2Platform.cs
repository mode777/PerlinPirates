using System;
using Game.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SDL2;

namespace Platform.Sdl2
{
    public class Sdl2Platform : IPlatform
    {
        private readonly ILogger<IPlatform> _logger;
        private readonly Sdl2Options _config;
        private Sdl2Window _window;
        private Sdl2GlContext _context;

        public Sdl2Platform(IOptions<Sdl2Options> configAccessor, ILogger<IPlatform> logger)
        {
            _logger = logger;
            _config = configAccessor.Value;
            var flags = SDL.SDL_INIT_AUDIO | SDL.SDL_INIT_GAMECONTROLLER | SDL.SDL_INIT_JOYSTICK | SDL.SDL_INIT_VIDEO;

            _logger.LogDebug($"Init SDL with flags {flags.ToString()}");

            if (SDL.SDL_Init(flags) < 0)
            {
                throw new Sdl2Exception("Initialization error");
            }

            SetGlParameters();
        }
        
        public IWindow Init()
        {
            _logger.LogDebug($"Creating a window. Width {_config.Width}, Height: {_config.Height}, Title: {_config.Title}");
            _window = new Sdl2Window(_config.Title, _config.Width, _config.Height);
            _logger.LogDebug($"Creating a GLContext...");
            _context = new Sdl2GlContext(_window);

            return _window;
        }

        public IntPtr GetGlProcAddress(string name)
        {
            var addr = _context.GetProcAddress(name);
            _logger.LogDebug($"GLProc {name} is located at {addr}.");
            return addr;
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

        public void Dispose()
        {
            _window?.Dispose();
            _context?.Dispose();
        }
    }
}
