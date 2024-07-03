using Framework.Bindable;
using FrameworkDesign.CounterApp.IoC;
using FrameworkDesign.CounterApp.Utility;

namespace FrameworkDesign.CounterApp.Model
{
    public class CounterModel
    {
        public readonly Bindable<int> BindableCount;

        public CounterModel()
        {
            BindableCount = Bindable<int>.New(App.Container.Resolve<IStorage>().LoadInt(nameof(CounterModel), default));
            BindableCount.ValueChanged +=
                count => App.Container.Resolve<IStorage>().SaveInt(nameof(CounterModel), count);
        }
    }
}
