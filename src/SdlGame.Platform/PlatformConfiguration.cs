using System;
using System.Collections.Generic;
using System.Text;

namespace SdlGame.Platform
{
    internal class PlatformConfiguration
    {
        public int Width { get; set; } = 640;
        public int Height { get; set; } = 480;
        public int GlMinor { get; set; } = 1;
        public int GlMajor { get; set; } = 3;
        public string GlProfile { get; set; } = "core";
    }
}
