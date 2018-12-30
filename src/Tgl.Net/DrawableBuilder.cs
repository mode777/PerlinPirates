using System;
using System.Collections.Generic;
using System.Text;
using Tgl.Net.Bindings;
using Tgl.Net.Math;

namespace Tgl.Net
{
    public class DrawableBuilder : IDrawable
    {
        private readonly IGlState _state;
        private List<VertexBuffer> _buffers = new List<VertexBuffer>();
        private Dictionary<string, Action<Shader>> _uniformSetters = new Dictionary<string, Action<Shader>>();
        private Dictionary<string, Texture> _textures = new Dictionary<string, Texture>();

        public DrawableBuilder(IGlState state)
        {
            _state = state;
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
            var builder = new ShaderBuilder(_state);
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
            var builder = new BufferBuilder<T>(_state);
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
            IndexBuffer = new IndexBuffer(_state, indices);

            return this;
        }

        public DrawableBuilder AddUniform(string variable, float value)
        {
            _uniformSetters[variable] = shader => shader.SetUniform(shader.GetUniformLocation(variable), value);

            return this;
        }

        public DrawableBuilder AddUniform(string variable, Vector2 value)
        {
            _uniformSetters[variable] = shader => shader.SetUniform(shader.GetUniformLocation(variable), value);

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

        public DrawableBuilder AddUniform(string variable, GL.TextureUnit value)
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
            var builder = new TextureBuilder<T>(_state);
            buildAction(builder);

            _textures[name] = builder.Build();

            return this;
        }

        public IDrawable Build()
        {
            return this;
        }
    }
}
