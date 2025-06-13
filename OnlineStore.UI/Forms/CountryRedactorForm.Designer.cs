using System.ComponentModel;

namespace OnlineStore.UI.Forms;

partial class CountryRedactorForm
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
        splitContainer1 = new System.Windows.Forms.SplitContainer();
        label1 = new System.Windows.Forms.Label();
        splitContainer2 = new System.Windows.Forms.SplitContainer();
        splitContainer3 = new System.Windows.Forms.SplitContainer();
        createBtn = new System.Windows.Forms.Button();
        splitContainer4 = new System.Windows.Forms.SplitContainer();
        updateBtn = new System.Windows.Forms.Button();
        splitContainer5 = new System.Windows.Forms.SplitContainer();
        deleteBtn = new System.Windows.Forms.Button();
        splitContainer6 = new System.Windows.Forms.SplitContainer();
        splitContainer7 = new System.Windows.Forms.SplitContainer();
        label2 = new System.Windows.Forms.Label();
        splitContainer8 = new System.Windows.Forms.SplitContainer();
        label3 = new System.Windows.Forms.Label();
        splitContainer9 = new System.Windows.Forms.SplitContainer();
        label4 = new System.Windows.Forms.Label();
        splitContainer10 = new System.Windows.Forms.SplitContainer();
        comboBox = new System.Windows.Forms.ComboBox();
        splitContainer11 = new System.Windows.Forms.SplitContainer();
        nameTextBox = new System.Windows.Forms.TextBox();
        splitContainer12 = new System.Windows.Forms.SplitContainer();
        codeTextBox = new System.Windows.Forms.TextBox();
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
        ((System.ComponentModel.ISupportInitialize)splitContainer8).BeginInit();
        splitContainer8.Panel1.SuspendLayout();
        splitContainer8.Panel2.SuspendLayout();
        splitContainer8.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer9).BeginInit();
        splitContainer9.Panel1.SuspendLayout();
        splitContainer9.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer10).BeginInit();
        splitContainer10.Panel1.SuspendLayout();
        splitContainer10.Panel2.SuspendLayout();
        splitContainer10.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer11).BeginInit();
        splitContainer11.Panel1.SuspendLayout();
        splitContainer11.Panel2.SuspendLayout();
        splitContainer11.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer12).BeginInit();
        splitContainer12.Panel1.SuspendLayout();
        splitContainer12.SuspendLayout();
        SuspendLayout();
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
        splitContainer1.Panel1.BackColor = System.Drawing.Color.SaddleBrown;
        splitContainer1.Panel1.Controls.Add(label1);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(splitContainer2);
        splitContainer1.Size = new System.Drawing.Size(800, 450);
        splitContainer1.SplitterDistance = 59;
        splitContainer1.TabIndex = 0;
        // 
        // label1
        // 
        label1.Dock = System.Windows.Forms.DockStyle.Fill;
        label1.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        label1.ForeColor = System.Drawing.Color.White;
        label1.Location = new System.Drawing.Point(0, 0);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(800, 59);
        label1.TabIndex = 0;
        label1.Text = "Редактор \"Стран\" для товаров";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
        splitContainer2.Size = new System.Drawing.Size(800, 387);
        splitContainer2.SplitterDistance = 266;
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
        splitContainer3.Size = new System.Drawing.Size(266, 387);
        splitContainer3.SplitterDistance = 88;
        splitContainer3.TabIndex = 0;
        // 
        // createBtn
        // 
        createBtn.BackColor = System.Drawing.Color.PaleGreen;
        createBtn.Dock = System.Windows.Forms.DockStyle.Fill;
        createBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        createBtn.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        createBtn.Location = new System.Drawing.Point(0, 0);
        createBtn.Name = "createBtn";
        createBtn.Size = new System.Drawing.Size(266, 88);
        createBtn.TabIndex = 0;
        createBtn.Text = "Создать";
        createBtn.UseVisualStyleBackColor = false;
        createBtn.Click += createButton_Click;
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
        splitContainer4.Size = new System.Drawing.Size(266, 295);
        splitContainer4.SplitterDistance = 88;
        splitContainer4.TabIndex = 0;
        // 
        // updateBtn
        // 
        updateBtn.BackColor = System.Drawing.Color.Aquamarine;
        updateBtn.Dock = System.Windows.Forms.DockStyle.Fill;
        updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        updateBtn.Font = new System.Drawing.Font("Trebuchet MS", 12F);
        updateBtn.Location = new System.Drawing.Point(0, 0);
        updateBtn.Name = "updateBtn";
        updateBtn.Size = new System.Drawing.Size(266, 88);
        updateBtn.TabIndex = 0;
        updateBtn.Text = "Обновить";
        updateBtn.UseVisualStyleBackColor = false;
        updateBtn.Click += updateButton_Click;
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
        splitContainer5.Size = new System.Drawing.Size(266, 203);
        splitContainer5.SplitterDistance = 88;
        splitContainer5.TabIndex = 0;
        // 
        // deleteBtn
        // 
        deleteBtn.BackColor = System.Drawing.Color.Tomato;
        deleteBtn.Dock = System.Windows.Forms.DockStyle.Fill;
        deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        deleteBtn.Font = new System.Drawing.Font("Trebuchet MS", 12F);
        deleteBtn.Location = new System.Drawing.Point(0, 0);
        deleteBtn.Name = "deleteBtn";
        deleteBtn.Size = new System.Drawing.Size(266, 88);
        deleteBtn.TabIndex = 0;
        deleteBtn.Text = "Удалить";
        deleteBtn.UseVisualStyleBackColor = false;
        deleteBtn.Click += removeButton_Click;
        // 
        // splitContainer6
        // 
        splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer6.Location = new System.Drawing.Point(0, 0);
        splitContainer6.Name = "splitContainer6";
        // 
        // splitContainer6.Panel1
        // 
        splitContainer6.Panel1.BackColor = System.Drawing.Color.RebeccaPurple;
        splitContainer6.Panel1.Controls.Add(splitContainer7);
        // 
        // splitContainer6.Panel2
        // 
        splitContainer6.Panel2.Controls.Add(splitContainer10);
        splitContainer6.Size = new System.Drawing.Size(530, 387);
        splitContainer6.SplitterDistance = 119;
        splitContainer6.TabIndex = 0;
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
        splitContainer7.Panel1.Controls.Add(label2);
        // 
        // splitContainer7.Panel2
        // 
        splitContainer7.Panel2.Controls.Add(splitContainer8);
        splitContainer7.Size = new System.Drawing.Size(119, 387);
        splitContainer7.SplitterDistance = 65;
        splitContainer7.TabIndex = 0;
        // 
        // label2
        // 
        label2.Dock = System.Windows.Forms.DockStyle.Fill;
        label2.Font = new System.Drawing.Font("Trebuchet MS", 12F);
        label2.ForeColor = System.Drawing.Color.White;
        label2.Location = new System.Drawing.Point(0, 0);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(119, 65);
        label2.TabIndex = 0;
        label2.Text = "Поиск";
        label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
        splitContainer8.Panel1.Controls.Add(label3);
        // 
        // splitContainer8.Panel2
        // 
        splitContainer8.Panel2.Controls.Add(splitContainer9);
        splitContainer8.Size = new System.Drawing.Size(119, 318);
        splitContainer8.SplitterDistance = 65;
        splitContainer8.TabIndex = 0;
        // 
        // label3
        // 
        label3.Dock = System.Windows.Forms.DockStyle.Fill;
        label3.Font = new System.Drawing.Font("Trebuchet MS", 12F);
        label3.ForeColor = System.Drawing.Color.White;
        label3.Location = new System.Drawing.Point(0, 0);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(119, 65);
        label3.TabIndex = 0;
        label3.Text = "Название";
        label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
        splitContainer9.Panel1.Controls.Add(label4);
        splitContainer9.Size = new System.Drawing.Size(119, 249);
        splitContainer9.SplitterDistance = 65;
        splitContainer9.TabIndex = 0;
        // 
        // label4
        // 
        label4.Dock = System.Windows.Forms.DockStyle.Fill;
        label4.Font = new System.Drawing.Font("Trebuchet MS", 12F);
        label4.ForeColor = System.Drawing.Color.White;
        label4.Location = new System.Drawing.Point(0, 0);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(119, 65);
        label4.TabIndex = 0;
        label4.Text = "Код страны";
        label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
        splitContainer10.Panel1.BackColor = System.Drawing.Color.RebeccaPurple;
        splitContainer10.Panel1.Controls.Add(comboBox);
        // 
        // splitContainer10.Panel2
        // 
        splitContainer10.Panel2.Controls.Add(splitContainer11);
        splitContainer10.Size = new System.Drawing.Size(407, 387);
        splitContainer10.SplitterDistance = 65;
        splitContainer10.TabIndex = 0;
        // 
        // comboBox
        // 
        comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
        comboBox.Font = new System.Drawing.Font("Trebuchet MS", 12F);
        comboBox.FormattingEnabled = true;
        comboBox.Location = new System.Drawing.Point(0, 0);
        comboBox.Name = "comboBox";
        comboBox.Size = new System.Drawing.Size(407, 34);
        comboBox.TabIndex = 0;
        comboBox.DropDown += comboBox_DropDown;
        comboBox.SelectedIndexChanged += comboBox_SelectedIndexChanged;
        comboBox.TextChanged += comboBox_TextChanged;
        comboBox.Leave += comboBox_Leave;
        // 
        // splitContainer11
        // 
        splitContainer11.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer11.Location = new System.Drawing.Point(0, 0);
        splitContainer11.Name = "splitContainer11";
        splitContainer11.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // splitContainer11.Panel1
        // 
        splitContainer11.Panel1.Controls.Add(nameTextBox);
        // 
        // splitContainer11.Panel2
        // 
        splitContainer11.Panel2.Controls.Add(splitContainer12);
        splitContainer11.Size = new System.Drawing.Size(407, 318);
        splitContainer11.SplitterDistance = 66;
        splitContainer11.TabIndex = 0;
        // 
        // nameTextBox
        // 
        nameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
        nameTextBox.Font = new System.Drawing.Font("Trebuchet MS", 12F);
        nameTextBox.Location = new System.Drawing.Point(0, 0);
        nameTextBox.Name = "nameTextBox";
        nameTextBox.Size = new System.Drawing.Size(407, 31);
        nameTextBox.TabIndex = 0;
        // 
        // splitContainer12
        // 
        splitContainer12.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer12.Location = new System.Drawing.Point(0, 0);
        splitContainer12.Name = "splitContainer12";
        splitContainer12.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // splitContainer12.Panel1
        // 
        splitContainer12.Panel1.Controls.Add(codeTextBox);
        splitContainer12.Size = new System.Drawing.Size(407, 248);
        splitContainer12.SplitterDistance = 63;
        splitContainer12.TabIndex = 1;
        // 
        // codeTextBox
        // 
        codeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
        codeTextBox.Font = new System.Drawing.Font("Trebuchet MS", 12F);
        codeTextBox.Location = new System.Drawing.Point(0, 0);
        codeTextBox.Name = "codeTextBox";
        codeTextBox.Size = new System.Drawing.Size(407, 31);
        codeTextBox.TabIndex = 0;
        // 
        // CountryRedactorForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.RebeccaPurple;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(splitContainer1);
        Text = "CountryRedactorForm";
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
        splitContainer8.Panel1.ResumeLayout(false);
        splitContainer8.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer8).EndInit();
        splitContainer8.ResumeLayout(false);
        splitContainer9.Panel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer9).EndInit();
        splitContainer9.ResumeLayout(false);
        splitContainer10.Panel1.ResumeLayout(false);
        splitContainer10.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer10).EndInit();
        splitContainer10.ResumeLayout(false);
        splitContainer11.Panel1.ResumeLayout(false);
        splitContainer11.Panel1.PerformLayout();
        splitContainer11.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer11).EndInit();
        splitContainer11.ResumeLayout(false);
        splitContainer12.Panel1.ResumeLayout(false);
        splitContainer12.Panel1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer12).EndInit();
        splitContainer12.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.TextBox codeTextBox;

    private System.Windows.Forms.SplitContainer splitContainer12;

    private System.Windows.Forms.TextBox nameTextBox;

    private System.Windows.Forms.ComboBox comboBox;

    private System.Windows.Forms.Label label4;

    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.SplitContainer splitContainer11;

    private System.Windows.Forms.SplitContainer splitContainer10;

    private System.Windows.Forms.SplitContainer splitContainer9;

    private System.Windows.Forms.SplitContainer splitContainer8;

    private System.Windows.Forms.SplitContainer splitContainer6;
    private System.Windows.Forms.SplitContainer splitContainer7;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Button createBtn;
    private System.Windows.Forms.Button updateBtn;
    private System.Windows.Forms.Button deleteBtn;

    private System.Windows.Forms.SplitContainer splitContainer5;

    private System.Windows.Forms.SplitContainer splitContainer4;

    private System.Windows.Forms.SplitContainer splitContainer2;
    private System.Windows.Forms.SplitContainer splitContainer3;

    private System.Windows.Forms.SplitContainer splitContainer1;

    #endregion
}