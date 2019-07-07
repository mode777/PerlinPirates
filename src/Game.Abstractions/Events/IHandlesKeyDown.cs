namespace Game.Abstractions.Events
{
    public interface IHandlesKeyDown
    {
        void KeyDown(KeyDownEvent keydown);
    }
}