using Framework.Command;
using FrameworkDesign.CounterApp.IoC;
using FrameworkDesign.CounterApp.Model;

namespace FrameworkDesign.CounterApp.Command
{
    public struct CounterSub : ICommand
    {
        public void Execute()
        {
            --App.Container.Resolve<CounterModel>().BindableCount.Value;
        }
    }
}
