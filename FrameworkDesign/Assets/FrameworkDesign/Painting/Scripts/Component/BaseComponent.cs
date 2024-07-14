using System;
using Framework.Component;
using FrameworkDesign.Painting.Presenter;
using FrameworkDesign.Painting.View;

namespace FrameworkDesign.Painting.Component
{
    public class BaseComponent : IComponent
    {
        private IComponentPresenter _presenter;
        private IComponentView _view;

        public int Id { get; set; }

        public event Action<IComponent> ChangedEvent;

        public void Init()
        {
            _presenter = new ComponentPresenter();
            _view = _presenter.View;
        }

        public void Dispose()
        {
            if (_view is ComponentView view)
            {
                ComponentView.Destroy(view);
            }

            _view = null;
            _presenter = null;
        }

        public void Change()
        {
            ChangedEvent?.Invoke(this);
        }
    }
}
