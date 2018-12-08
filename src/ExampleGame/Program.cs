using System;
using System.Threading;
using Platform.Sdl2;
using Renderer.Gles2;

namespace ExampleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var platform = new Sdl2Platform(new Sdl2Configuration());
            var renderer = new Gles2Renderer(platform);

            while (true)
            {
                renderer.Render();
                Thread.Sleep(15);
            }
        }
    }
}
