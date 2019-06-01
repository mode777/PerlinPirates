namespace Game.Abstractions
{
    public interface IGame
    {
        void Load();
        void Quit();
        void Draw();
        void Update(double delta);
    }
}