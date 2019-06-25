namespace ExampleGame.Components
{
    public readonly struct GameTile
    {
        public readonly TerrainType Terrain;

        public GameTile(TerrainType terrain)
        {
            Terrain = terrain;
        }
    }
}