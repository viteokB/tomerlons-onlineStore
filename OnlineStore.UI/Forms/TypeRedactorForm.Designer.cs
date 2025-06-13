using System.ComponentModel;

namespace OnlineStore.UI.Forms;

partial class TypeRedactorForm
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
        nameTextBox = new System.Windows.Forms.TextBox();
        description = new System.Windows.Forms.RichTextBox();
        splitContainer1 = new System.Windows.Forms.SplitContainer();
        label5 = new System.Windows.Forms.Label();
        splitContainer2 = new System.Windows.Forms.SplitContainer();
        splitContainer3 = new System.Windows.Forms.SplitContainer();
        splitContainer4 = new System.Windows.Forms.SplitContainer();
        splitContainer5 = new System.Windows.Forms.SplitContainer();
        splitContainer6 = new System.Windows.Forms.SplitContainer();
        label4 = new System.Windows.Forms.Label();
        splitContainer7 = new System.Windows.Forms.SplitContainer();
        splitContainer9 = new System.Windows.Forms.SplitContainer();
        label3 = new System.Windows.Forms.Label();
        splitContainer8 = new System.Windows.Forms.SplitContainer();
        splitContainer10 = new System.Windows.Forms.SplitContainer();
        label1 = new System.Windows.Forms.Label();
        comboBox1 = new System.Windows.Forms.ComboBox();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
        splitContainer2.Panel1.SuspendLayout();
        splitContainer2.Panel2.SuspendLayout();
        splitContainer2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
        splitContainer3.Panel1.SuspendLayout();
        splitContainer3.Panel2.SuspendLayout();
        splitContainer3.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
        splitContainer4.Panel1.SuspendLayout();
        splitContainer4.Panel2.SuspendLayout();
        splitContainer4.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer5).BeginInit();
        splitContainer5.Panel1.SuspendLayout();
        splitContainer5.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer6).BeginInit();
        splitContainer6.Panel1.SuspendLayout();
        splitContainer6.Panel2.SuspendLayout();
        splitContainer6.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer7).BeginInit();
        splitContainer7.Panel1.SuspendLayout();
        splitContainer7.Panel2.SuspendLayout();
        splitContainer7.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer9).BeginInit();
        splitContainer9.Panel1.SuspendLayout();
        splitContainer9.Panel2.SuspendLayout();
        splitContainer9.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer8).BeginInit();
        splitContainer8.Panel1.SuspendLayout();
        splitContainer8.Panel2.SuspendLayout();
        splitContainer8.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer10).BeginInit();
        splitContainer10.Panel1.SuspendLayout();
        splitContainer10.Panel2.SuspendLayout();
        splitContainer10.SuspendLayout();
        SuspendLayout();
        // 
        // createBtn
        // 
        createBtn.BackColor = System.Drawing.Color.LawnGreen;
        createBtn.Dock = System.Windows.Forms.DockStyle.Fill;
        createBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        createBtn.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        createBtn.Location = new System.Drawing.Point(0, 0);
        createBtn.Name = "createBtn";
        createBtn.Size = new System.Drawing.Size(161, 71);
        createBtn.TabIndex = 0;
        createBtn.Text = "Создать";
        createBtn.UseVisualStyleBackColor = false;
        createBtn.Click += createButton_Click;
        // 
        // deleteBtn
        // 
        deleteBtn.BackColor = System.Drawing.Color.Tomato;
        deleteBtn.Dock = System.Windows.Forms.DockStyle.Fill;
        deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        deleteBtn.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        deleteBtn.Location = new System.Drawing.Point(0, 0);
        deleteBtn.Name = "deleteBtn";
        deleteBtn.Size = new System.Drawing.Size(161, 77);
        deleteBtn.TabIndex = 1;
        deleteBtn.Text = "Удалить";
        deleteBtn.UseVisualStyleBackColor = false;
        deleteBtn.Click += removeButton_Click;
        // 
        // updateBtn
        // 
        updateBtn.BackColor = System.Drawing.Color.Aquamarine;
        updateBtn.Dock = System.Windows.Forms.DockStyle.Fill;
        updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        updateBtn.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        updateBtn.Location = new System.Drawing.Point(0, 0);
        updateBtn.Name = "updateBtn";
        updateBtn.Size = new System.Drawing.Size(161, 77);
        updateBtn.TabIndex = 2;
        updateBtn.Text = "Обновить";
        updateBtn.UseVisualStyleBackColor = false;
        updateBtn.Click += updateButton_Click;
        // 
        // nameTextBox
        // 
        nameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
        nameTextBox.Font = new System.Drawing.Font("Trebuchet MS", 12F);
        nameTextBox.Location = new System.Drawing.Point(0, 0);
        nameTextBox.Name = "nameTextBox";
        nameTextBox.Size = new System.Drawing.Size(499, 31);
        nameTextBox.TabIndex = 4;
        // 
        // description
        // 
        description.Dock = System.Windows.Forms.DockStyle.Fill;
        description.Font = new System.Drawing.Font("Trebuchet MS", 12F);
        description.Location = new System.Drawing.Point(0, 0);
        description.Name = "description";
        description.Size = new System.Drawing.Size(499, 236);
        description.TabIndex = 5;
        description.Text = "";
        // 
        // splitContainer1
        // 
        splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer1.Location = new System.Drawing.Point(0, 0);
        splitContainer1.Name = "splitContainer1";
        splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // splitContainer1.Panel1
        // 
        splitContainer1.Panel1.Controls.Add(label5);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(splitContainer2);
        splitContainer1.Size = new System.Drawing.Size(664, 534);
        splitContainer1.SplitterDistance = 77;
        splitContainer1.TabIndex = 6;
        // 
        // label5
        // 
        label5.BackColor = System.Drawing.Color.DarkOliveGreen;
        label5.Dock = System.Windows.Forms.DockStyle.Fill;
        label5.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        label5.ForeColor = System.Drawing.Color.White;
        label5.Location = new System.Drawing.Point(0, 0);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(664, 77);
        label5.TabIndex = 0;
        label5.Text = "Редактор \"Типов\" товаров";
        label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // splitContainer2
        // 
        splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer2.Location = new System.Drawing.Point(0, 0);
        splitContainer2.Name = "splitContainer2";
        // 
        // splitContainer2.Panel1
        // 
        splitContainer2.Panel1.Controls.Add(splitContainer3);
        // 
        // splitContainer2.Panel2
        // 
        splitContainer2.Panel2.Controls.Add(splitContainer6);
        splitContainer2.Size = new System.Drawing.Size(664, 453);
        splitContainer2.SplitterDistance = 161;
        splitContainer2.TabIndex = 0;
        // 
        // splitContainer3
        // 
        splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer3.Location = new System.Drawing.Point(0, 0);
        splitContainer3.Name = "splitContainer3";
        splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // splitContainer3.Panel1
        // 
        splitContainer3.Panel1.Controls.Add(createBtn);
        // 
        // splitContainer3.Panel2
        // 
        splitContainer3.Panel2.Controls.Add(splitContainer4);
        splitContainer3.Size = new System.Drawing.Size(161, 453);
        splitContainer3.SplitterDistance = 71;
        splitContainer3.TabIndex = 0;
        // 
        // splitContainer4
        // 
        splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer4.Location = new System.Drawing.Point(0, 0);
        splitContainer4.Name = "splitContainer4";
        splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // splitContainer4.Panel1
        // 
        splitContainer4.Panel1.Controls.Add(updateBtn);
        // 
        // splitContainer4.Panel2
        // 
        splitContainer4.Panel2.Controls.Add(splitContainer5);
        splitContainer4.Size = new System.Drawing.Size(161, 378);
        splitContainer4.SplitterDistance = 77;
        splitContainer4.TabIndex = 0;
        // 
        // splitContainer5
        // 
        splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer5.Location = new System.Drawing.Point(0, 0);
        splitContainer5.Name = "splitContainer5";
        splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // splitContainer5.Panel1
        // 
        splitContainer5.Panel1.Controls.Add(deleteBtn);
        splitContainer5.Size = new System.Drawing.Size(161, 297);
        splitContainer5.SplitterDistance = 77;
        splitContainer5.TabIndex = 0;
        // 
        // splitContainer6
        // 
        splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer6.Location = new System.Drawing.Point(0, 0);
        splitContainer6.Name = "splitContainer6";
        splitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // splitContainer6.Panel1
        // 
        splitContainer6.Panel1.Controls.Add(label4);
        // 
        // splitContainer6.Panel2
        // 
        splitContainer6.Panel2.Controls.Add(splitContainer7);
        splitContainer6.Size = new System.Drawing.Size(499, 453);
        splitContainer6.SplitterDistance = 38;
        splitContainer6.TabIndex = 0;
        // 
        // label4
        // 
        label4.BackColor = System.Drawing.Color.MidnightBlue;
        label4.Dock = System.Windows.Forms.DockStyle.Fill;
        label4.Font = new System.Drawing.Font("Trebuchet MS", 12F);
        label4.ForeColor = System.Drawing.Color.White;
        label4.Location = new System.Drawing.Point(0, 0);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(499, 38);
        label4.TabIndex = 0;
        label4.Text = "Поиск";
        label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // splitContainer7
        // 
        splitContainer7.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer7.Location = new System.Drawing.Point(0, 0);
        splitContainer7.Name = "splitContainer7";
        splitContainer7.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // splitContainer7.Panel1
        // 
        splitContainer7.Panel1.Controls.Add(splitContainer9);
        // 
        // splitContainer7.Panel2
        // 
        splitContainer7.Panel2.Controls.Add(splitContainer8);
        splitContainer7.Size = new System.Drawing.Size(499, 411);
        splitContainer7.SplitterDistance = 83;
        splitContainer7.TabIndex = 0;
        // 
        // splitContainer9
        // 
        splitContainer9.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer9.Location = new System.Drawing.Point(0, 0);
        splitContainer9.Name = "splitContainer9";
        splitContainer9.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // splitContainer9.Panel1
        // 
        splitContainer9.Panel1.Controls.Add(comboBox1);
        // 
        // splitContainer9.Panel2
        // 
        splitContainer9.Panel2.Controls.Add(label3);
        splitContainer9.Size = new System.Drawing.Size(499, 83);
        splitContainer9.SplitterDistance = 37;
        splitContainer9.TabIndex = 0;
        // 
        // label3
        // 
        label3.BackColor = System.Drawing.Color.DimGray;
        label3.Dock = System.Windows.Forms.DockStyle.Fill;
        label3.Font = new System.Drawing.Font("Trebuchet MS", 12F);
        label3.ForeColor = System.Drawing.Color.Transparent;
        label3.Location = new System.Drawing.Point(0, 0);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(499, 42);
        label3.TabIndex = 0;
        label3.Text = "Название";
        label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // splitContainer8
        // 
        splitContainer8.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer8.Location = new System.Drawing.Point(0, 0);
        splitContainer8.Name = "splitContainer8";
        splitContainer8.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // splitContainer8.Panel1
        // 
        splitContainer8.Panel1.Controls.Add(splitContainer10);
        // 
        // splitContainer8.Panel2
        // 
        splitContainer8.Panel2.Controls.Add(description);
        splitContainer8.Size = new System.Drawing.Size(499, 324);
        splitContainer8.SplitterDistance = 84;
        splitContainer8.TabIndex = 0;
        // 
        // splitContainer10
        // 
        splitContainer10.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer10.Location = new System.Drawing.Point(0, 0);
        splitContainer10.Name = "splitContainer10";
        splitContainer10.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // splitContainer10.Panel1
        // 
        splitContainer10.Panel1.Controls.Add(nameTextBox);
        // 
        // splitContainer10.Panel2
        // 
        splitContainer10.Panel2.Controls.Add(label1);
        splitContainer10.Size = new System.Drawing.Size(499, 84);
        splitContainer10.SplitterDistance = 37;
        splitContainer10.TabIndex = 0;
        // 
        // label1
        // 
        label1.BackColor = System.Drawing.Color.DimGray;
        label1.Dock = System.Windows.Forms.DockStyle.Fill;
        label1.Font = new System.Drawing.Font("Trebuchet MS", 12F);
        label1.ForeColor = System.Drawing.Color.White;
        label1.Location = new System.Drawing.Point(0, 0);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(499, 43);
        label1.TabIndex = 0;
        label1.Text = "Описание";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // comboBox1
        // 
        comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
        comboBox1.Font = new System.Drawing.Font("Trebuchet MS", 12F);
        comboBox1.FormattingEnabled = true;
        comboBox1.Location = new System.Drawing.Point(0, 0);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new System.Drawing.Size(499, 34);
        comboBox1.TabIndex = 0;
        comboBox1.DropDown += comboBox1_DropDown;
        comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        comboBox1.TextChanged += comboBox1_TextChanged;
        comboBox1.Leave += comboBox1_Leave;
        // 
        // TypeRedactorForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.ActiveCaption;
        ClientSize = new System.Drawing.Size(664, 534);
        Controls.Add(splitContainer1);
        Text = "TypeRedactorForm";
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        splitContainer2.Panel1.ResumeLayout(false);
        splitContainer2.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
        splitContainer2.ResumeLayout(false);
        splitContainer3.Panel1.ResumeLayout(false);
        splitContainer3.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
        splitContainer3.ResumeLayout(false);
        splitContainer4.Panel1.ResumeLayout(false);
        splitContainer4.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
        splitContainer4.ResumeLayout(false);
        splitContainer5.Panel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer5).EndInit();
        splitContainer5.ResumeLayout(false);
        splitContainer6.Panel1.ResumeLayout(false);
        splitContainer6.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer6).EndInit();
        splitContainer6.ResumeLayout(false);
        splitContainer7.Panel1.ResumeLayout(false);
        splitContainer7.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer7).EndInit();
        splitContainer7.ResumeLayout(false);
        splitContainer9.Panel1.ResumeLayout(false);
        splitContainer9.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer9).EndInit();
        splitContainer9.ResumeLayout(false);
        splitContainer8.Panel1.ResumeLayout(false);
        splitContainer8.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer8).EndInit();
        splitContainer8.ResumeLayout(false);
        splitContainer10.Panel1.ResumeLayout(false);
        splitContainer10.Panel1.PerformLayout();
        splitContainer10.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer10).EndInit();
        splitContainer10.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.ComboBox comboBox1;

    private System.Windows.Forms.Label label5;

    private System.Windows.Forms.Label label4;

    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.SplitContainer splitContainer10;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.SplitContainer splitContainer9;

    private System.Windows.Forms.SplitContainer splitContainer8;

    private System.Windows.Forms.SplitContainer splitContainer7;

    private System.Windows.Forms.SplitContainer splitContainer6;

    private System.Windows.Forms.SplitContainer splitContainer5;

    private System.Windows.Forms.SplitContainer splitContainer4;

    private System.Windows.Forms.SplitContainer splitContainer2;
    private System.Windows.Forms.SplitContainer splitContainer3;

    private System.Windows.Forms.SplitContainer splitContainer1;

    private System.Windows.Forms.Button createBtn;
    private System.Windows.Forms.Button deleteBtn;
    private System.Windows.Forms.Button updateBtn;
    private System.Windows.Forms.ComboBox comboBox;
    private System.Windows.Forms.TextBox nameTextBox;
    private System.Windows.Forms.RichTextBox description;

    #endregion
}