using Presentation.Common;
using Presentation.Views;

namespace Presentation.Presenters;

public class MainPresenter : BasePresenter<IMainView>
{
    public MainPresenter(IMainView view) : base(view)
    {
    }
}