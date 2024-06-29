using Framework.Bindable;

namespace FrameworkDesign.Example.Model
{
    public static class GameModel
    {
        public const int GamePassClickedCnt = 10;

        public static readonly Bindable<int> BindableClickedCnt =
            Bindable<int>.New(default);
    }
}
