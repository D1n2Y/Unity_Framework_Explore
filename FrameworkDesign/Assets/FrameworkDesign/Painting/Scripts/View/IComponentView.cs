using Framework.ViewPresenter;
using FrameworkDesign.Painting.Presenter;

namespace FrameworkDesign.Painting.View
{
    public interface IComponentView : IConcreteView<IComponentPresenter>
    {
        bool IsTemplate { get; set; }
    }
}
