using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Platform.RaspberryPi
{
    internal static class EGL
    {
        public const int BUFFER_SIZE = 0x3020;
        public const int ALPHA_SIZE = 0x3021;
        public const int BLUE_SIZE = 0x3022;
        public const int GREEN_SIZE = 0x3023;
        public const int RED_SIZE = 0x3024;
        public const int DEPTH_SIZE = 0x3025;
        public const int STENCIL_SIZE = 0x3026;
        public const int CONFIG_CAVEAT = 0x3027;
        public const int CONFIG_ID = 0x3028;
        public const int LEVEL = 0x3029;
        public const int MAX_PBUFFER_HEIGHT = 0x302A;
        public const int MAX_PBUFFER_PIXELS = 0x302B;
        public const int MAX_PBUFFER_WIDTH = 0x302C;
        public const int NATIVE_RENDERABLE = 0x302D;
        public const int NATIVE_VISUAL_ID = 0x302E;
        public const int NATIVE_VISUAL_TYPE = 0x302F;
        public const int SAMPLES = 0x3031;
        public const int SAMPLE_BUFFERS = 0x3032;
        public const int SURFACE_TYPE = 0x3033;
        public const int TRANSPARENT_TYPE = 0x3034;
        public const int TRANSPARENT_BLUE_VALUE = 0x3035;
        public const int TRANSPARENT_GREEN_VALUE = 0x3036;
        public const int TRANSPARENT_RED_VALUE = 0x3037;
        public const int NONE = 0x3038;
        public const int BIND_TO_TEXTURE_RGB = 0x3039;
        public const int BIND_TO_TEXTURE_RGBA = 0x303A;
        public const int MIN_SWAP_INTERVAL = 0x303B;
        public const int MAX_SWAP_INTERVAL = 0x303C;
        public const int LUMINANCE_SIZE = 0x303D;
        public const int ALPHA_MASK_SIZE = 0x303E;
        public const int COLOR_BUFFER_TYPE = 0x303F;
        public const int RENDERABLE_TYPE = 0x3040;
        public const int MATCH_NATIVE_PIXMAP = 0x3041;
        public const int CONFORMANT = 0x3042;
        public const int WINDOW_BIT = 0x0004;
        public const int NO_CONTEXT = 0;

        [DllImport("dl")]
        public static extern IntPtr dlopen(string filename, int flags);

        [DllImport("dl")]
        public static extern IntPtr dlsym(IntPtr handle, string symbol);

        [DllImport("dl", EntryPoint = "dlerror")]
        public static extern string dlerror();


        [SuppressUnmanagedCodeSecurity()]
        [DllImport("libEGL", EntryPoint = "eglGetProcAddress", CharSet = CharSet.Ansi)]
        public static extern IntPtr GetProcAddress([MarshalAs(UnmanagedType.LPStr)]string funcname);

        [SuppressUnmanagedCodeSecurity]
        [DllImport("libEGL", EntryPoint = "eglGetDisplay")]
        public static extern IntPtr GetDisplay(IntPtr display_id);

        [SuppressUnmanagedCodeSecurity]
        [DllImport("libEGL", EntryPoint = "eglGetError")]
        public static extern int GetError();

        [SuppressUnmanagedCodeSecurity]
        [DllImport("libEGL", EntryPoint = "eglInitialize")]
        public static extern bool Initialize(IntPtr dpy, ref int major, ref int minor);

        [SuppressUnmanagedCodeSecurity]
        [DllImport("libEGL", EntryPoint = "eglChooseConfig")]
        public static extern bool ChooseConfig(IntPtr dpy, IntPtr attrib_list, IntPtr configs, int config_size, ref int num_config);

        [SuppressUnmanagedCodeSecurity]
        [DllImport("libEGL", EntryPoint = "eglCreateContext")]
        public static extern IntPtr CreateContext(IntPtr dpy, IntPtr config, IntPtr share_context, IntPtr attrib_list);

        [SuppressUnmanagedCodeSecurity]
        [DllImport("libEGL", EntryPoint = "eglCreateWindowSurface")]
        public static extern IntPtr CreateWindowSurface(IntPtr dpy, IntPtr config, ref BcmHost.EGL_DISPMANX_WINDOW_T win, IntPtr attrib_list);

        [SuppressUnmanagedCodeSecurity]
        [DllImport("libEGL", EntryPoint = "eglMakeCurrent")]
        public static extern bool MakeCurrent(IntPtr dpy, IntPtr draw, IntPtr read, IntPtr ctx);

        [SuppressUnmanagedCodeSecurity]
        [DllImport("libEGL", EntryPoint = "eglSwapBuffers")]
        public static extern bool SwapBuffers(IntPtr dpy, IntPtr surface);

        //internal delegate IntPtr EglGetDisplay(IntPtr display_id);
        //internal static EglGetDisplay peglGetDisplay;

        //[SuppressUnmanagedCodeSecurity]
        //internal delegate bool eglChooseConfig(IntPtr dpy, int* attrib_list, IntPtr* configs, int config_size, int* num_config);
        //internal static eglChooseConfig peglChooseConfig;

        //[SuppressUnmanagedCodeSecurity]
        //internal delegate bool eglCopyBuffers(IntPtr dpy, IntPtr surface, IntPtr target);
        //internal static eglCopyBuffers peglCopyBuffers;

        //[SuppressUnmanagedCodeSecurity]
        //internal delegate IntPtr eglCreateContext(IntPtr dpy, IntPtr config, IntPtr share_context, int* attrib_list);
        //internal static eglCreateContext peglCreateContext;

        //[SuppressUnmanagedCodeSecurity]
        //internal delegate IntPtr eglCreatePbufferSurface(IntPtr dpy, IntPtr config, int* attrib_list);
        //internal static eglCreatePbufferSurface peglCreatePbufferSurface;

        //[SuppressUnmanagedCodeSecurity]
        //internal delegate IntPtr eglCreatePixmapSurface(IntPtr dpy, IntPtr config, IntPtr pixmap, int* attrib_list);
        //internal static eglCreatePixmapSurface peglCreatePixmapSurface;

        //[SuppressUnmanagedCodeSecurity]
        //internal delegate IntPtr eglCreateWindowSurface(IntPtr dpy, IntPtr config, IntPtr win, int* attrib_list);
        //internal static eglCreateWindowSurface peglCreateWindowSurface;

        //[SuppressUnmanagedCodeSecurity]
        //internal delegate bool eglDestroyContext(IntPtr dpy, IntPtr ctx);
        //internal static eglDestroyContext peglDestroyContext;

        //[SuppressUnmanagedCodeSecurity]
        //internal delegate bool eglDestroySurface(IntPtr dpy, IntPtr surface);
        //internal static eglDestroySurface peglDestroySurface;

        //[SuppressUnmanagedCodeSecurity]
        //internal delegate bool eglGetConfigAttrib(IntPtr dpy, IntPtr config, int attribute, int* value);
        //internal static eglGetConfigAttrib peglGetConfigAttrib;

        //[SuppressUnmanagedCodeSecurity]
        //internal delegate bool eglGetConfigs(IntPtr dpy, IntPtr* configs, int config_size, int* num_config);
        //internal static eglGetConfigs peglGetConfigs;

        //[SuppressUnmanagedCodeSecurity]
        //internal delegate IntPtr eglGetCurrentDisplay();
        //internal static eglGetCurrentDisplay peglGetCurrentDisplay;

        //[SuppressUnmanagedCodeSecurity]
        //internal delegate IntPtr eglGetCurrentSurface(int readdraw);
        //internal static eglGetCurrentSurface peglGetCurrentSurface;



        //[SuppressUnmanagedCodeSecurity]
        //internal delegate int eglGetError();
        //internal static eglGetError peglGetError;

        //[SuppressUnmanagedCodeSecurity]
        //internal delegate IntPtr eglGetProcAddress(string procname);
        //internal static eglGetProcAddress peglGetProcAddress;

        //[SuppressUnmanagedCodeSecurity]
        //internal delegate bool eglInitialize(IntPtr dpy, ref int major, ref int minor);
        //internal static eglInitialize peglInitialize;

        //[SuppressUnmanagedCodeSecurity]
        //internal delegate bool eglMakeCurrent(IntPtr dpy, IntPtr draw, IntPtr read, IntPtr ctx);
        //internal static eglMakeCurrent peglMakeCurrent;

        //[SuppressUnmanagedCodeSecurity]
        //internal delegate bool eglQueryContext(IntPtr dpy, IntPtr ctx, int attribute, int* value);
        //internal static eglQueryContext peglQueryContext;

        //[SuppressUnmanagedCodeSecurity]
        //internal delegate IntPtr eglQueryString(IntPtr dpy, int name);
        //internal static eglQueryString peglQueryString;

        //[SuppressUnmanagedCodeSecurity]
        //internal delegate bool eglQuerySurface(IntPtr dpy, IntPtr surface, int attribute, int* value);
        //internal static eglQuerySurface peglQuerySurface;

        //[SuppressUnmanagedCodeSecurity]
        //internal delegate bool eglSwapBuffers(IntPtr dpy, IntPtr surface);
        //internal static eglSwapBuffers peglSwapBuffers;

        //[SuppressUnmanagedCodeSecurity]
        //internal delegate bool eglTerminate(IntPtr dpy);
        //internal static eglTerminate peglTerminate;

        //[SuppressUnmanagedCodeSecurity]
        //internal delegate bool eglWaitGL();
        //internal static eglWaitGL peglWaitGL;

        //[SuppressUnmanagedCodeSecurity]
        //internal delegate bool eglWaitNative(int engine);
        //internal static eglWaitNative peglWaitNative;
    }
}