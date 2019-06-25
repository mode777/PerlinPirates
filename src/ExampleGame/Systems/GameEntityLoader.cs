using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using ECS;
using ExampleGame.Components;
using Game.Abstractions;
using Game.Abstractions.Events;
using Loader.Tmx.Xml;

namespace ExampleGame.Systems
{
    public class GameEntityLoader : IHandlesLoad
    {
        private readonly World _world;
        private readonly ResourceManager _manager;

        public GameEntityLoader(World world, ResourceManager manager)
        {
            _world = world;
            _manager = manager;
        }

        public void Load()
        {
            var tiled = _manager.LoadResource<TiledMap>("Resources/Tilemaps/level.tmx");

            CommonTileset tileset;
            var embedded = tiled.Tilesets.First();

            if (embedded.Source != null)
            {
                var path = Path.Combine("Resource/Tilemaps", embedded.Source);
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

            var map = new GameMap(tiled.Width, tiled.Height, tiles, entities);

            var mapEntity = _world.CreateEntity();
            _world.AddComponent(mapEntity, map);
        }
    }
}
