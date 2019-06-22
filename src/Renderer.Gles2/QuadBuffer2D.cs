using System;
using System.Drawing;
using System.Numerics;
using Tgl.Net;
using Tgl.Net.Bindings;
using Tgl.Net.Math;
using Rectangle = System.Drawing.Rectangle;

namespace Renderer.Gles2
{
    public class QuadBuffer2D
    {
        private readonly GlContext _context;
        private readonly Shader2d _shader;
        private readonly int _capacity;
        private readonly Quad2d[] _quads;
        private readonly ushort[] _indices;
        private readonly IDrawable _drawable;
        private readonly VertexBuffer _buffer;

        public Texture Texture { get; }


        public QuadBuffer2D(GlContext context, Shader2d shader, Texture texture, int capacity)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _shader = shader ?? throw new ArgumentNullException(nameof(shader));
            Texture = texture ?? throw new ArgumentNullException(nameof(texture));
            _capacity = capacity;
            _quads = new Quad2d[capacity];

            _indices = new ushort[capacity * 6];
            CreateQuadIndices();

            _buffer = _context.BuildBuffer<Quad2d>()
                .HasUsage(BufferUsageARB.GL_STREAM_DRAW)
                .HasAttribute("aPosition", 2)
                .HasAttribute("aTexcoord", 2)
                .HasAttribute("aColor", 4)
                .HasData(_quads).Build();

            _drawable = context.BuildDrawable()
                .UseShader(shader.Shader)
                .AddBuffer(_buffer)
                .AddTexture("uTexture", Texture)
                .UseIndices(_indices)
                .Build();
        }
        
        public int Size => _capacity;

        public void Render()
        {
            _shader.UpdateUvMatrix(Texture);
            
            _context.DrawDrawable(_drawable);
        }

        public void Update()
        {
            _buffer.SubData(_quads, 0, (uint)_buffer.VertexCount);
        }

        public void SetQuad(int index, ref Quad2d quad)
        {
            _quads[index] = quad;
        }

        public void SetQuad(int index, int x, int y, int w, int h, int srcx, int srcy)
        {
            _quads[index] = Quad2d.FromDimensions(x, y, w, h, srcx, srcy);
        }

        public void SetSrcRectangle(int index, ref Rectangle rect)
        {
            _quads[index].SetSrcRectangle(ref rect);
        }

        public void SetSrcRectangle(int index, Rectangle rect)
        {
            _quads[index].SetSrcRectangle(ref rect);
        }

        public void SetDstRectangle(int index, ref Rectangle rect)
        {
            _quads[index].SetDstRectangle(ref rect);
        }

        public void SetDstRectangle(int index, Rectangle rect)
        {
            _quads[index].SetDstRectangle(ref rect);
        }

        public void FlipQuad(int index, bool diagonal, bool horizontal, bool vertical)
        {
            _quads[index].Flip(diagonal, horizontal, vertical);
        }

        public void TransformQuad(int index, Transform2d transform)
        {
            transform.UpdateMatrix();
            _quads[index].Transform(ref transform.Matrix);
        }

        public void OffsetQuad(int index, float x, float y)
        {
            _quads[index].Offset(x, y);
        }

        public Quad2d GetQuad2D(int index)
        {
            return _quads[index];
        }

        public void ClearQuad(int index)
        {
            _quads[index] = new Quad2d();
        }

        public RectangleF GetBoundingBox(int index)
        {
            return _quads[index].GetBoundingBox();
        }

        public Vector2 GetCenter(int index)
        {
            return _quads[index].GetCenter();
        }

        public void SetQuad(int index, ref Quad2d quad, Transform2d transform)
        {
            _quads[index] = quad;
            TransformQuad(index, transform);
        }

        public void SetColor(int index, float r, float g, float b, float a)
        {
            _quads[index].SetColor(r,g,b,a);
        }

        public void SetColor(int index, ref Vector4 color)
        {
            _quads[index].SetColor(ref color);
        }

        private void CreateQuadIndices()
        {
            for (int i = 0; i < _capacity; i++)
            {
                var vertex = i * 4;
                var index = i * 6;

                _indices[index + 0] = (ushort)(vertex + 3);
                _indices[index + 1] = (ushort)(vertex + 0);
                _indices[index + 2] = (ushort)(vertex + 1);
                _indices[index + 3] = (ushort)(vertex + 3);
                _indices[index + 4] = (ushort)(vertex + 1);
                _indices[index + 5] = (ushort)(vertex + 2);
            }
        }
    }
}