using System;

namespace Framework.Component
{
    public interface IComponent
    {
        int Id { get; set; }

        event Action<IComponent> ChangedEvent;

        void Init();
        void Dispose();
        void Change();
    }
}
