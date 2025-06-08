namespace Presentation.Common;

public abstract class BasePresenter<TIView> : IPresenter
    where TIView : IView
{
    public TIView View { get;private set; }

    protected BasePresenter(TIView view)
    {
        View = view;
    }


    public void Run()
    {
        View.Show();
    }
}

public abstract class BasePresenter<TIView, TArg> : IPresenter<TArg>
    where TIView : IView
{
    public TIView View { get;private set; }

    protected BasePresenter(TIView view)
    {
        View = view;
    }


    public abstract void Run(TArg arg);
}