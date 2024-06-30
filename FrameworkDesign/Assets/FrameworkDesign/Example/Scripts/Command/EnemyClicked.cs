using Framework.Command;
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
            ++GameModel.BindableClickedCnt.Value;
        }
    }
}
