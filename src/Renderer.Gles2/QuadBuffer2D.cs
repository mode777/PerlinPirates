using Tgl.Net;

namespace Renderer.Gles2
{
    public class QuadBuffer2D
    {
        private readonly GlContext _context;
        private readonly Shader2d _shader;
        private readonly Texture _texture;
        private readonly int _capacity;
        public readonly Quad2d[] Quads;
        private readonly ushort[] _indices;
        private readonly IDrawable _drawable;
        private readonly VertexBuffer _buffer;

        public QuadBuffer2D(GlContext context, Shader2d shader, Texture texture, int capacity)
        {
            _context = context;
            _shader = shader;
            _texture = texture;
            _capacity = capacity;
            Quads = new Quad2d[capacity];

            _indices = new ushort[capacity * 6];
            CreateQuadIndices();

            _buffer = _context.BuildBuffer<Quad2d>()
                .HasAttribute("aPosition", 2)
                .HasAttribute("aTexcoord", 2)
                .HasData(Quads).Build();

            _drawable = context.BuildDrawable()
                .UseShader(shader.Shader)
                .AddBuffer(_buffer)
                .AddTexture("uTexture", _texture)
                .UseIndices(_indices)
                .Build();
        }
        
        public int Size => _capacity;

        public void Render()
        {
            _shader.UpdateUvMatrix(_texture);
            
            _context.DrawDrawable(_drawable);
        }

        public void Update()
        {
            _buffer.SubData(Quads, 0, (uint)_buffer.VertexCount);
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