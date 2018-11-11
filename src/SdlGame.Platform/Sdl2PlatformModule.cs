using Microsoft.Extensions.Configuration;
using SDL2;
using SdlGame.Shared;
using System;

namespace SdlGame.Platform.Sdl2
{
    public class Sdl2PlatformModule : IGameModule
    {
        private readonly PlatformConfiguration _config;
        private readonly IEventPublisher _publisher;
        private Sdl2Window _window;
        private Sdl2GlContext _context;

        public Sdl2PlatformModule(IConfiguration config, IEventPublisher publisher)
        {
            _config = config.GetSection("platform").Get<PlatformConfiguration>();
            _publisher = publisher;

            Init();
        }

        public void Update()
        {
        }

        private void Init()
        {
            if (SDL.SDL_Init(SDL.SDL_INIT_AUDIO | SDL.SDL_INIT_GAMECONTROLLER | SDL.SDL_INIT_JOYSTICK | SDL.SDL_INIT_VIDEO) < 0)
            {
                throw new Sdl2Exception("Initialization error");
            }
            else
            {
                SetGlVersion();

                _window = new Sdl2Window("Test", _config.Width, _config.Height);

                _context = new Sdl2GlContext(_window);
            }
        }

        private void SetGlVersion()
        {
            SDL.SDL_GL_SetAttribute(SDL.SDL_GLattr.SDL_GL_CONTEXT_MAJOR_VERSION, _config.GlMajor);
            SDL.SDL_GL_SetAttribute(SDL.SDL_GLattr.SDL_GL_CONTEXT_MINOR_VERSION, _config.GlMinor);

            switch (_config.GlProfile.ToLower())
            {
                case "es":
                    SDL.SDL_GL_SetAttribute(SDL.SDL_GLattr.SDL_GL_CONTEXT_PROFILE_MASK, (int)SDL.SDL_GLprofile.SDL_GL_CONTEXT_PROFILE_ES);
                    break;
                case "compatibility":
                    SDL.SDL_GL_SetAttribute(SDL.SDL_GLattr.SDL_GL_CONTEXT_PROFILE_MASK, (int)SDL.SDL_GLprofile.SDL_GL_CONTEXT_PROFILE_COMPATIBILITY);
                    break;
                default:
                    SDL.SDL_GL_SetAttribute(SDL.SDL_GLattr.SDL_GL_CONTEXT_PROFILE_MASK, (int)SDL.SDL_GLprofile.SDL_GL_CONTEXT_PROFILE_CORE);
                    break;
            }
        }
    }
}
