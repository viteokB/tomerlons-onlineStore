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
        ordersDataGridView = new System.Windows.Forms.DataGridView();
        lblPageInfo = new System.Windows.Forms.Label();
        btnLoad = new System.Windows.Forms.Button();
        btnCreate = new System.Windows.Forms.Button();
        btnCancel = new System.Windows.Forms.Button();
        btnDetails = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)ordersDataGridView).BeginInit();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(204, 9);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(124, 23);
        label1.TabIndex = 0;
        label1.Text = "МОИ ЗАКАЗЫ";
        // 
        // ordersDataGridView
        // 
        ordersDataGridView.ColumnHeadersHeight = 29;
        ordersDataGridView.Location = new System.Drawing.Point(38, 36);
        ordersDataGridView.Name = "ordersDataGridView";
        ordersDataGridView.RowHeadersWidth = 51;
        ordersDataGridView.Size = new System.Drawing.Size(488, 276);
        ordersDataGridView.TabIndex = 1;
        // 
        // lblPageInfo
        // 
        lblPageInfo.Location = new System.Drawing.Point(229, 342);
        lblPageInfo.Name = "lblPageInfo";
        lblPageInfo.Size = new System.Drawing.Size(297, 23);
        lblPageInfo.TabIndex = 2;
        lblPageInfo.Text = "label2";
        // 
        // btnLoad
        // 
        btnLoad.Location = new System.Drawing.Point(545, 36);
        btnLoad.Name = "btnLoad";
        btnLoad.Size = new System.Drawing.Size(96, 33);
        btnLoad.TabIndex = 3;
        btnLoad.Text = "btnLoad";
        btnLoad.UseVisualStyleBackColor = true;
        // 
        // btnCreate
        // 
        btnCreate.Location = new System.Drawing.Point(545, 95);
        btnCreate.Name = "btnCreate";
        btnCreate.Size = new System.Drawing.Size(96, 33);
        btnCreate.TabIndex = 4;
        btnCreate.Text = "btnCreate";
        btnCreate.UseVisualStyleBackColor = true;
        // 
        // btnCancel
        // 
        btnCancel.Location = new System.Drawing.Point(545, 156);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new System.Drawing.Size(96, 33);
        btnCancel.TabIndex = 5;
        btnCancel.Text = "btnCancel";
        btnCancel.UseVisualStyleBackColor = true;
        // 
        // btnDetails
        // 
        btnDetails.Location = new System.Drawing.Point(545, 216);
        btnDetails.Name = "btnDetails";
        btnDetails.Size = new System.Drawing.Size(96, 33);
        btnDetails.TabIndex = 6;
        btnDetails.Text = "btnDetails";
        btnDetails.UseVisualStyleBackColor = true;
        // 
        // UserCartForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(653, 401);
        Controls.Add(btnDetails);
        Controls.Add(btnCancel);
        Controls.Add(btnCreate);
        Controls.Add(btnLoad);
        Controls.Add(lblPageInfo);
        Controls.Add(ordersDataGridView);
        Controls.Add(label1);
        Text = "UserCartForm";
        ((System.ComponentModel.ISupportInitialize)ordersDataGridView).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button btnDetails;

    private System.Windows.Forms.Button btnLoad;
    private System.Windows.Forms.Button btnCreate;
    private System.Windows.Forms.Button btnCancel;

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DataGridView ordersDataGridView;
    private System.Windows.Forms.Label lblPageInfo;

    #endregion
}