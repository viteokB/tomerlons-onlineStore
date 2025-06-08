using Presentation.Common;

namespace OnlineStore.UI.Forms.Common;

public class BaseModalForm : Form, IModalView
{
    public ModalResult ModalResult { get; set; }

    public new void Show()
    {
        this.FormClosing += (s, e) =>
        {
            this.ModalResult = ConvertDialogResultToModalResult(base.DialogResult);
        };

        base.ShowDialog();
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
}