namespace Game.Abstractions
{
    public abstract class GameComponent : IGameComponent
    {
        public virtual void Draw()
        {
        }

        public virtual void Load()
        {
        }

        public virtual void Quit()
        {
        }

        public virtual void Update(float delta)
        {
        }
    }
}