namespace Game.Abstractions
{
    public interface IGameComponent
    {
        void Load();
        void Quit();
        void Draw();
        void Update(double delta);
    }
}