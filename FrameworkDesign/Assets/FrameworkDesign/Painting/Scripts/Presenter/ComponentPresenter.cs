using FrameworkDesign.Painting.View;
using UnityEngine;

namespace FrameworkDesign.Painting.Presenter
{
    public class ComponentPresenter : IComponentPresenter
    {
        private IComponentView _view;

        public IComponentView View
        {
            get
            {
                if (_view != null)
                {
                    return _view;
                }

                _view = ComponentView.Instantiate();
                _view.Presenter = this;

                return _view;
            }
            set => _view = value;
        }

        public void EndInputDesc(string value)
        {
            Debug.Log(value);
        }
    }
}
