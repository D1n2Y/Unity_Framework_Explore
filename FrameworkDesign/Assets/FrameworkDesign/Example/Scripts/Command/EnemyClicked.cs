using Framework.Command;
using FrameworkDesign.Example.IoC;
using FrameworkDesign.Example.Model;

namespace FrameworkDesign.Example.Command
{
    public struct EnemyClicked : ICommand
    {
        public static void Exec()
        {
            new EnemyClicked().Execute();
        }

        public void Execute()
        {
            ++GameIoC.Container.Resolve<GameModel>().BindableClickedCnt.Value;
        }
    }
}
