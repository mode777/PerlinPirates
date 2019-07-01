using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ExampleGame.Components;
using Game.Abstractions;
using Loader.Tmx.Xml;

namespace ExampleGame.Loaders
{
    public class GameMapLoader : ResourceLoader<GameMap>
    {
        private readonly ResourceManager _manager;

        public GameMapLoader(ResourceManager manager)
        {
            _manager = manager;
        }
        public override GameMap Load(string rid, Stream stream)
        {
            var tiled = _manager.LoadResource<TiledMap>(rid + ".tmx");

            CommonTileset tileset;
            var embedded = tiled.Tilesets.First();

            if (embedded.Source != null)
            {
                var path = Path.Combine(Path.GetDirectoryName(rid), embedded.Source);
                tileset = _manager.LoadResource<TiledTileset>(path);
            }
            else
            {
                tileset = embedded;
            }

            var terrainLookup = tileset.Tiles.ToDictionary(x => x.Id + 1,
                x => (TerrainType)Enum.Parse(typeof(TerrainType), 
                    x.Properties.Properties.First(y => y.Name == "terrain_type").Value, 
                    true));
            var entityLookup = tileset.Tiles
                .Select(x => new
                {
                    Id = x.Id + 1,
                    Type = x.Properties.Properties.FirstOrDefault(y => y.Name == "entity_type")?.Value
                })
                .Where(x => x.Type != null)
                .ToDictionary(x => x.Id, x => x.Type);

            var mapData = tiled.Layers.First(x => x.Name == "map").Decoded;
            var tiles = mapData.Select(x => new GameTile(terrainLookup[x.Id])).ToArray();

            var entityData = tiled.Layers.First(x => x.Name == "entities").Decoded;

            return new GameMap(tiled.Width, tiled.Height, tiles);
        }
    }
}
