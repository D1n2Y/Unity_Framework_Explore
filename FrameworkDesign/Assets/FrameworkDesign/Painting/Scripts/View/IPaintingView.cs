using Framework.ViewPresenter;
using FrameworkDesign.Painting.Presenter;

namespace FrameworkDesign.Painting.View
{
    public interface IPaintingView : IConcreteView<IPaintingPresenter>
    {
        void AddEntity();
        void SubEntity();
    }
}
