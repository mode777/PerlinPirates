using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Text;
using Tgl.Net.Bindings;
using Tgl.Net.Math;

namespace Tgl.Net
{
    public class DrawableBuilder : IDrawable
    {
        private readonly GlContext _context;
        private List<VertexBuffer> _buffers = new List<VertexBuffer>();
        private Dictionary<string, Texture> _textures = new Dictionary<string, Texture>();

        private IDictionary<string, float> _floatUniforms = new Dictionary<string, float>();
        private IDictionary<string, Vector2> _vector2Uniforms = new Dictionary<string, Vector2>();
        private IDictionary<string, Vector3> _vector3Uniforms = new Dictionary<string, Vector3>();
        private IDictionary<string, Vector4> _vector4Uniforms = new Dictionary<string, Vector4>();
        private IDictionary<string, Matrix2x2> _matrix2Uniforms = new Dictionary<string, Matrix2x2>();
        private IDictionary<string, Matrix3x3> _matrix3Uniforms = new Dictionary<string, Matrix3x3>();
        private IDictionary<string, Matrix4x4> _matrix4Uniforms = new Dictionary<string, Matrix4x4>();

        public DrawableBuilder(GlContext context)
        {
            _context = context;
        }

        public Shader Shader { get; private set; }
        public IEnumerable<VertexBuffer> Buffers { get => _buffers; }
        public IndexBuffer IndexBuffer { get; private set; }
        public IDictionary<string, Texture> Textures { get => _textures; }

        public IDictionary<string, float> FloatUniforms => _floatUniforms;

        public IDictionary<string, Vector2> Vector2Uniforms => _vector2Uniforms;

        public IDictionary<string, Vector3> Vector3Uniforms => _vector3Uniforms;

        public IDictionary<string, Vector4> Vector4Uniforms => _vector4Uniforms;

        public IDictionary<string, Matrix2x2> Matrix2Uniforms => _matrix2Uniforms;

        public IDictionary<string, Matrix3x3> Matrix3Uniforms => _matrix3Uniforms;

        public IDictionary<string, Matrix4x4> Matrix4Uniforms => _matrix4Uniforms;


        public DrawableBuilder UseShader(Shader shader)
        {
            Shader = shader;

            return this;
        }

        public DrawableBuilder UseShader(Action<ShaderBuilder> buildAction)
        {
            var builder = new ShaderBuilder(_context.State);
            buildAction(builder);
            Shader = builder.Build();

            return this;
        }

        public DrawableBuilder AddBuffer(VertexBuffer buffer)
        {
            _buffers.Add(buffer);

            return this;
        }
        
        public DrawableBuilder AddBuffer<T>(Action<BufferBuilder<T>> buildAction)
            where T : struct
        {
            var builder = new BufferBuilder<T>(_context.State);
            buildAction(builder);
            var buffer = builder.Build();

            _buffers.Add(buffer);

            return this;
        }

        public DrawableBuilder UseIndices(IndexBuffer indexBuffer)
        {
            IndexBuffer = indexBuffer;

            return this;
        }

        public DrawableBuilder UseIndices(params ushort[] indices)
        {
            IndexBuffer = new IndexBuffer(_context.State, indices);

            return this;
        }

        public DrawableBuilder AddUniform(string variable, float value)
        {
            _floatUniforms[variable] = value;

            return this;
        }

        public DrawableBuilder AddUniform(string variable, Vector2 value)
        {
            _vector2Uniforms[variable] = value;

            return this;
        }

        public DrawableBuilder AddUniform(string variable, Vector3 value)
        {
            _vector3Uniforms[variable] = value;

            return this;
        }

        public DrawableBuilder AddUniform(string variable, Vector4 value)
        {
            _vector4Uniforms[variable] = value;

            return this;
        }
        
        public DrawableBuilder AddUniform(string variable, Matrix3x3 value)
        {
            _matrix3Uniforms[variable] = value;

            return this;
        }

        public DrawableBuilder AddUniform(string variable, Matrix4x4 value)
        {
            _matrix4Uniforms[variable] = value;

            return this;
        }

        public DrawableBuilder AddTexture(string name, Texture texture)
        {
            _textures[name] = texture;

            return this;
        }

        public DrawableBuilder AddTexture<T>(string name, Action<TextureBuilder<T>> buildAction)
            where T : struct
        {
            var builder = new TextureBuilder<T>(_context.State);
            buildAction(builder);

            _textures[name] = builder.Build();

            return this;
        }

        public DrawableBuilder AddTexture(string name, byte[] data, int width, int height, ImagePixelFormat format = ImagePixelFormat.Rgba)
        {
            _textures[name] = _context.TextureFromPixels(data, width, height, format);

            return this;
        }

        public IDrawable Build()
        {
            return this;
        }
    }
}
