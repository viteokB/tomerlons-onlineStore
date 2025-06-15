using System.ComponentModel;

namespace OnlineStore.UI.Forms;

partial class AdminOrdersForm
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
        components = new System.ComponentModel.Container();
        ordersDataGridView = new System.Windows.Forms.DataGridView();
        cmbStatus = new System.Windows.Forms.ComboBox();
        btnSearch = new System.Windows.Forms.Button();
        btnUpdateStatus = new System.Windows.Forms.Button();
        btnDetails = new System.Windows.Forms.Button();
        lblPageInfo = new System.Windows.Forms.Label();
        txtStatusName = new System.Windows.Forms.TextBox();
        label1 = new System.Windows.Forms.Label();
        txtStatusDesc = new System.Windows.Forms.RichTextBox();
        label2 = new System.Windows.Forms.Label();
        chkActive = new System.Windows.Forms.CheckBox();
        btnLoadStatuses = new System.Windows.Forms.Button();
        btnAddStatus = new System.Windows.Forms.Button();
        bindingSource1 = new System.Windows.Forms.BindingSource(components);
        btnDeleteStatus = new System.Windows.Forms.Button();
        statusBindingSource = new System.Windows.Forms.BindingSource(components);
        label3 = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)ordersDataGridView).BeginInit();
        ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)statusBindingSource).BeginInit();
        SuspendLayout();
        // 
        // ordersDataGridView
        // 
        ordersDataGridView.ColumnHeadersHeight = 29;
        ordersDataGridView.Location = new System.Drawing.Point(12, 21);
        ordersDataGridView.Name = "ordersDataGridView";
        ordersDataGridView.RowHeadersWidth = 51;
        ordersDataGridView.Size = new System.Drawing.Size(485, 302);
        ordersDataGridView.TabIndex = 0;
        // 
        // cmbStatus
        // 
        cmbStatus.FormattingEnabled = true;
        cmbStatus.Location = new System.Drawing.Point(642, 16);
        cmbStatus.Name = "cmbStatus";
        cmbStatus.Size = new System.Drawing.Size(233, 28);
        cmbStatus.TabIndex = 1;
        // 
        // btnSearch
        // 
        btnSearch.Location = new System.Drawing.Point(12, 329);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new System.Drawing.Size(88, 33);
        btnSearch.TabIndex = 2;
        btnSearch.Text = "btnSearch";
        btnSearch.UseVisualStyleBackColor = true;
        // 
        // btnUpdateStatus
        // 
        btnUpdateStatus.Location = new System.Drawing.Point(126, 329);
        btnUpdateStatus.Name = "btnUpdateStatus";
        btnUpdateStatus.Size = new System.Drawing.Size(93, 33);
        btnUpdateStatus.TabIndex = 3;
        btnUpdateStatus.Text = "btnUpdateStatus";
        btnUpdateStatus.UseVisualStyleBackColor = true;
        // 
        // btnDetails
        // 
        btnDetails.Location = new System.Drawing.Point(256, 329);
        btnDetails.Name = "btnDetails";
        btnDetails.Size = new System.Drawing.Size(93, 33);
        btnDetails.TabIndex = 4;
        btnDetails.Text = "btnDetails";
        btnDetails.UseVisualStyleBackColor = true;
        // 
        // lblPageInfo
        // 
        lblPageInfo.Location = new System.Drawing.Point(12, 383);
        lblPageInfo.Name = "lblPageInfo";
        lblPageInfo.Size = new System.Drawing.Size(521, 23);
        lblPageInfo.TabIndex = 5;
        lblPageInfo.Text = "lblPageInfo";
        // 
        // txtStatusName
        // 
        txtStatusName.Location = new System.Drawing.Point(642, 60);
        txtStatusName.Name = "txtStatusName";
        txtStatusName.Size = new System.Drawing.Size(233, 27);
        txtStatusName.TabIndex = 7;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(514, 64);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(107, 23);
        label1.TabIndex = 8;
        label1.Text = "txtStatusName";
        // 
        // txtStatusDesc
        // 
        txtStatusDesc.Location = new System.Drawing.Point(642, 113);
        txtStatusDesc.Name = "txtStatusDesc";
        txtStatusDesc.Size = new System.Drawing.Size(233, 128);
        txtStatusDesc.TabIndex = 9;
        txtStatusDesc.Text = "";
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(521, 116);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(100, 23);
        label2.TabIndex = 10;
        label2.Text = "txtStatusDesc ";
        // 
        // chkActive
        // 
        chkActive.Location = new System.Drawing.Point(642, 247);
        chkActive.Name = "chkActive";
        chkActive.Size = new System.Drawing.Size(104, 24);
        chkActive.TabIndex = 14;
        chkActive.Text = "chkActive";
        chkActive.UseVisualStyleBackColor = true;
        // 
        // btnLoadStatuses
        // 
        btnLoadStatuses.Location = new System.Drawing.Point(546, 301);
        btnLoadStatuses.Name = "btnLoadStatuses";
        btnLoadStatuses.Size = new System.Drawing.Size(75, 38);
        btnLoadStatuses.TabIndex = 15;
        btnLoadStatuses.Text = "btnLoadStatuses";
        btnLoadStatuses.UseVisualStyleBackColor = true;
        // 
        // btnAddStatus
        // 
        btnAddStatus.Location = new System.Drawing.Point(653, 301);
        btnAddStatus.Name = "btnAddStatus";
        btnAddStatus.Size = new System.Drawing.Size(75, 38);
        btnAddStatus.TabIndex = 16;
        btnAddStatus.Text = "btnAddStatus";
        btnAddStatus.UseVisualStyleBackColor = true;
        // 
        // btnDeleteStatus
        // 
        btnDeleteStatus.Location = new System.Drawing.Point(758, 301);
        btnDeleteStatus.Name = "btnDeleteStatus";
        btnDeleteStatus.Size = new System.Drawing.Size(75, 38);
        btnDeleteStatus.TabIndex = 17;
        btnDeleteStatus.Text = "btnDeleteStatus";
        btnDeleteStatus.UseVisualStyleBackColor = true;
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(521, 21);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(100, 23);
        label3.TabIndex = 18;
        label3.Text = "Поиск";
        // 
        // AdminOrdersForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(922, 420);
        Controls.Add(label3);
        Controls.Add(btnDeleteStatus);
        Controls.Add(btnAddStatus);
        Controls.Add(btnLoadStatuses);
        Controls.Add(chkActive);
        Controls.Add(label2);
        Controls.Add(txtStatusDesc);
        Controls.Add(label1);
        Controls.Add(txtStatusName);
        Controls.Add(lblPageInfo);
        Controls.Add(btnDetails);
        Controls.Add(btnUpdateStatus);
        Controls.Add(btnSearch);
        Controls.Add(cmbStatus);
        Controls.Add(ordersDataGridView);
        Text = "AdminOrdersForm";
        ((System.ComponentModel.ISupportInitialize)ordersDataGridView).EndInit();
        ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
        ((System.ComponentModel.ISupportInitialize)statusBindingSource).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.BindingSource statusBindingSource;

    private System.Windows.Forms.Button btnLoadStatuses;
    private System.Windows.Forms.Button btnAddStatus;
    private System.Windows.Forms.BindingSource bindingSource1;
    private System.Windows.Forms.Button btnDeleteStatus;

    private System.Windows.Forms.CheckBox chkActive;

    private System.Windows.Forms.RichTextBox txtStatusDesc;

    private System.Windows.Forms.RichTextBox richTextBox1;
    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.TextBox txtStatusName;
    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Label lblPageInfo;

    private System.Windows.Forms.Button btnDetails;

    private System.Windows.Forms.Button btnUpdateStatus;

    private System.Windows.Forms.Button btnSearch;

    private System.Windows.Forms.ComboBox cmbStatus;

    private System.Windows.Forms.DataGridView ordersDataGridView;

    #endregion
}