using System;
using System.Drawing;
using System.Text;
using Tgl.Net.Bindings;

namespace Tgl.Net
{
    public class Framebuffer
    {
        private readonly IGlState _state;
        private readonly FramebufferContext _fbContext;
        
        public Texture ColorAttachment { get; private set; }
        public Texture DepthAttachment { get; private set; }


        public Framebuffer(IGlState state)
        {
            _state = state;

            unsafe
            {
                var handle = Handle;
                GL.glGenFramebuffers(1, &handle);
                Handle = handle;
            }

            _fbContext = new FramebufferContext(this, _state);
        }

        public uint Handle { get; }

        public void Bind()
        {
            _state.FramebufferBinding = Handle;
        }

        public void Unbind()
        {
            if (_state.FramebufferBinding == Handle)
            {
                _state.FramebufferBinding = 0;
            }
        }

        public FramebufferStatus CheckStatus()
        {
            return GL.glCheckFramebufferStatus(FramebufferTarget.GL_FRAMEBUFFER);
        }

        public void Texture2D(FramebufferAttachment attachment, Texture texture)
        {
            texture.Bind();
            
            Bind();
            GL.glFramebufferTexture2D(FramebufferTarget.GL_FRAMEBUFFER,
                attachment, TextureTarget.GL_TEXTURE_2D, texture.Handle, 0);

            switch (attachment)
            {
                case FramebufferAttachment.GL_COLOR_ATTACHMENT0:
                    ColorAttachment = texture;
                    break;
                case FramebufferAttachment.GL_DEPTH_ATTACHMENT:
                    DepthAttachment = texture;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(attachment), attachment, null);
            }

            Unbind();
        }

        public IDisposable StartDrawing()
        {
            _fbContext.Up();

            return _fbContext;
        }
    }

    internal class FramebufferContext : IDisposable
    {
        private readonly Framebuffer _fb;
        private readonly IGlState _state;
        private Rectangle _viewport;
        private uint _framebufferHandle;
        private bool isUp = false;

        public FramebufferContext(Framebuffer fb, IGlState state)
        {
            _fb = fb;
            _state = state;
        }

        public void Up()
        {
            if (!isUp)
            {
                _framebufferHandle = _state.FramebufferBinding;
                _viewport = _state.Viewport;

                _state.FramebufferBinding = _fb.Handle;
                _state.Viewport = new Rectangle(0,0, _fb.ColorAttachment.Width, _fb.ColorAttachment.Height);

                isUp = true;
            }
        }

        public void Down()
        {
            if (isUp)
            {
                _state.FramebufferBinding = _framebufferHandle;
                _state.Viewport = _viewport;

                isUp = false;
            }
        }

        public void Dispose()
        {
            Down();
        }
    }
}
