namespace RETCON.Core.Event
{
    public class KeyEvent : BaseEvent
    {
        protected ushort _keyCode;
        public ushort GetKeyCode() { return _keyCode; }

        protected KeyEvent(ushort keyCode)
        {
            _keyCode = keyCode;
            _category = EventCategory.Keyboard | EventCategory.Input;
        }
    }

    public class KeyPressedEvent : KeyEvent
    {
        private bool _isRepeat;

        public KeyPressedEvent(ushort keyCode, bool isRepeat) : base(keyCode)
        {
            _keyCode = keyCode;
            _isRepeat = isRepeat;

            _type = EventType.KeyPressed;
        }

        public override string ToString()
        {
            return $"{nameof(KeyPressedEvent)}: {_keyCode} (IsRepeat: {_isRepeat})";
        }
    }

    public class KeyReleasedEvent : KeyEvent
    {
        public KeyReleasedEvent(ushort keyCode) : base(keyCode)
        {
            _keyCode = keyCode;

            _type = EventType.KeyReleased;
        }

        public override string ToString()
        {
            return $"{nameof(KeyReleasedEvent)}: {_keyCode}";
        }
    }
    
    public class KeyTypedEvent : KeyEvent
    {
        public KeyTypedEvent(ushort keyCode) : base(keyCode)
        {
            _keyCode = keyCode;

            _type = EventType.KeyTyped;
        }

        public override string ToString()
        {
            return $"{nameof(KeyTypedEvent)}: {_keyCode}";
        }
    }
}
