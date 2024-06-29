using Framework.Bindable;

namespace FrameworkDesign.CounterApp.Model
{
    public static class CounterModel
    {
        public static readonly Bindable<int> BindableCount = Bindable<int>.New(default);
    }
}
