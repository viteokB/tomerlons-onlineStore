using System.ComponentModel;

namespace OnlineStore.UI.Forms;

partial class ProductRedactorForm
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
        createBtn = new System.Windows.Forms.Button();
        updateBtn = new System.Windows.Forms.Button();
        deleteBtn = new System.Windows.Forms.Button();
        disactivateBtn = new System.Windows.Forms.Button();
        typeComboBox = new System.Windows.Forms.ComboBox();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        brandComboBox = new System.Windows.Forms.ComboBox();
        countryComboBox = new System.Windows.Forms.ComboBox();
        photoPathTextBox = new System.Windows.Forms.TextBox();
        label4 = new System.Windows.Forms.Label();
        productsComboBox = new System.Windows.Forms.ComboBox();
        label5 = new System.Windows.Forms.Label();
        button1 = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // createBtn
        // 
        createBtn.Location = new System.Drawing.Point(43, 29);
        createBtn.Name = "createBtn";
        createBtn.Size = new System.Drawing.Size(113, 36);
        createBtn.TabIndex = 0;
        createBtn.Text = "create";
        createBtn.UseVisualStyleBackColor = true;
        createBtn.Click += createButton_Click;
        // 
        // updateBtn
        // 
        updateBtn.Location = new System.Drawing.Point(43, 92);
        updateBtn.Name = "updateBtn";
        updateBtn.Size = new System.Drawing.Size(113, 36);
        updateBtn.TabIndex = 1;
        updateBtn.Text = "update";
        updateBtn.UseVisualStyleBackColor = true;
        updateBtn.Click += updateButton_Click;
        // 
        // deleteBtn
        // 
        deleteBtn.Location = new System.Drawing.Point(43, 157);
        deleteBtn.Name = "deleteBtn";
        deleteBtn.Size = new System.Drawing.Size(113, 36);
        deleteBtn.TabIndex = 2;
        deleteBtn.Text = "delete";
        deleteBtn.UseVisualStyleBackColor = true;
        deleteBtn.Click += deleteButton_Click;
        // 
        // disactivateBtn
        // 
        disactivateBtn.Location = new System.Drawing.Point(43, 229);
        disactivateBtn.Name = "disactivateBtn";
        disactivateBtn.Size = new System.Drawing.Size(113, 36);
        disactivateBtn.TabIndex = 3;
        disactivateBtn.Text = "disactivate";
        disactivateBtn.UseVisualStyleBackColor = true;
        disactivateBtn.Click += disactivateButton_Click;
        // 
        // typeComboBox
        // 
        typeComboBox.FormattingEnabled = true;
        typeComboBox.Location = new System.Drawing.Point(568, 29);
        typeComboBox.Name = "typeComboBox";
        typeComboBox.Size = new System.Drawing.Size(121, 28);
        typeComboBox.TabIndex = 4;
        typeComboBox.DropDown += typeComboBox_DropDown;
        typeComboBox.TextChanged += typeComboBox_TextChanged;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(462, 29);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(100, 23);
        label1.TabIndex = 5;
        label1.Text = "Type";
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(462, 81);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(100, 23);
        label2.TabIndex = 6;
        label2.Text = "Brand";
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(462, 134);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(100, 23);
        label3.TabIndex = 7;
        label3.Text = "Country";
        // 
        // brandComboBox
        // 
        brandComboBox.FormattingEnabled = true;
        brandComboBox.Location = new System.Drawing.Point(568, 81);
        brandComboBox.Name = "brandComboBox";
        brandComboBox.Size = new System.Drawing.Size(121, 28);
        brandComboBox.TabIndex = 8;
        brandComboBox.DropDown += brandComboBox_DropDown;
        brandComboBox.TextChanged += brandComboBox_TextChanged;
        // 
        // countryComboBox
        // 
        countryComboBox.FormattingEnabled = true;
        countryComboBox.Location = new System.Drawing.Point(568, 134);
        countryComboBox.Name = "countryComboBox";
        countryComboBox.Size = new System.Drawing.Size(121, 28);
        countryComboBox.TabIndex = 9;
        countryComboBox.DropDown += countryComboBox_DropDown;
        countryComboBox.TextChanged += countryComboBox_TextChanged;
        // 
        // photoPathTextBox
        // 
        photoPathTextBox.Location = new System.Drawing.Point(568, 187);
        photoPathTextBox.Name = "photoPathTextBox";
        photoPathTextBox.Size = new System.Drawing.Size(121, 27);
        photoPathTextBox.TabIndex = 10;
        // 
        // label4
        // 
        label4.Location = new System.Drawing.Point(462, 187);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(100, 23);
        label4.TabIndex = 11;
        label4.Text = "Photo Path";
        // 
        // productsComboBox
        // 
        productsComboBox.FormattingEnabled = true;
        productsComboBox.Location = new System.Drawing.Point(568, 247);
        productsComboBox.Name = "productsComboBox";
        productsComboBox.Size = new System.Drawing.Size(121, 28);
        productsComboBox.TabIndex = 12;
        productsComboBox.DropDown += productsComboBox_DropDown;
        productsComboBox.SelectedIndexChanged += productsComboBox_SelectedIndexChanged;
        productsComboBox.TextChanged += productsComboBox_TextChanged;
        // 
        // label5
        // 
        label5.Location = new System.Drawing.Point(421, 247);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(141, 23);
        label5.TabIndex = 13;
        label5.Text = "Product ComboBox";
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(43, 289);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(113, 36);
        button1.TabIndex = 14;
        button1.Text = "browsePhoto";
        button1.UseVisualStyleBackColor = true;
        button1.Click += browsePhotoButton_Click;
        // 
        // ProductRedactorForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(button1);
        Controls.Add(label5);
        Controls.Add(productsComboBox);
        Controls.Add(label4);
        Controls.Add(photoPathTextBox);
        Controls.Add(countryComboBox);
        Controls.Add(brandComboBox);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(typeComboBox);
        Controls.Add(disactivateBtn);
        Controls.Add(deleteBtn);
        Controls.Add(updateBtn);
        Controls.Add(createBtn);
        Text = "ProductRedactorForm";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.ComboBox productsComboBox;
    private System.Windows.Forms.Label label5;

    private System.Windows.Forms.Label label4;

    private System.Windows.Forms.TextBox photoPathTextBox;

    private System.Windows.Forms.ComboBox typeComboBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox brandComboBox;

    private System.Windows.Forms.ComboBox countryComboBox;

    private System.Windows.Forms.Button createBtn;
    private System.Windows.Forms.Button updateBtn;
    private System.Windows.Forms.Button deleteBtn;
    private System.Windows.Forms.Button disactivateBtn;

    #endregion
}