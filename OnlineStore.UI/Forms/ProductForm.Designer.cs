using System.ComponentModel;

namespace OnlineStore.UI.Forms;

partial class ProductForm
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
        dataGridView = new System.Windows.Forms.DataGridView();
        btnSearch = new System.Windows.Forms.Button();
        btnPrevPage = new System.Windows.Forms.Button();
        btnNextPage = new System.Windows.Forms.Button();
        lblPageInfo = new System.Windows.Forms.Label();
        txtSearch = new System.Windows.Forms.TextBox();
        cmbType = new System.Windows.Forms.ComboBox();
        cmbBrand = new System.Windows.Forms.ComboBox();
        cmbCountry = new System.Windows.Forms.ComboBox();
        ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
        SuspendLayout();
        // 
        // dataGridView
        // 
        dataGridView.ColumnHeadersHeight = 29;
        dataGridView.Location = new System.Drawing.Point(12, 62);
        dataGridView.Name = "dataGridView";
        dataGridView.RowHeadersWidth = 51;
        dataGridView.Size = new System.Drawing.Size(656, 329);
        dataGridView.TabIndex = 0;
        // 
        // btnSearch
        // 
        btnSearch.Location = new System.Drawing.Point(578, 397);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new System.Drawing.Size(90, 41);
        btnSearch.TabIndex = 1;
        btnSearch.Text = "btnSearch";
        btnSearch.UseVisualStyleBackColor = true;
        // 
        // btnPrevPage
        // 
        btnPrevPage.Location = new System.Drawing.Point(375, 397);
        btnPrevPage.Name = "btnPrevPage";
        btnPrevPage.Size = new System.Drawing.Size(75, 41);
        btnPrevPage.TabIndex = 2;
        btnPrevPage.Text = "<";
        btnPrevPage.UseVisualStyleBackColor = true;
        // 
        // btnNextPage
        // 
        btnNextPage.Location = new System.Drawing.Point(472, 397);
        btnNextPage.Name = "btnNextPage";
        btnNextPage.Size = new System.Drawing.Size(84, 41);
        btnNextPage.TabIndex = 3;
        btnNextPage.Text = ">";
        btnNextPage.UseVisualStyleBackColor = true;
        // 
        // lblPageInfo
        // 
        lblPageInfo.Location = new System.Drawing.Point(12, 407);
        lblPageInfo.Name = "lblPageInfo";
        lblPageInfo.Size = new System.Drawing.Size(280, 23);
        lblPageInfo.TabIndex = 4;
        // 
        // txtSearch
        // 
        txtSearch.Location = new System.Drawing.Point(12, 12);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new System.Drawing.Size(146, 27);
        txtSearch.TabIndex = 5;
        // 
        // cmbType
        // 
        cmbType.FormattingEnabled = true;
        cmbType.Location = new System.Drawing.Point(186, 11);
        cmbType.Name = "cmbType";
        cmbType.Size = new System.Drawing.Size(135, 28);
        cmbType.TabIndex = 6;
        // 
        // cmbBrand
        // 
        cmbBrand.FormattingEnabled = true;
        cmbBrand.Location = new System.Drawing.Point(338, 11);
        cmbBrand.Name = "cmbBrand";
        cmbBrand.Size = new System.Drawing.Size(158, 28);
        cmbBrand.TabIndex = 7;
        // 
        // cmbCountry
        // 
        cmbCountry.FormattingEnabled = true;
        cmbCountry.Location = new System.Drawing.Point(521, 11);
        cmbCountry.Name = "cmbCountry";
        cmbCountry.Size = new System.Drawing.Size(147, 28);
        cmbCountry.TabIndex = 8;
        // 
        // ProductForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(698, 450);
        Controls.Add(cmbCountry);
        Controls.Add(cmbBrand);
        Controls.Add(cmbType);
        Controls.Add(txtSearch);
        Controls.Add(lblPageInfo);
        Controls.Add(btnNextPage);
        Controls.Add(btnPrevPage);
        Controls.Add(btnSearch);
        Controls.Add(dataGridView);
        Text = "ProductForm";
        ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.ComboBox cmbCountry;

    private System.Windows.Forms.ComboBox cmbBrand;

    private System.Windows.Forms.ComboBox cmbType;

    private System.Windows.Forms.TextBox txtSearch;

    private System.Windows.Forms.Label lblPageInfo;

    private System.Windows.Forms.Button btnNextPage;

    private System.Windows.Forms.Button btnPrevPage;

    private System.Windows.Forms.Button btnSearch;

    private System.Windows.Forms.DataGridView dataGridView;

    #endregion
}