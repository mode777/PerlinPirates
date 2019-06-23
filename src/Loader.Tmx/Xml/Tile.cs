namespace Loader.Tmx.Xml
{
    public struct Tile
    {
        private readonly uint _gid;

        public Tile(uint gid)
        {
            _gid = gid;
        }

        public bool FlippedHorizontally => ((TileFlags)_gid).HasFlag(TileFlags.FlippedHorizontally);
        public bool FlippedVertically => ((TileFlags)_gid).HasFlag(TileFlags.FlippedVertically);
        public bool FlippedDiagonally => ((TileFlags)_gid).HasFlag(TileFlags.FlippedDiagonally);
        public int Id => (int) (_gid & ~(uint) TileFlags.All);
    }
}