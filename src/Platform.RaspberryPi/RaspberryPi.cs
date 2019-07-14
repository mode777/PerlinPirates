using System;
using System.Drawing;
using System.Runtime.InteropServices;
using Game.Abstractions;
using Microsoft.Extensions.Logging;

namespace Platform.RaspberryPi
{
    public class RaspberryPi : IPlatform, IWindow
    {
        private readonly ILogger<IPlatform> _logger;
        private IntPtr glesHandle;
        private IntPtr display;
        private IntPtr surface;

        public RaspberryPi(ILogger<IPlatform> logger)
        {
            _logger = logger;
        }

        public void CreateGlContext()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IWindow Init()
        {
            int[] attributeList = new[]
            {
                EGL.RED_SIZE, 8,
                EGL.GREEN_SIZE, 8,
                EGL.BLUE_SIZE, 8,
                EGL.ALPHA_SIZE, 8,
                EGL.SURFACE_TYPE, EGL.WINDOW_BIT,
                EGL.NONE
            };
            
            _logger.LogDebug("Initialize BCM host.");
            BcmHost.bcm_host_init();

            _logger.LogDebug("Loading libGLESv2");
            glesHandle = EGL.dlopen("libGLESv2.so", 2);

            //_logger.LogDebug("Loading libEGL.so");
            //var eglHandle = EGL.dlopen("libEGL.so", 2);
            //_logger.LogDebug(EGL.dlerror());

            //_logger.LogDebug("Get eglProcAddress func ptr");
            //var eglPtr = EGL.dlsym(eglHandle, "eglGetProcAddress");
            //_logger.LogDebug(eglPtr.ToString());
            //_logger.LogDebug("error:" + EGL.dlerror());

            display = EGL.GetDisplay((IntPtr)0);
            _logger.LogDebug("Display: " + display);

            // initialize the EGL display connection
            int min = 0;
            int maj = 0;

            var result = EGL.Initialize(display, ref min, ref maj);
            _logger.LogDebug($"Initialized EGL Version {min}.{maj}");

            IntPtr[] configs = new IntPtr[1];
            IntPtr context = IntPtr.Zero;

            using (var configHandle = new PinnedGCHandle(attributeList))
            using (var configsHandle = new PinnedGCHandle(configs))
            {
                int numCfg = 0;

                // get an appropriate EGL frame buffer configuration
                var resultConfig = EGL.ChooseConfig(display, configHandle.Pointer, configsHandle.Pointer, 1, ref numCfg);
                _logger.LogDebug($"Choose config result {resultConfig}, {configs[0]}, total configs: {numCfg}");
                context = EGL.CreateContext(display, configs[0], (IntPtr)EGL.NO_CONTEXT, IntPtr.Zero);
                // create an EGL rendering context
                _logger.LogDebug($"Create context result {context}");
            }
            
            // create an EGL window surface
            var success = BcmHost.graphics_get_display_size(0, out var width, out var height);
            _logger.LogDebug($"Displaysize is: {width}, {height}");


            var dispman_display = BcmHost.vc_dispmanx_display_open(0 /* LCD */);
            _logger.LogDebug($"Dispman display: {dispman_display}");
            var dispman_update = BcmHost.vc_dispmanx_update_start(0);
            _logger.LogDebug($"Dispman update: {dispman_update}");

            var dst_rect = new BcmHost.VC_RECT_T
            {
                x = 0,
                y = 0,
                width = width,
                height = height
            };

            WindowSize = new Size(width, height);

            var src_rect = new BcmHost.VC_RECT_T
            {
                x = 0,
                y = 0,
                width = width << 16,
                height = height << 16
            };

            uint dispman_element;
            
            using (var dest_rectHandle = new PinnedGCHandle(dst_rect))
            using (var src_rectHandle = new PinnedGCHandle(src_rect))
            {
                dispman_element = BcmHost.vc_dispmanx_element_add(
                    dispman_update,
                    dispman_display,
                    0/*layer*/,
                    dest_rectHandle.Pointer,
                    0/*src*/,
                    src_rectHandle.Pointer,
                    0 /*DISPMANX_PROTECTION_NONE*/,
                    IntPtr.Zero /*alpha*/,
                    IntPtr.Zero /*clamp*/,
                    0/*transform*/);
                _logger.LogDebug($"Dispmanx element {dispman_element}");

                var nativeWindow = new BcmHost.EGL_DISPMANX_WINDOW_T
                {
                    element = dispman_element,
                    width = width,
                    height = height
                };
                var submitRes = BcmHost.vc_dispmanx_update_submit_sync(dispman_update);
                _logger.LogDebug($"Submited dispmanx update: {submitRes}");

                surface = EGL.CreateWindowSurface(display, configs[0], ref nativeWindow, IntPtr.Zero);
                _logger.LogDebug($"Created surface {surface}");

                // connect the context to the surface
                result = EGL.MakeCurrent(display, surface, surface, context);
                _logger.LogDebug($"Make current result {result}");
            }
            
            _logger.LogDebug("Testing EGL proc addr");
            var ptr = EGL.GetProcAddress("glEnable");
            _logger.LogDebug(ptr.ToString());
            _logger.LogDebug(EGL.GetError().ToString());

            _logger.LogDebug("DLsymtest:" + EGL.dlsym(glesHandle, "glEnable"));
            
            return this;
        }

        public IntPtr GetGlProcAddress(string name)
        {
            return EGL.dlsym(glesHandle, name);
        }

        public bool PollEvent(out PlatformEvent @event)
        {
            @event = null;
            return false;
            //throw new NotImplementedException();
        }

        public void Sleep(uint ms)
        {
            //throw new NotImplementedException();
        }

        public Size WindowSize { get; private set; }
        public Point GetMousePosition()
        {
            throw new NotImplementedException();
        }

        public void SetMousePosition(Point p)
        {
            throw new NotImplementedException();
        }

        public void SwapBuffers()
        {
            EGL.SwapBuffers(display, surface);
        }
    }
}