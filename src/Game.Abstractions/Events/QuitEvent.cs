using Game.Abstractions.Constants;

namespace Game.Abstractions.Events
{
    public class QuitEvent : PlatformEvent
    {
    }

    public class KeyDownEvent : KeyboardEvent
    {
    }

    public class KeyUpEvent : KeyboardEvent
    {
    }

    public abstract class KeyboardEvent : PlatformEvent
    {
        public KeyCode Key { get; set; }
        public ScanCode ScanCode { get; set; }
        public bool IsRepeat { get; set; }
        public KeyModifier Modifier { get; set; }
    }
}