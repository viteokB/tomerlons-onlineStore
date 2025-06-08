namespace Presentation.Common;

public interface IPresenterFactoryMethod<TPresenter> where TPresenter : IPresenter
{
    public TPresenter CreatePresenter();
}

public interface IPresenterFactoryMethod<TPresenter, TArg> where TPresenter : IPresenter<TArg>
{
    public TPresenter CreatePresenter();
}