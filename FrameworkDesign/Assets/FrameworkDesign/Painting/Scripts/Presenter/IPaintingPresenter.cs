using Framework.ViewPresenter;
using FrameworkDesign.Painting.View;

namespace FrameworkDesign.Painting.Presenter
{
    public interface IPaintingPresenter : IConcretePresenter<IPaintingView>
    {
        void ClickAddEntity();
        void ClickSubEntity();
        void ClickAddComponent();
        void ClickSubComponent();
    }
}
