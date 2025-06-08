namespace Presentation.Common;

public interface IModalView : IView
{
    ModalResult ModalResult { get; set; }
}