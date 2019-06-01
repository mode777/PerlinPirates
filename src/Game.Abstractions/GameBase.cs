namespace Game.Abstractions
{
    public abstract class GameBase : IGame
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

        public virtual void Update(double delta)
        {
        }
    }
}