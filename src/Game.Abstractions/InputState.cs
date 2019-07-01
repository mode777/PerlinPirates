using System;
using System.Collections.Generic;
using System.Text;
using Game.Abstractions.Constants;
using Game.Abstractions.Events;

namespace Game.Abstractions
{
    public class InputState
    {
        private readonly Dictionary<KeyCode, bool> _keys = new Dictionary<KeyCode, bool>();
        private readonly Dictionary<ScanCode, bool> _scancodes = new Dictionary<ScanCode, bool>();
        private KeyModifier _modifier = KeyModifier.NONE;

        public void OnKeyUp(KeyUpEvent ev)
        {
            _keys[ev.Key] = false;
            _scancodes[ev.ScanCode] = false;
            _modifier = ev.Modifier;
        }

        public void OnKeyDown(KeyDownEvent ev)
        {
            _keys[ev.Key] = true;
            _scancodes[ev.ScanCode] = true;
            _modifier = ev.Modifier;
        }

        public KeyModifier Modifier => _modifier;

        public bool IsKeyDown(KeyCode code)
        {
            if (_keys.TryGetValue(code, out var val))
            {
                return val;
            }

            return false;
        }

        public bool IsScancodeDown(ScanCode code)
        {
            if (_scancodes.TryGetValue(code, out var val))
            {
                return val;
            }

            return false;
        }


    }
}
