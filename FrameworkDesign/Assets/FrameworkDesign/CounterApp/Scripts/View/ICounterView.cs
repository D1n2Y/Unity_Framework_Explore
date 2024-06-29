using Framework.ViewPresenter;
using FrameworkDesign.CounterApp.Presenter;

namespace FrameworkDesign.CounterApp.View
{
    public interface ICounterView : IConcreteView<ICounterPresenter>
    {
        void SetCount(string value);
    }
}
