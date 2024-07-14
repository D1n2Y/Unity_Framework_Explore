using Framework.ViewPresenter;
using FrameworkDesign.Painting.View;

namespace FrameworkDesign.Painting.Presenter
{
    public interface IComponentPresenter : IConcretePresenter<IComponentView>
    {
        void EndInputDesc(string value);
    }
}
