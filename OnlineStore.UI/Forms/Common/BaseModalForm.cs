using Presentation.Common;

namespace OnlineStore.UI.Forms.Common;

public class BaseModalForm : Form, IModalView
{
    public ModalResult ModalResult { get; set; } = ModalResult.None;

    public new void Show()
    {
        this.FormClosing -= OnFormClosing;
        this.FormClosing += OnFormClosing;
        
        base.ShowDialog();
    }

    private void OnFormClosing(object sender, FormClosingEventArgs e)
    {
        this.ModalResult = ConvertDialogResultToModalResult(base.DialogResult);
    }
    
    public void SetModalResult(ModalResult modalResult)
    {
        this.ModalResult = modalResult;
        this.DialogResult = ConvertModalResultToDialogResult(modalResult);
    }

    private static ModalResult ConvertDialogResultToModalResult(DialogResult? dialogResult)
    {
        return dialogResult switch
        {
            DialogResult.OK => ModalResult.Ok,
            DialogResult.Cancel => ModalResult.Cancel,
            DialogResult.Yes => ModalResult.Yes,
            DialogResult.No => ModalResult.No,
            DialogResult.Abort => ModalResult.Abort,
            DialogResult.Retry => ModalResult.Retry,
            DialogResult.Ignore => ModalResult.Ignore,
            _ => ModalResult.None,
        };
    }

    private static DialogResult ConvertModalResultToDialogResult(ModalResult modalResult)
    {
        return modalResult switch
        {
            ModalResult.Ok => DialogResult.OK,
            ModalResult.Cancel => DialogResult.Cancel,
            ModalResult.Yes => DialogResult.Yes,
            ModalResult.No => DialogResult.No,
            ModalResult.Abort => DialogResult.Abort,
            ModalResult.Retry => DialogResult.Retry,
            ModalResult.Ignore => DialogResult.Ignore,
            _ => DialogResult.None,
        };
    }
}

public class BaseModalForm<T> : BaseModalForm, IModalView<T>
{
    public T? ModalResultData { get; set; }
}