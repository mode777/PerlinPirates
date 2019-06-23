using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ExampleGame.Entites;
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
                .Where(x => x.Properties.Properties
                    .Any(y => y.Name == "entity_type"))
                .ToDictionary(x => x.Id + 1, 
                    x => (EntityType)Enum.Parse(typeof(EntityType), x.Properties.Properties.First(y => y.Name == "entity_type").Value, 
                        true));

            var mapData = tiled.Layers.First(x => x.Name == "map").Decoded;
            var tiles = mapData.Select(x => new GameTile(terrainLookup[x.Id])).ToArray();

            var entityData = tiled.Layers.First(x => x.Name == "entities").Decoded;
            var entities = entityData.Where(x => x.Id > 0).Select((x, i) => new GameEntity(i, entityLookup[x.Id], i % tiled.Width, i / tiled.Width)).ToArray();

            return new GameMap(tiled.Width, tiled.Height, tiles, entities);
        }
    }
}
