using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using Tgl.Net;

namespace Renderer.Gles2
{
    public class Sprite
    {
        private static int _instanceCounter = 0;

        public Texture Texture { get; }
        public RectangleF Source { get; }
        public Transform2d Transform { get; }

        public Quad2d BaseQuad2D;
        private readonly int _quadId;

        internal Sprite(Texture texture, RectangleF? source = null, Transform2d transform = null)
        {
            Texture = texture;
            Source = source ?? RectangleF.FromLTRB(0,0,texture.Width,texture.Height);
            Transform = transform ?? new Transform2d();

            BaseQuad2D = Quad2d.FromDimensions(0, 0, Source.Width, Source.Height, Source.X, Source.Y);

            _quadId = Interlocked.Increment(ref _instanceCounter);
        }

        public void ApplyToQuad(out Quad2d quad2D)
        {
            Transform.UpdateMatrix();
            
            quad2D = BaseQuad2D;
            quad2D.Transform(ref Transform.Matrix);
        }

        public override int GetHashCode()
        {
            return _quadId;
        }
    }
}
