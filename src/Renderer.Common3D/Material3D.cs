using System.Drawing;
using Tgl.Net;

namespace Renderer.Common3D
{
    public class Material3D
    {
        public Texture Diffuse { get; }

        public Material3D(Texture diffuse)
        {
            Diffuse = diffuse;
        }
    }
}