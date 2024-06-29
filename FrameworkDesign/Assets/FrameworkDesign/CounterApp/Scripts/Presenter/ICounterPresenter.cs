using Framework.ViewPresenter;
using FrameworkDesign.CounterApp.View;

namespace FrameworkDesign.CounterApp.Presenter
{
    public interface ICounterPresenter : IConcretePresenter<ICounterView>
    {
        void ClickedAdd();
        void ClickedSub();
    }
}
