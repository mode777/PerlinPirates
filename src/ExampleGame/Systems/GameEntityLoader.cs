using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using ECS;
using ExampleGame.Components;
using Game.Abstractions;
using Game.Abstractions.Events;
using Loader.Tmx.Xml;
using Renderer.Gles2;
using Tgl.Net;

namespace ExampleGame.Systems
{
    public class GameEntityLoader : IHandlesLoad
    {
        private readonly World _world;
        private readonly ResourceManager _manager;
        private readonly GlContext _context;
        private readonly Shader2d _shader;

        public GameEntityLoader(World world, ResourceManager manager, GlContext context, Shader2d shader)
        {
            _world = world;
            _manager = manager;
            _context = context;
            _shader = shader;
        }

        public void Load()
        {
            var tiled = _manager.LoadResource<TiledMap>("Resources/Tilemaps/level.tmx");

            CommonTileset tileset;
            var embedded = tiled.Tilesets.First();

            if (embedded.Source != null)
            {
                var path = Path.Combine("Resources/Tilemaps", embedded.Source);
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
            
            var map = new GameMap(tiled.Width, tiled.Height, tiles);

            var texture = _manager.LoadResource<Texture>(Path.Combine("Resources/Tilemaps", tileset.Image.Source));
            var tilesetGl = new Tileset(texture, new Size(tileset.TileWidth, tileset.TileHeight));
            var tilemapGl = new Tilemap(_context, _shader, tilesetGl, tiled.Width, tiled.Height,
                mapData.Select(x => x.Id).ToArray());

            foreach (var entity in entityData.Select((x, i) => new
            {
                x.Id,
                X = i % tiled.Width,
                Y = i / tiled.Width
            }).Where(x => x.Id > 0 && entityLookup.ContainsKey(x.Id)))
            {
                var pos = new PositionComponent(entity.X, entity.Y);
                var sprite = new TileSprite(_context, _shader, tilesetGl, entity.Id);

                var id = _world.CreateEntity(pos, sprite);

                if (entityLookup.TryGetValue(entity.Id, out var type) && type == "player")
                {
                    _world.NameEntity(id, "player");
                    _world.AddComponent(id, new PlayerComponent());
                }
            }

            var mapId = _world.CreateEntity(map, tilemapGl);
            _world.NameEntity(mapId, "map");
        }

        
    }
}
