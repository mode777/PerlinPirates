using System.Security.Cryptography.X509Certificates;
using Renderer.Common3D.Primitives;
using Tgl.Net;
using Tgl.Net.Bindings;

namespace Renderer.Common3D
{
    public class Mesh3D
    {
        private readonly IDrawable _drawable;
        private readonly VertexBuffer _buffer;
        private readonly GlContext _context;
        private readonly Shader3D _shader;
        private readonly Vertex3d[] _vertices;
        private readonly Material3D _material;

        public Transform3D Transform3D { get; }

        public Mesh3D(GlContext context, Shader3D shader, Vertex3d[] vertices, ushort[] indices, Material3D material)
        {
            _context = context;
            _shader = shader;
            _vertices = vertices;
            _material = material;
            _vertices = vertices;

            _buffer = context.BuildBuffer<Vertex3d>()
                .HasUsage(BufferUsageARB.GL_STATIC_DRAW)
                .HasData(_vertices)
                .HasAttribute("vertexPosition_modelspace", 3)
                .HasAttribute("vertexNormal_modelspace", 3)
                .HasAttribute("vertexUV_attr", 2)
                .Build();

            _drawable = context.BuildDrawable()
                .UseShader(shader.Shader)
                .AddTexture("myTextureSampler", _material.Diffuse)
                .AddBuffer(_buffer)
                .UseIndices(indices)
                .Build();

            Transform3D = new Transform3D();
        }

        public void Draw(Camera3D camera)
        {
            _shader.ModelMatrix = Transform3D.Matrix;
            _shader.ViewMatrix = camera.ViewMatrix;
            
            _shader.Update();

            _context.DrawDrawable(_drawable);
        }

    }
}