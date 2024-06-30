using Framework.Command;
using FrameworkDesign.CounterApp.Model;

namespace FrameworkDesign.CounterApp.Command
{
    public struct CounterSub : ICommand
    {
        public void Execute()
        {
            --CounterModel.BindableCount.Value;
        }
    }
}
