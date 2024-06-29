namespace Framework.ViewPresenter
{
    public interface IConcreteView<TPresenter> : IView
        where TPresenter : IPresenter
    {
        TPresenter Presenter { get; set; }
    }
}
