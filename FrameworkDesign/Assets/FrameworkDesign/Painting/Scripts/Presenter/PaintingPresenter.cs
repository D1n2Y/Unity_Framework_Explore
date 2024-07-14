using System.Collections.Generic;
using Framework.Component;
using FrameworkDesign.Painting.Component;
using FrameworkDesign.Painting.View;

namespace FrameworkDesign.Painting.Presenter
{
    public class PaintingPresenter : IPaintingPresenter
    {
        private readonly List<IEntity> _entities = new List<IEntity>();

        private IEntity _curEntity;

        public IPaintingView View { get; set; }

        public void ClickAddEntity()
        {
            var entity = new BaseEntity();
            entity.Inject();
            _entities.Add(entity);
            _curEntity = entity;

            View.AddEntity();
        }

        public void ClickSubEntity()
        {
            View.SubEntity();

            _entities.Remove(_curEntity);
            _curEntity?.Remove();
            _curEntity = null;
            if (_entities.Count > 0)
            {
                _curEntity = _entities[_entities.Count - 1];
            }
        }

        public void ClickAddComponent()
        {
            if (_curEntity is BaseEntity entity)
            {
                entity.AddComponent();
            }
        }

        public void ClickSubComponent()
        {
            if (_curEntity is BaseEntity entity)
            {
                entity.SubComponent();
            }
        }
    }
}
