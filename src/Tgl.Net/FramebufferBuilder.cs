using System.Collections.Generic;
using Tgl.Net.Bindings;

namespace Tgl.Net
{
    public class FramebufferBuilder
    {
        private readonly IGlState _state;

        private List<FramebufferAttachmentBuilder> _attachmentBuilders = new List<FramebufferAttachmentBuilder>();

        public FramebufferBuilder(IGlState state)
        {
            _state = state;
        }

        public FramebufferAttachmentBuilder HasAttachment(FramebufferAttachment attachment)
        {
            var attachmentBuilder = new FramebufferAttachmentBuilder(_state, this, attachment);
            _attachmentBuilders.Add(attachmentBuilder);
            return attachmentBuilder;
        }

        public Framebuffer Build()
        {
            var framebuffer = new Framebuffer(_state);

            foreach (var framebufferAttachmentBuilder in _attachmentBuilders)
            {
                framebuffer.Texture2D(framebufferAttachmentBuilder.Attachment, 
                    framebufferAttachmentBuilder.Texture);

            }

            var err = GL.glGetError();
            var complete = framebuffer.CheckStatus();

            return framebuffer;
        }
    }
}