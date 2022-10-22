using System;

/*
 * DISCLAIMER:
 * Most of the event code found here is taken from TheCherno, who is developing
 * a game engine called "Hazel" (https://github.com/TheCherno/Hazel)
 * 
 * Please check out their project as it's truly amazing!
 * We'll be rewriting this code in the future to not copy Hazels Engine Code.
*/ 

namespace RETCON.Core.Event
{
    public enum EventType
    {
        Undefined = 0,

        // Window
        WindowOpen, WindowClose, WindowResize, WindowFocus, WindowLostFocus, WindowMoved,

        // App
        AppTick, AppUpdate, AppRender,

        // Keys
        KeyPressed, KeyReleased, KeyTyped,

        // Mouse
        MouseMoved, MouseScrolled, MouseButtonClicked, MouseButtonReleased
    }

    public enum EventCategory
    {
        Undefined = 0,
        Window,
        Application,
        Input,
        Keyboard,
        Mouse,
        MouseButton
    }

    public class BaseEvent
    {
        protected EventCategory _category;
        protected EventType _type;

        public bool IsHandled = false;

        public virtual void Dispatch() { }

        public static int GetCategoryFlags(EventCategory category)
        {
            return (int)category;
        }

        public bool IsInCategory(EventCategory search)
        {
            return _category == search;
        }

        public virtual EventType GetEventType()
        {
            return _type;
        }

        public override string ToString()
        {
            var name = Enum.GetName(typeof(EventType), _type);
            return name ?? "Undefined";
        }
    }

    public class EventDispatcher
    {
        private BaseEvent _event;

        public EventDispatcher(BaseEvent arg)
        {
            _event = arg;
        }


        public bool Dispatch()
        {
            if(!_event.IsHandled)
            {
                _event.Dispatch();
                _event.IsHandled = true;

                return true;
            }

            return false;
        }
    }
}