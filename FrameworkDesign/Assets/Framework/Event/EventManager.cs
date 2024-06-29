using System;
using System.Collections.Generic;

namespace Framework.Event
{
    public class EventManager<TEnum>
        where TEnum : Enum
    {
        private readonly Dictionary<TEnum, EventHandler<EventArgs>> _dicEventHandler =
            new Dictionary<TEnum, EventHandler<EventArgs>>();

        public void Register(TEnum @event, EventHandler<EventArgs> handler)
        {
            _dicEventHandler.TryGetValue(@event, out EventHandler<EventArgs> existedHandler);
            existedHandler += handler;
            _dicEventHandler[@event] = existedHandler;
        }

        public void Unregister(TEnum @event, EventHandler<EventArgs> handler)
        {
            _dicEventHandler.TryGetValue(@event, out EventHandler<EventArgs> existedHandler);
            existedHandler -= handler;
            _dicEventHandler[@event] = existedHandler;
        }

        public void Trigger(TEnum @event, object sender = null, EventArgs args = null)
        {
            _dicEventHandler.TryGetValue(@event, out EventHandler<EventArgs> handler);
            handler?.Invoke(sender, args);
        }
    }
}
