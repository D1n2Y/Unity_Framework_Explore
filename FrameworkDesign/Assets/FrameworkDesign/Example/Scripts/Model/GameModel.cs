using Framework.Bindable;

namespace FrameworkDesign.Example.Model
{
    public class GameModel
    {
        public const int GamePassClickedCnt = 10;

        public readonly Bindable<int> BindableClickedCnt =
            Bindable<int>.New(default);
    }
}
