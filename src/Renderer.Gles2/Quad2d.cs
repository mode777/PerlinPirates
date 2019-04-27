using System;
using System.Collections.Generic;
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
    }
}
