using System;
using Tgl.Net.Bindings;

namespace Tgl.Net
{
    public class FramebufferAttachmentBuilder
    {
        private readonly IGlState _state;
        private readonly FramebufferBuilder _builder;

        public FramebufferAttachment Attachment { get; }
        public Texture Texture { get; private set; }

        public FramebufferAttachmentBuilder(IGlState state, FramebufferBuilder builder, FramebufferAttachment attachment)
        {
            Attachment = attachment;
            _state = state;
            _builder = builder;
        }

        public FramebufferBuilder WithDefaultTexture(int width, int height)
        {
            Texture = new TextureBuilder<byte>(_state)
                .HasSize(width, height)
                .HasFiltering(TextureMinType.GL_NEAREST, TextureMagType.GL_NEAREST)
                .HasMipmaps(false)
                .Build();

            return _builder;
        }

        public FramebufferBuilder WithTexture(Texture texture)
        {
            Texture = texture;

            return _builder;
        }

        public FramebufferBuilder WithTexture<T>(Action<TextureBuilder<T>> buildAction)
            where T : struct
        {
            var builder = ConfigureDefaultBuilder<T>();

            buildAction(builder);

            Texture = builder.Build();

            return _builder;
        }

        private TextureBuilder<T> ConfigureDefaultBuilder<T>()
            where T : struct
        {
            var builder = new TextureBuilder<T>(_state);

            builder.HasMipmaps(false);

            return builder;
        }
    }
}