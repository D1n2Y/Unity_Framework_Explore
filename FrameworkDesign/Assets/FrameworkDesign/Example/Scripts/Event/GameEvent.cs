using System;
using System.Collections.Generic;
using UnityEngine.Assertions;

namespace FrameworkDesign.Example.Event
{
    public static class GameEvent
    {
        private static readonly Dictionary<Event, EventHandler<EventArgs>> s_dicEventHandler =
            new Dictionary<Event, EventHandler<EventArgs>>();

        public static void Register(Event @event, EventHandler<EventArgs> handler)
        {
            s_dicEventHandler.TryGetValue(@event, out EventHandler<EventArgs> existedHandler);
            existedHandler += handler;
            s_dicEventHandler[@event] = existedHandler;
        }

        public static void Unregister(Event @event, EventHandler<EventArgs> handler)
        {
            s_dicEventHandler.TryGetValue(@event, out EventHandler<EventArgs> existedHandler);
            existedHandler -= handler;
            s_dicEventHandler[@event] = existedHandler;
        }

        public static void Trigger(Event @event, object sender = null, EventArgs args = null)
        {
            if (s_dicEventHandler.TryGetValue(@event, out EventHandler<EventArgs> handler))
            {
                handler?.Invoke(sender, args);
            }
            else
            {
                Assert.IsFalse(true);
            }
        }
    }
}
