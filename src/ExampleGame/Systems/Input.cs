using ECS;
using ExampleGame.Components;
using Game.Abstractions;
using Game.Abstractions.Constants;
using Game.Abstractions.Events;

namespace ExampleGame.Systems
{
    public class Input : IHandlesUpdate
    {
        private readonly InputState _state;
        private readonly World _world;

        private bool up = false;
        private bool down = false;
        private bool left = false;
        private bool right = false;

        public Input(InputState state, World world)
        {
            _state = state;
            _world = world;
        }

        public void Update(float delta)
        {
            MovementComponent movement = null;

            if (_state.IsKeyDown(KeyCode.LEFT) && !left)
            {
                left = true;
                movement = new MovementComponent(-1,0);
            }

            if (_state.IsKeyDown(KeyCode.RIGHT) && !right)
            {
                right = true;
                movement = new MovementComponent(1, 0);
            }

            if (_state.IsKeyDown(KeyCode.UP) && !up)
            {
                up = true;
                movement = new MovementComponent(0, -1);
            }

            if (_state.IsKeyDown(KeyCode.DOWN) && !down)
            {
                down = true;
                movement = new MovementComponent(0, 1);
            }

            if (movement != null)
            {
                _world.AddComponent(_world.IdForName("player"), movement);
            }
            else
            {
                left = false;
                right = false;
                up = false;
                down = false;
                _world.RemoveComponent<MovementComponent>(_world.IdForName("player"));
            }
        }
    }
}