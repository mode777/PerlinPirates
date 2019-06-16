using Game.Abstractions.Constants;

namespace Game.Abstractions
{
    public interface IGameComponent
    {
        void Load();
        void Quit();
        void Draw();
        void KeyDown(KeyCode key, ScanCode code, bool isRepeat);
        void KeyUp(KeyCode key, ScanCode code);
        void Update(float delta);
    }
}