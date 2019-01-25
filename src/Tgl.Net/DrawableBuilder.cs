using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tgl.Net.Abstractions;
using Tgl.Net.Bindings;
using Tgl.Net.Math;

namespace Tgl.Net
{
    public class DrawableBuilder : IDrawable
    {
        private readonly GlContext _context;
        private List<VertexBuffer> _buffers = new List<VertexBuffer>();
        private Dictionary<string, Action<Shader>> _uniformSetters = new Dictionary<string, Action<Shader>>();
        private Dictionary<string, Texture> _textures = new Dictionary<string, Texture>();

        public DrawableBuilder(GlContext context)
        {
            _context = context;
        }

        public Shader Shader { get; private set; }
        public IEnumerable<VertexBuffer> Buffers { get => _buffers; }
        public IndexBuffer IndexBuffer { get; private set; }
        public IReadOnlyDictionary<string, Texture> Textures { get => _textures; }
        public IReadOnlyDictionary<string, Action<Shader>> UniformSetters { get => _uniformSetters; }

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
            _uniformSetters[variable] = shader => shader.SetUniform(shader.GetUniformLocation(variable), value);

            return this;
        }

        public DrawableBuilder AddUniform(string variable, float x, float y)
        {
            _uniformSetters[variable] = shader => shader.SetUniform(shader.GetUniformLocation(variable), x, y);

            return this;
        }

        public DrawableBuilder AddUniform(string variable, Vector3 value)
        {
            _uniformSetters[variable] = shader => shader.SetUniform(shader.GetUniformLocation(variable), value);

            return this;
        }

        public DrawableBuilder AddUniform(string variable, Vector4 value)
        {
            _uniformSetters[variable] = shader => shader.SetUniform(shader.GetUniformLocation(variable), value);

            return this;
        }

        public DrawableBuilder AddUniform(string variable, TextureUnit value)
        {
            _uniformSetters[variable] = shader => shader.SetUniform(shader.GetUniformLocation(variable), value);

            return this;
        }

        public DrawableBuilder AddUniformSetter(string variable, Action<Shader> action)
        {
            _uniformSetters[variable] = action;

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

        public DrawableBuilder AddTexture(string name, IImage image)
        {
            _textures[name] = _context.TextureFromImage(image);

            return this;
        }

        public IDrawable Build()
        {
            return this;
        }
    }
}
