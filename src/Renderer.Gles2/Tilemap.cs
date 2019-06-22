using System;
using System.Drawing;
using System.IO;
using Tgl.Net;

namespace Renderer.Gles2
{
    public class Tilemap
    {
        private readonly QuadBuffer2D _buffer2D;

        public Tileset Set { get; }
        public int Width { get; }
        public int Height { get; }

        public Tilemap(GlContext context, Shader2d shader, Tileset set, int width, int height, int[] data)
            : this(context, shader, set, width, height)
        {
            if (data.Length != width * height)
                throw new InvalidDataException("Data size does not match map size");

            SetData(data);
        }

        public Tilemap(GlContext context, Shader2d shader, Tileset set, int width, int height)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (shader == null) throw new ArgumentNullException(nameof(shader));
            Set = set ?? throw new ArgumentNullException(nameof(set));
            Width = width;
            Height = height;
            _buffer2D = new QuadBuffer2D(context, shader, Set.Texture, width * height);
        }

        public void SetTile(Point point, int id)
        {
            var index = (point.Y * Width) + point.X;

            SetTile(point, index, id);
        }

        private void SetTile(Point point, int index, int id)
        {
            if (id == 0)
            {
                _buffer2D.ClearQuad(index);
                return;
            }

            _buffer2D.SetSrcRectangle(index, Set.GetTile(id));
            _buffer2D.SetDstRectangle(index, GetRectangle(point));
        }

        public Rectangle GetRectangle(Point point)
        {
            var scaled = new Point(point.X * Set.TileSize.Width, point.Y * Set.TileSize.Height);

            return new Rectangle(scaled, Set.TileSize);
        }

        public void SetData(int[] data)
        {
            for (int index = 0; index < data.Length; index++)
            {
                var id = data[index];
                var point = new Point(index % Width, index / Width);

                SetTile(point, index, id);
            }
            _buffer2D.Update();
        }

        public void Update()
        {
            _buffer2D.Update();
        }

        public void Render()
        {
            _buffer2D.Render();
        }
    }
}