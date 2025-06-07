namespace Presentation.Common;

public interface IPresenterFactoryMethod<TPresenter> where TPresenter : IPresenter
{
    public TPresenter CreatePresenter();
}