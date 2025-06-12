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
        splitContainer1 = new System.Windows.Forms.SplitContainer();
        label1 = new System.Windows.Forms.Label();
        splitContainer2 = new System.Windows.Forms.SplitContainer();
        splitContainer3 = new System.Windows.Forms.SplitContainer();
        createButton = new System.Windows.Forms.Button();
        splitContainer4 = new System.Windows.Forms.SplitContainer();
        updateButton = new System.Windows.Forms.Button();
        splitContainer5 = new System.Windows.Forms.SplitContainer();
        removeButton = new System.Windows.Forms.Button();
        splitContainer6 = new System.Windows.Forms.SplitContainer();
        splitContainer7 = new System.Windows.Forms.SplitContainer();
        label5 = new System.Windows.Forms.Label();
        searchComboBox = new System.Windows.Forms.ComboBox();
        splitContainer8 = new System.Windows.Forms.SplitContainer();
        splitContainer11 = new System.Windows.Forms.SplitContainer();
        label4 = new System.Windows.Forms.Label();
        nameTextBox = new System.Windows.Forms.TextBox();
        splitContainer10 = new System.Windows.Forms.SplitContainer();
        label3 = new System.Windows.Forms.Label();
        descriptionTextBox = new System.Windows.Forms.RichTextBox();
        label2 = new System.Windows.Forms.Label();
        splitContainer9 = new System.Windows.Forms.SplitContainer();
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
        ((System.ComponentModel.ISupportInitialize)splitContainer8).BeginInit();
        splitContainer8.Panel1.SuspendLayout();
        splitContainer8.Panel2.SuspendLayout();
        splitContainer8.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer11).BeginInit();
        splitContainer11.Panel1.SuspendLayout();
        splitContainer11.Panel2.SuspendLayout();
        splitContainer11.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer10).BeginInit();
        splitContainer10.Panel1.SuspendLayout();
        splitContainer10.Panel2.SuspendLayout();
        splitContainer10.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer9).BeginInit();
        splitContainer9.SuspendLayout();
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
        splitContainer1.Panel1.BackColor = System.Drawing.Color.DarkOliveGreen;
        splitContainer1.Panel1.Controls.Add(label1);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(splitContainer2);
        splitContainer1.Size = new System.Drawing.Size(690, 450);
        splitContainer1.SplitterDistance = 63;
        splitContainer1.TabIndex = 0;
        splitContainer1.Visible = false;
        // 
        // label1
        // 
        label1.Dock = System.Windows.Forms.DockStyle.Fill;
        label1.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        label1.ForeColor = System.Drawing.Color.White;
        label1.Location = new System.Drawing.Point(0, 0);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(690, 63);
        label1.TabIndex = 0;
        label1.Text = "Редактов \"Типов\" продуктов";
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
        splitContainer2.Size = new System.Drawing.Size(690, 383);
        splitContainer2.SplitterDistance = 301;
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
        splitContainer3.Panel1.Controls.Add(createButton);
        // 
        // splitContainer3.Panel2
        // 
        splitContainer3.Panel2.Controls.Add(splitContainer4);
        splitContainer3.Size = new System.Drawing.Size(301, 383);
        splitContainer3.SplitterDistance = 54;
        splitContainer3.TabIndex = 0;
        // 
        // createButton
        // 
        createButton.BackColor = System.Drawing.Color.RoyalBlue;
        createButton.Dock = System.Windows.Forms.DockStyle.Fill;
        createButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        createButton.Font = new System.Drawing.Font("Trebuchet MS", 13.200001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        createButton.ForeColor = System.Drawing.Color.White;
        createButton.Location = new System.Drawing.Point(0, 0);
        createButton.Name = "createButton";
        createButton.Size = new System.Drawing.Size(301, 54);
        createButton.TabIndex = 0;
        createButton.Text = "Создать";
        createButton.UseVisualStyleBackColor = false;
        createButton.Click += createButton_Click;
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
        splitContainer4.Panel1.Controls.Add(updateButton);
        // 
        // splitContainer4.Panel2
        // 
        splitContainer4.Panel2.Controls.Add(splitContainer5);
        splitContainer4.Size = new System.Drawing.Size(301, 325);
        splitContainer4.SplitterDistance = 62;
        splitContainer4.TabIndex = 0;
        // 
        // updateButton
        // 
        updateButton.BackColor = System.Drawing.Color.Aqua;
        updateButton.Dock = System.Windows.Forms.DockStyle.Fill;
        updateButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        updateButton.Font = new System.Drawing.Font("Trebuchet MS", 13F);
        updateButton.Location = new System.Drawing.Point(0, 0);
        updateButton.Name = "updateButton";
        updateButton.Size = new System.Drawing.Size(301, 62);
        updateButton.TabIndex = 0;
        updateButton.Text = "Обновить";
        updateButton.UseVisualStyleBackColor = false;
        updateButton.Click += updateButton_Click;
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
        splitContainer5.Panel1.Controls.Add(removeButton);
        splitContainer5.Size = new System.Drawing.Size(301, 259);
        splitContainer5.SplitterDistance = 59;
        splitContainer5.TabIndex = 0;
        // 
        // removeButton
        // 
        removeButton.BackColor = System.Drawing.Color.Red;
        removeButton.Dock = System.Windows.Forms.DockStyle.Fill;
        removeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        removeButton.Font = new System.Drawing.Font("Trebuchet MS", 13F);
        removeButton.ForeColor = System.Drawing.Color.White;
        removeButton.Location = new System.Drawing.Point(0, 0);
        removeButton.Name = "removeButton";
        removeButton.Size = new System.Drawing.Size(301, 59);
        removeButton.TabIndex = 0;
        removeButton.Text = "Удалить";
        removeButton.UseVisualStyleBackColor = false;
        removeButton.Click += removeButton_Click;
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
        splitContainer6.Panel1.BackColor = System.Drawing.Color.DarkOliveGreen;
        splitContainer6.Panel1.Controls.Add(splitContainer7);
        // 
        // splitContainer6.Panel2
        // 
        splitContainer6.Panel2.Controls.Add(splitContainer8);
        splitContainer6.Size = new System.Drawing.Size(385, 383);
        splitContainer6.SplitterDistance = 72;
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
        splitContainer7.Panel1.Controls.Add(label5);
        // 
        // splitContainer7.Panel2
        // 
        splitContainer7.Panel2.Controls.Add(searchComboBox);
        splitContainer7.Size = new System.Drawing.Size(385, 72);
        splitContainer7.SplitterDistance = 30;
        splitContainer7.TabIndex = 0;
        // 
        // label5
        // 
        label5.Dock = System.Windows.Forms.DockStyle.Fill;
        label5.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        label5.ForeColor = System.Drawing.Color.White;
        label5.Location = new System.Drawing.Point(0, 0);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(385, 30);
        label5.TabIndex = 1;
        label5.Text = "Поиск";
        // 
        // searchComboBox
        // 
        searchComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
        searchComboBox.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        searchComboBox.FormattingEnabled = true;
        searchComboBox.Location = new System.Drawing.Point(0, 0);
        searchComboBox.Name = "searchComboBox";
        searchComboBox.Size = new System.Drawing.Size(385, 34);
        searchComboBox.TabIndex = 0;
        searchComboBox.DropDown += searchComboBox_DropDown;
        searchComboBox.SelectedIndexChanged += searchComboBox_SelectedIndexChanged;
        searchComboBox.TextChanged += searchComboBox_TextChanged;
        searchComboBox.Leave += searchComboBox_Leave;
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
        splitContainer8.Panel1.Controls.Add(splitContainer11);
        // 
        // splitContainer8.Panel2
        // 
        splitContainer8.Panel2.Controls.Add(splitContainer10);
        splitContainer8.Size = new System.Drawing.Size(385, 307);
        splitContainer8.SplitterDistance = 77;
        splitContainer8.TabIndex = 0;
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
        splitContainer11.Panel1.Controls.Add(label4);
        // 
        // splitContainer11.Panel2
        // 
        splitContainer11.Panel2.Controls.Add(nameTextBox);
        splitContainer11.Size = new System.Drawing.Size(385, 77);
        splitContainer11.SplitterDistance = 39;
        splitContainer11.TabIndex = 0;
        // 
        // label4
        // 
        label4.Dock = System.Windows.Forms.DockStyle.Fill;
        label4.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        label4.ForeColor = System.Drawing.Color.Black;
        label4.Location = new System.Drawing.Point(0, 0);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(385, 39);
        label4.TabIndex = 0;
        label4.Text = "Название";
        // 
        // nameTextBox
        // 
        nameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
        nameTextBox.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        nameTextBox.Location = new System.Drawing.Point(0, 0);
        nameTextBox.Name = "nameTextBox";
        nameTextBox.Size = new System.Drawing.Size(385, 31);
        nameTextBox.TabIndex = 0;
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
        splitContainer10.Panel1.Controls.Add(label3);
        // 
        // splitContainer10.Panel2
        // 
        splitContainer10.Panel2.Controls.Add(descriptionTextBox);
        splitContainer10.Size = new System.Drawing.Size(385, 226);
        splitContainer10.SplitterDistance = 45;
        splitContainer10.TabIndex = 0;
        // 
        // label3
        // 
        label3.BackColor = System.Drawing.Color.DarkOliveGreen;
        label3.Dock = System.Windows.Forms.DockStyle.Fill;
        label3.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        label3.ForeColor = System.Drawing.Color.White;
        label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        label3.Location = new System.Drawing.Point(0, 0);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(385, 45);
        label3.TabIndex = 0;
        label3.Text = "Описание";
        // 
        // descriptionTextBox
        // 
        descriptionTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
        descriptionTextBox.Location = new System.Drawing.Point(0, 0);
        descriptionTextBox.Name = "descriptionTextBox";
        descriptionTextBox.Size = new System.Drawing.Size(385, 177);
        descriptionTextBox.TabIndex = 0;
        descriptionTextBox.Text = "";
        // 
        // label2
        // 
        label2.Dock = System.Windows.Forms.DockStyle.Fill;
        label2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        label2.ForeColor = System.Drawing.Color.White;
        label2.Location = new System.Drawing.Point(0, 0);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(91, 72);
        label2.TabIndex = 0;
        label2.Text = "Поиск";
        label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // splitContainer9
        // 
        splitContainer9.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer9.Location = new System.Drawing.Point(0, 0);
        splitContainer9.Name = "splitContainer9";
        splitContainer9.Size = new System.Drawing.Size(385, 226);
        splitContainer9.SplitterDistance = 74;
        splitContainer9.TabIndex = 0;
        // 
        // comboBox1
        // 
        comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom));
        comboBox1.FormattingEnabled = true;
        comboBox1.Location = new System.Drawing.Point(22, 26);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new System.Drawing.Size(253, 28);
        comboBox1.TabIndex = 0;
        // 
        // TypeRedactorForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.YellowGreen;
        ClientSize = new System.Drawing.Size(690, 450);
        Controls.Add(splitContainer1);
        Location = new System.Drawing.Point(19, 19);
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
        splitContainer8.Panel1.ResumeLayout(false);
        splitContainer8.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer8).EndInit();
        splitContainer8.ResumeLayout(false);
        splitContainer11.Panel1.ResumeLayout(false);
        splitContainer11.Panel2.ResumeLayout(false);
        splitContainer11.Panel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer11).EndInit();
        splitContainer11.ResumeLayout(false);
        splitContainer10.Panel1.ResumeLayout(false);
        splitContainer10.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer10).EndInit();
        splitContainer10.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer9).EndInit();
        splitContainer9.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.ComboBox searchComboBox;

    private System.Windows.Forms.Label label5;

    private System.Windows.Forms.SplitContainer splitContainer7;

    private System.Windows.Forms.Label label4;

    private System.Windows.Forms.TextBox nameTextBox;

    private System.Windows.Forms.SplitContainer splitContainer11;

    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.RichTextBox descriptionTextBox;

    private System.Windows.Forms.SplitContainer splitContainer10;

    private System.Windows.Forms.SplitContainer splitContainer9;

    private System.Windows.Forms.SplitContainer splitContainer8;

    private System.Windows.Forms.ComboBox comboBox1;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.SplitContainer splitContainer6;

    private System.Windows.Forms.Button updateButton;
    private System.Windows.Forms.Button removeButton;

    private System.Windows.Forms.Button createButton;

    private System.Windows.Forms.SplitContainer splitContainer5;

    private System.Windows.Forms.SplitContainer splitContainer4;

    private System.Windows.Forms.SplitContainer splitContainer3;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.SplitContainer splitContainer2;

    private System.Windows.Forms.SplitContainer splitContainer1;

    #endregion
}