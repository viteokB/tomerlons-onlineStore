using Presentation.Common;
using Presentation.Views;

namespace Presentation.Presenters;

public class AuthorPresenter : BasePresenter<IAuthorView>
{
    public AuthorPresenter(IAuthorView view) : base(view)
    {
    }
}