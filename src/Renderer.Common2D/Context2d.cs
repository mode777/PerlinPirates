using System.Drawing;
using Renderer.Common2D.Primitives;
using Renderer.Common2D.Tiles;
using Tgl.Net;

namespace Renderer.Common2D
{
    public class Context2d
    {
        private readonly Shader2d _shader;
        public GlContext GlContext { get; }

        public Context2d(GlContext glContext, Shader2d shader)
        {
            _shader = shader;
            GlContext = glContext;
        }

        public QuadBuffer2D CreateQuadBuffer(Texture texture, int size)
        {
            return new QuadBuffer2D(GlContext, _shader, texture, size);
        }

        public Tilemap CreateTilemap(Tileset set, Size size, int[] data)
        {
            return new Tilemap(GlContext, _shader, set, size, data);
        }

        public TileSprite CreateTileSprite(Tileset set, int index)
        {
            return new TileSprite(GlContext, _shader, set, index);
        }
     }
}