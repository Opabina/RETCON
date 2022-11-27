namespace RETCON.Core.Event
{
    public class WindowResizeEvent : BaseEvent
    {
        private uint _width;
        private uint _height;

        public WindowResizeEvent(uint width, uint height)
        {
            _width = width;
            _height = height;

            _category = EventCategory.Window;
            _type = EventType.WindowResize;
        }

        uint GetWidth() { return _width; }
        uint GetHeight() { return _height; }

        public override string ToString()
        {
            return $"{nameof(WindowResizeEvent)}: {_width}, {_height}";
        }
    }

    public class WindowCloseEvent : BaseEvent
    {
        public WindowCloseEvent()
        {
            _category = EventCategory.Window;
            _type = EventType.WindowClose;
        }
    }

    //TODO: Add Window public class as parameters
    public class WindowOpenEvent : BaseEvent
    {
        public WindowOpenEvent()
        {
            _category = EventCategory.Window;
            _type = EventType.WindowOpen;
        }
    }

    public class WindowFocusEvent : BaseEvent
    {
        public WindowFocusEvent()
        {
            _category = EventCategory.Window;
            _type = EventType.WindowFocus;
        }
    }

    public class WindowLostFocusEvent : BaseEvent
    {
        public WindowLostFocusEvent()
        {
            _category = EventCategory.Window;
            _type = EventType.WindowFocus;
        }
    }

    public class WindowMovedEvent : BaseEvent
    {
        private uint _x;
        private uint _y;

        public uint GetX() { return _x; }
        public uint GetY() { return _y; }

        public WindowMovedEvent(uint x, uint y)
        {
            _x = x;
            _y = y;

            _category = EventCategory.Window;
            _type = EventType.WindowMoved;
        }

        public override string ToString()
        {
            return $"{nameof(WindowMovedEvent)}: {_x}, {_y}";
        }
    }

    // Application Events
    public class AppTickEvent : BaseEvent
    {
        public AppTickEvent()
        {
            _category = EventCategory.Application;
            _type = EventType.AppTick;
        }
    }

    public class AppUpdateEvent : BaseEvent
    {
        private float _dt; // dt = Delta Time (time since last update)

        public float GetDeltaTime() { return _dt; }

        public AppUpdateEvent(float dt)
        {
            _dt = dt;

            _category = EventCategory.Application;
            _type = EventType.AppUpdate;
        }
    }

    public class AppRenderEvent : BaseEvent
    {
        public AppRenderEvent()
        {
            _category = EventCategory.Application;
            _type = EventType.AppRender;
        }
    }
}
