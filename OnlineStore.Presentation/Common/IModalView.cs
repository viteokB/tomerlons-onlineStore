namespace Presentation.Common;

public interface IModalView : IView
{
    ModalResult ModalResult { get; set; }

    public void SetModalResult(ModalResult modalResult);
}

public interface IModalView<T> : IView
{
    ModalResult ModalResult { get; set; }
    
    T? ModalResultData { get; set; }
    
    public void SetModalResult(ModalResult modalResult);
}