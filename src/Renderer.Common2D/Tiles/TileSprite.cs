using System.Drawing;
using Renderer.Common2D.Primitives;
using Tgl.Net;

namespace Renderer.Common2D.Tiles
{
    public class TileSprite
    {
        private readonly QuadBuffer2D _buffer2D;

        public Tileset Set { get; }

        public TileSprite(GlContext context, Shader2d shader, Tileset set, int index)
        {
            Set = set;
            _buffer2D = new QuadBuffer2D(context, shader, Set.Texture, 1);
            SetPosition(new Point(0,0));
            SetTile(index);
        }

        public void SetPosition(Point point)
        {
            _buffer2D.SetDstRectangle(0, GetRectangle(point));

            _buffer2D.Update();
        }

        public void SetTile(int id)
        {
            if(id == 0)
                _buffer2D.ClearQuad(0);

            _buffer2D.SetSrcRectangle(0, Set.GetTile(id));

            _buffer2D.Update();
        }
        
        public Rectangle GetRectangle(Point point)
        {
            var scaled = new Point(point.X * Set.TileSize.Width, point.Y * Set.TileSize.Height);

            return new Rectangle(scaled, Set.TileSize);
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