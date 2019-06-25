using Game.Abstractions.Constants;

namespace Game.Abstractions.Events
{
    public abstract class KeyboardEvent : PlatformEvent
    {
        public KeyCode Key { get; set; }
        public ScanCode ScanCode { get; set; }
        public KeyModifier Modifier { get; set; }
    }
}