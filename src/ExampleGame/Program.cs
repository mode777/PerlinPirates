using System;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading;
using Game.Abstractions;
using Platform.Sdl2;
using Renderer.Gles2;

namespace ExampleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = AssemblyLoadContext.Default;

            var platform = new Sdl2Platform(new Sdl2Configuration());
            platform.CreateWindow();

            var renderer = new Gles2Renderer(platform);

            var quit = false;

            while (!quit)
            {
                while (platform.PollEvent(out var ev))
                {
                    if (ev is QuitEvent)
                        quit = true;
                }

                renderer.Render();
                platform.Sleep(15);
            }
        }
    }
}
