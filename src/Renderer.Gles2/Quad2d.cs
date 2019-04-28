using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using Tgl.Net;
using Tgl.Net.Abstractions;
using Tgl.Net.Math;

namespace Renderer.Gles2
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Quad2d
    {
        public static Quad2d FromDimensions(float x, float y, float w, float h)
        {
            var spr = new Quad2d();
            spr.SetRectangle(x,y,w,h);
            spr.SetFrame(0, 0, w, h);
            return spr;
        }

        public static Quad2d FromDimensions(float x, float y, float w, float h, float srcX, float srcY)
        {
            var spr = new Quad2d();
            spr.SetRectangle(x, y, w, h);
            spr.SetFrame(srcX, srcY, w, h);
            return spr;
        }

        public Vertex2d A;
        public Vertex2d B;
        public Vertex2d C;
        public Vertex2d D;

        public void Flip(bool diagonal, bool horizontal, bool vertical)
        {
            Vector2 temp;

            if (diagonal)
            {
                SwitchPositions(ref B, ref D);
            }

            if (horizontal)
            {
                SwitchPositions(ref A, ref B);
                SwitchPositions(ref C, ref D);
            }

            if (vertical)
            {
                SwitchPositions(ref A, ref D);
                SwitchPositions(ref B, ref D);
            }
        }

        public void Offset(float x, float y)
        {
            A.Position.Offset(x,y);
            B.Position.Offset(x,y);
            C.Position.Offset(x,y);
            D.Position.Offset(x,y);
        }

        public void SetRectangle(float x, float y, float w, float h)
        {
            A.Position.X = x;
            A.Position.Y = y;

            B.Position.X = x + w;
            B.Position.Y = y;

            C.Position.X = x + w;
            C.Position.Y = y + h;

            D.Position.X = x;
            D.Position.Y = y + h;
        }

        public void SetFrame(float x, float y, float w, float h)
        {
            A.Uv.X = x;
            A.Uv.Y = y;

            B.Uv.X = x + w;
            B.Uv.Y = y;

            C.Uv.X = x + w;
            C.Uv.Y = y + h;

            D.Uv.X = x;
            D.Uv.Y = y + h;
        }

        public void SetTexture(Texture texture, float x, float y)
        {
            SetFrame(0, 0, texture.Width, texture.Height);
            SetRectangle(x, y, texture.Width, texture.Height);
        }

        public void Transform(ref Matrix3 mat)
        {
            A.Position.Transform(ref mat);
            B.Position.Transform(ref mat);
            C.Position.Transform(ref mat);
            D.Position.Transform(ref mat);
        }

        public RectangleF GetBoundingBox()
        {
            return RectangleF.FromLTRB(
                Math.Min(Math.Min(A.Position.X, B.Position.X), Math.Min(C.Position.X, D.Position.X)),
                Math.Min(Math.Min(A.Position.Y, B.Position.Y), Math.Min(C.Position.Y, D.Position.Y)),
                Math.Max(Math.Max(A.Position.X, B.Position.X), Math.Max(C.Position.X, D.Position.X)),
                Math.Max(Math.Max(A.Position.Y, B.Position.Y), Math.Max(C.Position.Y, D.Position.Y)));
        }

        public Vector2 GetCenter()
        {
            return new Vector2
            {
                X = (A.Position.X + B.Position.X + C.Position.X + D.Position.X) / 4.0f,
                Y = (A.Position.Y + B.Position.Y + C.Position.Y + D.Position.Y) / 4.0f
            };
        }

        private void SwitchPositions(ref Vertex2d a, ref Vertex2d b)
        {
            var temp = a.Position;
            a.Position = b.Position;
            b.Position = temp;
        }
    }
}
