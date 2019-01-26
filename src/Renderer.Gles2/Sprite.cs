using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using Tgl.Net;

namespace Renderer.Gles2
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Sprite
    {
        public Vector2 A_Pos;
        public Vector2 A_Uv;
        public Vector2 C_Pos;
        public Vector2 C_Uv;
        public Vector2 B_Pos;
        public Vector2 B_Uv;
        public Vector2 D_Pos;
        public Vector2 D_Uv;

        public void SetRectangle(float x, float y, float w, float h)
        {
            A_Pos.X = x;
            A_Pos.Y = y;

            B_Pos.X = x + w;
            B_Pos.Y = y;

            C_Pos.X = x + w;
            C_Pos.Y = y + h;

            D_Pos.X = x;
            D_Pos.Y = y + h;
        }

        public void SetFrame(float x, float y, float w, float h)
        {
            A_Uv.X = x;
            A_Uv.Y = y;

            B_Uv.X = x + w;
            B_Uv.Y = y;

            C_Uv.X = x + w;
            C_Uv.Y = y + h;

            D_Uv.X = x;
            D_Uv.Y = y + h;
        }

        public void SetTexture(Texture texture, float x, float y)
        {
            SetFrame(0, 0, texture.Width, texture.Height);
            SetRectangle(x, y, texture.Width, texture.Height);
        }
    }
}
