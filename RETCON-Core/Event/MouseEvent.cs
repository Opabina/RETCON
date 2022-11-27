namespace RETCON.Core.Event
{
    public class MouseMovedEvent : BaseEvent
    {
        private float _x;
        private float _y;

        public float GetX() { return _x; }
        public float GetY() { return _y; }

        public MouseMovedEvent(float x, float y)
        {
            _x = x;
            _y = y;

            _category = EventCategory.Input | EventCategory.Mouse;
            _type = EventType.MouseMoved;
        }

        public override string ToString()
        {
            return $"{nameof(MouseMovedEvent)}: {_x}, {_y}";
        }
    }

    public class MouseScrolledEvent : BaseEvent
    {
        private float _xOffset;
        private float _yOffset;

        public float GetXOffset() { return _xOffset; }
        public float GetYOffset() { return _yOffset; }

        public MouseScrolledEvent(float xOffset, float yOffset)
        {
            _xOffset = xOffset;
            _yOffset = yOffset;

            _category = EventCategory.Input | EventCategory.Mouse;
            _type = EventType.MouseScrolled;
        }

        public override string ToString()
        {
            return $"{nameof(MouseScrolledEvent)}: {_xOffset}, {_yOffset}";
        }
    }

    public class MouseButtonEvent : BaseEvent
    {
        protected ushort _button;

        public ushort GetMouseButton() { return _button; }

        protected MouseButtonEvent(ushort button)
        {
            _button = button;

            _category = EventCategory.Input | EventCategory.Mouse | EventCategory.MouseButton;
        }
    }

    public class MouseButtonClickedEvent : MouseButtonEvent
    {
        public MouseButtonClickedEvent(ushort button) : base(button)
        {
            _button = button;

            _type = EventType.MouseButtonClicked;
        }

        public override string ToString()
        {
            return $"{nameof(MouseButtonClickedEvent)}: {_button}";
        }
    }

    public class MouseButtonReleasedEvent : MouseButtonEvent
    {
        public MouseButtonReleasedEvent(ushort button) : base(button)
        {
            _button = button;

            _type = EventType.MouseButtonReleased;
        }

        public override string ToString()
        {
            return $"{nameof(MouseButtonReleasedEvent)}: {_button}";
        }
    }
}
