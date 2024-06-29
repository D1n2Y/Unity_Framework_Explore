using Framework.Event;

namespace FrameworkDesign.Example.Event
{
    public static class GameEvent
    {
        public static readonly EventManager<Event> EventManager =
            new EventManager<Event>();
    }
}
