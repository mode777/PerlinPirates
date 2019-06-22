using System;
using System.Drawing;
using Game.Abstractions;
using Game.Abstractions.Constants;
using Game.Abstractions.Events;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SDL2;

namespace Platform.Sdl2
{
    public class Sdl2Platform : IPlatform, IGlLoader
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

            _logger.LogDebug($"Creating a window. Width {_config.Width}, Height: {_config.Height}, Title: {_config.Title}");
            _window = new Sdl2Window(_config.Title, _config.Width, _config.Height);

            WindowSize = new Size(_config.Width, _config.Height);

            _logger.LogDebug($"Creating a GLContext...");
            _context = new Sdl2GlContext(_window);
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

        public Size WindowSize { get; }

        public bool PollEvent(out PlatformEvent @event)
        {
            var more = SDL.SDL_PollEvent(out SDL.SDL_Event ev) != 0;

            @event = null;

            if(ev.type != SDL.SDL_EventType.SDL_FIRSTEVENT)
                _logger.LogDebug("Event: " + ev.type);
            
            switch (ev.type)
            {
                case SDL.SDL_EventType.SDL_FIRSTEVENT:
                    break;
                case SDL.SDL_EventType.SDL_QUIT:
                    @event = new QuitEvent();
                    break;
                case SDL.SDL_EventType.SDL_APP_TERMINATING:
                    break;
                case SDL.SDL_EventType.SDL_APP_LOWMEMORY:
                    break;
                case SDL.SDL_EventType.SDL_APP_WILLENTERBACKGROUND:
                    break;
                case SDL.SDL_EventType.SDL_APP_DIDENTERBACKGROUND:
                    break;
                case SDL.SDL_EventType.SDL_APP_WILLENTERFOREGROUND:
                    break;
                case SDL.SDL_EventType.SDL_APP_DIDENTERFOREGROUND:
                    break;
                case SDL.SDL_EventType.SDL_DISPLAYEVENT:
                    break;
                case SDL.SDL_EventType.SDL_WINDOWEVENT:
                    break;
                case SDL.SDL_EventType.SDL_SYSWMEVENT:
                    break;
                case SDL.SDL_EventType.SDL_KEYDOWN:
                    @event = new KeyDownEvent
                    {
                        Key = (KeyCode) ev.key.keysym.sym,
                        ScanCode = (ScanCode) ev.key.keysym.scancode,
                        IsRepeat = Convert.ToBoolean(ev.key.repeat),
                        Modifier = (KeyModifier) ev.key.keysym.mod
                    };
                    break;
                case SDL.SDL_EventType.SDL_KEYUP:
                    @event = new KeyDownEvent
                    {
                        Key = (KeyCode)ev.key.keysym.sym,
                        ScanCode = (ScanCode)ev.key.keysym.scancode,
                        IsRepeat = Convert.ToBoolean(ev.key.repeat),
                        Modifier = (KeyModifier)ev.key.keysym.mod
                    };
                    break;
                case SDL.SDL_EventType.SDL_TEXTEDITING:
                    break;
                case SDL.SDL_EventType.SDL_TEXTINPUT:
                    break;
                case SDL.SDL_EventType.SDL_KEYMAPCHANGED:
                    break;
                case SDL.SDL_EventType.SDL_MOUSEMOTION:
                    break;
                case SDL.SDL_EventType.SDL_MOUSEBUTTONDOWN:
                    break;
                case SDL.SDL_EventType.SDL_MOUSEBUTTONUP:
                    break;
                case SDL.SDL_EventType.SDL_MOUSEWHEEL:
                    break;
                case SDL.SDL_EventType.SDL_JOYAXISMOTION:
                    break;
                case SDL.SDL_EventType.SDL_JOYBALLMOTION:
                    break;
                case SDL.SDL_EventType.SDL_JOYHATMOTION:
                    break;
                case SDL.SDL_EventType.SDL_JOYBUTTONDOWN:
                    break;
                case SDL.SDL_EventType.SDL_JOYBUTTONUP:
                    break;
                case SDL.SDL_EventType.SDL_JOYDEVICEADDED:
                    break;
                case SDL.SDL_EventType.SDL_JOYDEVICEREMOVED:
                    break;
                case SDL.SDL_EventType.SDL_CONTROLLERAXISMOTION:
                    break;
                case SDL.SDL_EventType.SDL_CONTROLLERBUTTONDOWN:
                    break;
                case SDL.SDL_EventType.SDL_CONTROLLERBUTTONUP:
                    break;
                case SDL.SDL_EventType.SDL_CONTROLLERDEVICEADDED:
                    break;
                case SDL.SDL_EventType.SDL_CONTROLLERDEVICEREMOVED:
                    break;
                case SDL.SDL_EventType.SDL_CONTROLLERDEVICEREMAPPED:
                    break;
                case SDL.SDL_EventType.SDL_FINGERDOWN:
                    break;
                case SDL.SDL_EventType.SDL_FINGERUP:
                    break;
                case SDL.SDL_EventType.SDL_FINGERMOTION:
                    break;
                case SDL.SDL_EventType.SDL_DOLLARGESTURE:
                    break;
                case SDL.SDL_EventType.SDL_DOLLARRECORD:
                    break;
                case SDL.SDL_EventType.SDL_MULTIGESTURE:
                    break;
                case SDL.SDL_EventType.SDL_CLIPBOARDUPDATE:
                    break;
                case SDL.SDL_EventType.SDL_DROPFILE:
                    break;
                case SDL.SDL_EventType.SDL_DROPTEXT:
                    break;
                case SDL.SDL_EventType.SDL_DROPBEGIN:
                    break;
                case SDL.SDL_EventType.SDL_DROPCOMPLETE:
                    break;
                case SDL.SDL_EventType.SDL_AUDIODEVICEADDED:
                    break;
                case SDL.SDL_EventType.SDL_AUDIODEVICEREMOVED:
                    break;
                case SDL.SDL_EventType.SDL_SENSORUPDATE:
                    break;
                case SDL.SDL_EventType.SDL_RENDER_TARGETS_RESET:
                    break;
                case SDL.SDL_EventType.SDL_RENDER_DEVICE_RESET:
                    break;
                case SDL.SDL_EventType.SDL_USEREVENT:
                    break;
                case SDL.SDL_EventType.SDL_LASTEVENT:
                    break;
                default:
                    break;
            }

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
