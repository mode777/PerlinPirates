using System.Drawing;
using ECS;
using ExampleGame.Components;
using Game.Abstractions.Events;

namespace ExampleGame.Systems
{
    public class Movement : IHandlesUpdate
    {
        private readonly World _world;

        public Movement(World world)
        {
            _world = world;
        }

        public void Update(float delta)
        {
            var map = _world.Component<GameMap>(_world.IdForName("map"));

            foreach (var (id, position, movement) in _world.Enumerate<PositionComponent, MovementComponent>())
            {
                var target = new Point(position.Value.X + movement.Value.X, position.Value.Y + movement.Value.Y);

                var tile = map.GetTile(target);

                if (tile.Terrain == TerrainType.Ground)
                {
                    _world.RemoveComponent<MovementComponent>(id);
                    _world.AddComponent(id, new PositionComponent(target.X, target.Y));
                }

            }
        }
    }
}