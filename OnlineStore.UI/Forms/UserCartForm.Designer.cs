using System.ComponentModel;

namespace OnlineStore.UI.Forms;

partial class UserCartForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        label1 = new System.Windows.Forms.Label();
        dataGridView = new System.Windows.Forms.DataGridView();
        btnRefresh = new System.Windows.Forms.Button();
        btnCancelOrder = new System.Windows.Forms.Button();
        lblTotal = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        label1.Location = new System.Drawing.Point(204, 9);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(124, 23);
        label1.TabIndex = 0;
        label1.Text = "МОИ ЗАКАЗЫ";
        // 
        // dataGridView
        // 
        dataGridView.ColumnHeadersHeight = 29;
        dataGridView.Location = new System.Drawing.Point(23, 35);
        dataGridView.Name = "dataGridView";
        dataGridView.RowHeadersWidth = 51;
        dataGridView.Size = new System.Drawing.Size(453, 304);
        dataGridView.TabIndex = 3;
        // 
        // btnRefresh
        // 
        btnRefresh.Location = new System.Drawing.Point(159, 355);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Size = new System.Drawing.Size(135, 42);
        btnRefresh.TabIndex = 4;
        btnRefresh.Text = "Обновить заказ";
        btnRefresh.UseVisualStyleBackColor = true;
        // 
        // btnCancelOrder
        // 
        btnCancelOrder.Location = new System.Drawing.Point(23, 355);
        btnCancelOrder.Name = "btnCancelOrder";
        btnCancelOrder.Size = new System.Drawing.Size(130, 42);
        btnCancelOrder.TabIndex = 5;
        btnCancelOrder.Text = "Отменить заказ";
        btnCancelOrder.UseVisualStyleBackColor = true;
        // 
        // lblTotal
        // 
        lblTotal.Location = new System.Drawing.Point(376, 366);
        lblTotal.Name = "lblTotal";
        lblTotal.Size = new System.Drawing.Size(100, 23);
        lblTotal.TabIndex = 6;
        // 
        // UserCartForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(504, 409);
        Controls.Add(lblTotal);
        Controls.Add(btnCancelOrder);
        Controls.Add(btnRefresh);
        Controls.Add(dataGridView);
        Controls.Add(label1);
        Text = "UserCartForm";
        ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button btnRefresh;
    private System.Windows.Forms.Label lblTotal;

    private System.Windows.Forms.Button btnCancelOrder;

    private System.Windows.Forms.DataGridView dataGridView;

    private System.Windows.Forms.Label label1;

    #endregion
}