using System.Collections.Generic;
using Framework.Component;

namespace FrameworkDesign.Painting.Component
{
    public class BaseEntity : IEntity
    {
        private readonly List<IComponent> _components = new List<IComponent>();
        private int _componentId = int.MinValue;

        public void Inject()
        {
        }

        public void Remove()
        {
        }

        public void AddComponent()
        {
            var component = new BaseComponent
            {
                Id = _componentId
            };
            ++_componentId;
            _components.Add(component);
            component.Init();
        }

        public void SubComponent()
        {
            if (_components.Count <= 0)
            {
                return;
            }

            int idx = _components.Count - 1;
            IComponent component = _components[idx];
            _components.RemoveAt(idx);
            component.Dispose();
        }
    }
}
