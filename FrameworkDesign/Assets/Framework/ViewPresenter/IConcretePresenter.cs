namespace Framework.ViewPresenter
{
    public interface IConcretePresenter<TView> : IPresenter
        where TView : IView
    {
        TView View { get; set; }
    }
}
