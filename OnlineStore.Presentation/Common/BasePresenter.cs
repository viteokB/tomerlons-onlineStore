namespace Presentation.Common;

public abstract class BasePresenter<TIView> : IPresenter
    where TIView : IView
{
    protected TIView _view { get;private set; }

    protected BasePresenter(TIView view)
    {
        _view = view;
    }


    public void Run()
    {
        _view.Show();
    }
}

public abstract class BasePresenter<TIView, TArg> : IPresenter<TArg>
    where TIView : IView
{
    protected TIView _view { get;private set; }

    protected BasePresenter(TIView view)
    {
        _view = view;
    }


    public abstract void Run(TArg arg);
}