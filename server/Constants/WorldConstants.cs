using System.Collections.Generic;
using System.Drawing;
using WorldServer.Constants;

public static class WorldConstants 
{
    public const int ChunkColumns = 32;
    public const int ChunkRows = 32;
    public const int TileWidth = 16;
    public const int TileHeight = 16;
    public static readonly Rectangle PlayerHitbox = new Rectangle(-4, -6, 8, 12);
    public static readonly Dictionary<TerrainType, TerrainMovement> TerrainMovements = new Dictionary<TerrainType, TerrainMovement>
    {
        [TerrainType.DeepWater] = TerrainMovement.PassableOnWater,
        [TerrainType.ShallowWater] = TerrainMovement.PassableOnWater,
        [TerrainType.Coast] = TerrainMovement.PassableOnLand,
        [TerrainType.Wood] = TerrainMovement.PassableOnLand,
        [TerrainType.Mountain] = TerrainMovement.PassableOnLand,
        [TerrainType.Volcano] = TerrainMovement.Unpassable,
    };

}