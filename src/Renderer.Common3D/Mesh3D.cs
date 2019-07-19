using Renderer.Common3D.Primitives;
using Tgl.Net;
using Tgl.Net.Bindings;

namespace Renderer.Common3D
{
    public class Mesh3D
    {
        private readonly IDrawable _drawable;
        private readonly VertexBuffer _buffer;
        private readonly Vertex3d[] _vertices;

        public Mesh3D(GlContext context, /*Shader3d shader,*/ int capacity)
        {
            _vertices = new Vertex3d[capacity];

            context.BuildBuffer<Vertex3d>()
                .HasUsage(BufferUsageARB.GL_STATIC_DRAW)
                .HasData(_vertices)
                .HasAttribute("aPosition", 3)
                .HasAttribute("aNormal", 3)
                .HasAttribute("aTexcoord", 2);


        }


    }
}