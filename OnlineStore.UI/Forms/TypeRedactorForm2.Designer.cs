using System.ComponentModel;

namespace OnlineStore.UI.Forms;

partial class TypeRedactorForm2
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
        deleteBtn = new System.Windows.Forms.Button();
        updateBtn = new System.Windows.Forms.Button();
        comboBox = new System.Windows.Forms.ComboBox();
        nameTextBox = new System.Windows.Forms.TextBox();
        description = new System.Windows.Forms.RichTextBox();
        SuspendLayout();
        // 
        // createBtn
        // 
        createBtn.Location = new System.Drawing.Point(52, 52);
        createBtn.Name = "createBtn";
        createBtn.Size = new System.Drawing.Size(75, 43);
        createBtn.TabIndex = 0;
        createBtn.Text = "Создать";
        createBtn.UseVisualStyleBackColor = true;
        createBtn.Click += createButton_Click;
        // 
        // deleteBtn
        // 
        deleteBtn.Location = new System.Drawing.Point(52, 154);
        deleteBtn.Name = "deleteBtn";
        deleteBtn.Size = new System.Drawing.Size(75, 38);
        deleteBtn.TabIndex = 1;
        deleteBtn.Text = "Удалить";
        deleteBtn.UseVisualStyleBackColor = true;
        deleteBtn.Click += removeButton_Click;
        // 
        // updateBtn
        // 
        updateBtn.Location = new System.Drawing.Point(52, 270);
        updateBtn.Name = "updateBtn";
        updateBtn.Size = new System.Drawing.Size(75, 44);
        updateBtn.TabIndex = 2;
        updateBtn.Text = "Обновить";
        updateBtn.UseVisualStyleBackColor = true;
        updateBtn.Click += updateButton_Click;
        // 
        // comboBox
        // 
        comboBox.FormattingEnabled = true;
        comboBox.Location = new System.Drawing.Point(485, 52);
        comboBox.Name = "comboBox";
        comboBox.Size = new System.Drawing.Size(213, 28);
        comboBox.TabIndex = 3;
        comboBox.DropDown += comboBox_DropDown;
        comboBox.SelectedIndexChanged += comboBox_SelectedIndexChanged;
        comboBox.TextChanged += comboBox_TextChanged;
        comboBox.Leave += comboBox_Leave;
        // 
        // nameTextBox
        // 
        nameTextBox.Location = new System.Drawing.Point(485, 165);
        nameTextBox.Name = "nameTextBox";
        nameTextBox.Size = new System.Drawing.Size(100, 27);
        nameTextBox.TabIndex = 4;
        // 
        // description
        // 
        description.Location = new System.Drawing.Point(485, 279);
        description.Name = "description";
        description.Size = new System.Drawing.Size(252, 96);
        description.TabIndex = 5;
        description.Text = "";
        // 
        // TypeRedactorForm2
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(description);
        Controls.Add(nameTextBox);
        Controls.Add(comboBox);
        Controls.Add(updateBtn);
        Controls.Add(deleteBtn);
        Controls.Add(createBtn);
        Text = "TypeRedactorForm2";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button createBtn;
    private System.Windows.Forms.Button deleteBtn;
    private System.Windows.Forms.Button updateBtn;
    private System.Windows.Forms.ComboBox comboBox;
    private System.Windows.Forms.TextBox nameTextBox;
    private System.Windows.Forms.RichTextBox description;

    #endregion
}