namespace Game.Abstractions.Events
{
    public class KeyDownEvent : KeyboardEvent
    {
        public bool IsRepeat { get; set; }
    }
}