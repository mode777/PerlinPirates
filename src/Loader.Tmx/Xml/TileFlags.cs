namespace Loader.Tmx.Xml
{
    public enum TileFlags : uint
    {
        FlippedHorizontally = 0x80000000,
        FlippedVertically = 0x40000000,
        FlippedDiagonally = 0x20000000,
        All = FlippedHorizontally | FlippedVertically | FlippedDiagonally
    }
}