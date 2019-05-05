using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using Tgl.Net;
using Tgl.Net.Abstractions;
using Tgl.Net.Math;
using Rectangle = System.Drawing.Rectangle;

namespace Renderer.Gles2
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Quad2d
    {
        public static Quad2d FromDimensions(float x, float y, float w, float h)
        {
            var spr = new Quad2d();
            spr.SetDstRectangle(x,y,w,h);
            spr.SetSrcRectangle(0, 0, w, h);
            return spr;
        }

        public static Quad2d FromDimensions(float x, float y, float w, float h, float srcX, float srcY)
        {
            var spr = new Quad2d();
            spr.SetDstRectangle(x, y, w, h);
            spr.SetSrcRectangle(srcX, srcY, w, h);
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

        public void SetColor(float r, float g, float b, float a)
        {
            var color = new Vector4(1 - r, 1 - g, 1 - b, 1 - a);

            A.Color = color;
            B.Color = color;
            C.Color = color;
            D.Color = color;
        }

        public void SetColor(ref Vector4 color)
        {
            var colori = new Vector4(1 - color.X, 1- color.Y, 1 - color.Z, 1 - color.W);

            A.Color = colori;
            B.Color = colori;
            C.Color = colori;
            D.Color = colori;
        }

        public void Offset(float x, float y)
        {
            A.Position.Offset(x,y);
            B.Position.Offset(x,y);
            C.Position.Offset(x,y);
            D.Position.Offset(x,y);
        }

        public void SetDstRectangle(float x, float y, float w, float h)
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

        public void SetDstRectangle(ref Rectangle rect)
        {
            A.Position.X = rect.X;
            A.Position.Y = rect.Y;

            B.Position.X = rect.Right;
            B.Position.Y = rect.Y;

            C.Position.X = rect.Right;
            C.Position.Y = rect.Bottom;

            D.Position.X = rect.X;
            D.Position.Y = rect.Bottom;
        }

        public void SetSrcRectangle(float x, float y, float w, float h)
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

        public void SetSrcRectangle(ref Rectangle rect)
        {
            A.Uv.X = rect.X;
            A.Uv.Y = rect.Y;

            B.Uv.X = rect.Right;
            B.Uv.Y = rect.Y;

            C.Uv.X = rect.Right;
            C.Uv.Y = rect.Bottom;

            D.Uv.X = rect.X;
            D.Uv.Y = rect.Bottom;
        }

        public void SetTexture(Texture texture, float x, float y)
        {
            SetSrcRectangle(0, 0, texture.Width, texture.Height);
            SetDstRectangle(x, y, texture.Width, texture.Height);
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
