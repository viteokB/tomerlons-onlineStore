using System.ComponentModel;

namespace OnlineStore.UI.Forms;

partial class BrandRedactorForm
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
        splitContainer9 = new System.Windows.Forms.SplitContainer();
        createBtn = new System.Windows.Forms.Button();
        splitContainer10 = new System.Windows.Forms.SplitContainer();
        updateBtn = new System.Windows.Forms.Button();
        splitContainer11 = new System.Windows.Forms.SplitContainer();
        deleteBtn = new System.Windows.Forms.Button();
        splitContainer3 = new System.Windows.Forms.SplitContainer();
        splitContainer6 = new System.Windows.Forms.SplitContainer();
        label2 = new System.Windows.Forms.Label();
        brandComboBox = new System.Windows.Forms.ComboBox();
        splitContainer4 = new System.Windows.Forms.SplitContainer();
        splitContainer7 = new System.Windows.Forms.SplitContainer();
        label3 = new System.Windows.Forms.Label();
        nameTextBox = new System.Windows.Forms.TextBox();
        splitContainer5 = new System.Windows.Forms.SplitContainer();
        splitContainer8 = new System.Windows.Forms.SplitContainer();
        label4 = new System.Windows.Forms.Label();
        labelCountry = new System.Windows.Forms.Label();
        countryComboBox = new System.Windows.Forms.ComboBox();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
        splitContainer2.Panel1.SuspendLayout();
        splitContainer2.Panel2.SuspendLayout();
        splitContainer2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer9).BeginInit();
        splitContainer9.Panel1.SuspendLayout();
        splitContainer9.Panel2.SuspendLayout();
        splitContainer9.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer10).BeginInit();
        splitContainer10.Panel1.SuspendLayout();
        splitContainer10.Panel2.SuspendLayout();
        splitContainer10.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer11).BeginInit();
        splitContainer11.Panel1.SuspendLayout();
        splitContainer11.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
        splitContainer3.Panel1.SuspendLayout();
        splitContainer3.Panel2.SuspendLayout();
        splitContainer3.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer6).BeginInit();
        splitContainer6.Panel1.SuspendLayout();
        splitContainer6.Panel2.SuspendLayout();
        splitContainer6.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
        splitContainer4.Panel1.SuspendLayout();
        splitContainer4.Panel2.SuspendLayout();
        splitContainer4.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer7).BeginInit();
        splitContainer7.Panel1.SuspendLayout();
        splitContainer7.Panel2.SuspendLayout();
        splitContainer7.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer5).BeginInit();
        splitContainer5.Panel1.SuspendLayout();
        splitContainer5.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer8).BeginInit();
        splitContainer8.Panel1.SuspendLayout();
        splitContainer8.Panel2.SuspendLayout();
        splitContainer8.SuspendLayout();
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
        splitContainer1.Panel1.Controls.Add(label1);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(splitContainer2);
        splitContainer1.Size = new System.Drawing.Size(678, 349);
        splitContainer1.SplitterDistance = 46;
        splitContainer1.TabIndex = 0;
        // 
        // label1
        // 
        label1.BackColor = System.Drawing.Color.FromArgb(((int)((byte)64)), ((int)((byte)0)), ((int)((byte)64)));
        label1.Dock = System.Windows.Forms.DockStyle.Fill;
        label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        label1.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        label1.ForeColor = System.Drawing.Color.White;
        label1.Location = new System.Drawing.Point(0, 0);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(678, 46);
        label1.TabIndex = 0;
        label1.Text = "Редактор \"Брендов\" товаров";
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
        splitContainer2.Panel1.Controls.Add(splitContainer9);
        // 
        // splitContainer2.Panel2
        // 
        splitContainer2.Panel2.Controls.Add(splitContainer3);
        splitContainer2.Size = new System.Drawing.Size(678, 299);
        splitContainer2.SplitterDistance = 186;
        splitContainer2.TabIndex = 0;
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
        splitContainer9.Panel1.Controls.Add(createBtn);
        // 
        // splitContainer9.Panel2
        // 
        splitContainer9.Panel2.Controls.Add(splitContainer10);
        splitContainer9.Size = new System.Drawing.Size(186, 299);
        splitContainer9.SplitterDistance = 62;
        splitContainer9.TabIndex = 0;
        // 
        // createBtn
        // 
        createBtn.BackColor = System.Drawing.Color.DarkGreen;
        createBtn.Dock = System.Windows.Forms.DockStyle.Fill;
        createBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        createBtn.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        createBtn.ForeColor = System.Drawing.Color.White;
        createBtn.Location = new System.Drawing.Point(0, 0);
        createBtn.Name = "createBtn";
        createBtn.Size = new System.Drawing.Size(186, 62);
        createBtn.TabIndex = 0;
        createBtn.Text = "Создать";
        createBtn.UseVisualStyleBackColor = false;
        createBtn.Click += createButton_Click;
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
        splitContainer10.Panel1.Controls.Add(updateBtn);
        // 
        // splitContainer10.Panel2
        // 
        splitContainer10.Panel2.Controls.Add(splitContainer11);
        splitContainer10.Size = new System.Drawing.Size(186, 233);
        splitContainer10.SplitterDistance = 62;
        splitContainer10.TabIndex = 0;
        // 
        // updateBtn
        // 
        updateBtn.BackColor = System.Drawing.Color.DarkSlateBlue;
        updateBtn.Dock = System.Windows.Forms.DockStyle.Fill;
        updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        updateBtn.Font = new System.Drawing.Font("Trebuchet MS", 12F);
        updateBtn.ForeColor = System.Drawing.Color.White;
        updateBtn.Location = new System.Drawing.Point(0, 0);
        updateBtn.Name = "updateBtn";
        updateBtn.Size = new System.Drawing.Size(186, 62);
        updateBtn.TabIndex = 0;
        updateBtn.Text = "Обновить";
        updateBtn.UseVisualStyleBackColor = false;
        updateBtn.Click += updateButton_Click;
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
        splitContainer11.Panel1.Controls.Add(deleteBtn);
        splitContainer11.Size = new System.Drawing.Size(186, 167);
        splitContainer11.SplitterDistance = 62;
        splitContainer11.TabIndex = 0;
        // 
        // deleteBtn
        // 
        deleteBtn.BackColor = System.Drawing.Color.DarkRed;
        deleteBtn.Dock = System.Windows.Forms.DockStyle.Fill;
        deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        deleteBtn.Font = new System.Drawing.Font("Trebuchet MS", 12F);
        deleteBtn.ForeColor = System.Drawing.Color.White;
        deleteBtn.Location = new System.Drawing.Point(0, 0);
        deleteBtn.Name = "deleteBtn";
        deleteBtn.Size = new System.Drawing.Size(186, 62);
        deleteBtn.TabIndex = 0;
        deleteBtn.Text = "Удалить";
        deleteBtn.UseVisualStyleBackColor = false;
        deleteBtn.Click += deleteButton_Click;
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
        splitContainer3.Panel1.Controls.Add(splitContainer6);
        // 
        // splitContainer3.Panel2
        // 
        splitContainer3.Panel2.Controls.Add(splitContainer4);
        splitContainer3.Size = new System.Drawing.Size(488, 299);
        splitContainer3.SplitterDistance = 49;
        splitContainer3.TabIndex = 0;
        // 
        // splitContainer6
        // 
        splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer6.Location = new System.Drawing.Point(0, 0);
        splitContainer6.Name = "splitContainer6";
        // 
        // splitContainer6.Panel1
        // 
        splitContainer6.Panel1.Controls.Add(label2);
        // 
        // splitContainer6.Panel2
        // 
        splitContainer6.Panel2.Controls.Add(brandComboBox);
        splitContainer6.Size = new System.Drawing.Size(488, 49);
        splitContainer6.SplitterDistance = 88;
        splitContainer6.TabIndex = 0;
        // 
        // label2
        // 
        label2.BackColor = System.Drawing.Color.FromArgb(((int)((byte)64)), ((int)((byte)64)), ((int)((byte)64)));
        label2.Dock = System.Windows.Forms.DockStyle.Fill;
        label2.Font = new System.Drawing.Font("Trebuchet MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        label2.ForeColor = System.Drawing.Color.White;
        label2.Location = new System.Drawing.Point(0, 0);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(88, 49);
        label2.TabIndex = 0;
        label2.Text = "Поиск Брендов";
        label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // brandComboBox
        // 
        brandComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
        brandComboBox.Font = new System.Drawing.Font("Trebuchet MS", 10.8F);
        brandComboBox.FormattingEnabled = true;
        brandComboBox.Location = new System.Drawing.Point(0, 0);
        brandComboBox.Name = "brandComboBox";
        brandComboBox.Size = new System.Drawing.Size(396, 31);
        brandComboBox.TabIndex = 0;
        brandComboBox.DropDown += brandComboBox_DropDown;
        brandComboBox.SelectedIndexChanged += brandComboBox_SelectedIndexChanged;
        brandComboBox.TextChanged += brandComboBox_TextChanged;
        brandComboBox.Leave += brandComboBox_Leave;
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
        splitContainer4.Panel1.Controls.Add(splitContainer7);
        // 
        // splitContainer4.Panel2
        // 
        splitContainer4.Panel2.Controls.Add(splitContainer5);
        splitContainer4.Size = new System.Drawing.Size(488, 246);
        splitContainer4.SplitterDistance = 51;
        splitContainer4.TabIndex = 0;
        // 
        // splitContainer7
        // 
        splitContainer7.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer7.Location = new System.Drawing.Point(0, 0);
        splitContainer7.Name = "splitContainer7";
        // 
        // splitContainer7.Panel1
        // 
        splitContainer7.Panel1.Controls.Add(label3);
        splitContainer7.Panel1.Font = new System.Drawing.Font("Trebuchet MS", 10.8F);
        // 
        // splitContainer7.Panel2
        // 
        splitContainer7.Panel2.Controls.Add(nameTextBox);
        splitContainer7.Size = new System.Drawing.Size(488, 51);
        splitContainer7.SplitterDistance = 88;
        splitContainer7.TabIndex = 0;
        // 
        // label3
        // 
        label3.BackColor = System.Drawing.Color.FromArgb(((int)((byte)64)), ((int)((byte)64)), ((int)((byte)64)));
        label3.Dock = System.Windows.Forms.DockStyle.Fill;
        label3.ForeColor = System.Drawing.Color.White;
        label3.Location = new System.Drawing.Point(0, 0);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(88, 51);
        label3.TabIndex = 0;
        label3.Text = "Имя";
        label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // nameTextBox
        // 
        nameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
        nameTextBox.Font = new System.Drawing.Font("Trebuchet MS", 10.8F);
        nameTextBox.Location = new System.Drawing.Point(0, 0);
        nameTextBox.Name = "nameTextBox";
        nameTextBox.Size = new System.Drawing.Size(396, 28);
        nameTextBox.TabIndex = 0;
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
        splitContainer5.Panel1.Controls.Add(splitContainer8);
        // 
        // splitContainer5.Panel2
        // 
        splitContainer5.Panel2.BackColor = System.Drawing.Color.Black;
        splitContainer5.Size = new System.Drawing.Size(488, 191);
        splitContainer5.SplitterDistance = 64;
        splitContainer5.TabIndex = 0;
        // 
        // splitContainer8
        // 
        splitContainer8.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer8.Location = new System.Drawing.Point(0, 0);
        splitContainer8.Name = "splitContainer8";
        // 
        // splitContainer8.Panel1
        // 
        splitContainer8.Panel1.Controls.Add(label4);
        // 
        // splitContainer8.Panel2
        // 
        splitContainer8.Panel2.Controls.Add(labelCountry);
        splitContainer8.Panel2.Controls.Add(countryComboBox);
        splitContainer8.Size = new System.Drawing.Size(488, 64);
        splitContainer8.SplitterDistance = 88;
        splitContainer8.TabIndex = 0;
        // 
        // label4
        // 
        label4.BackColor = System.Drawing.Color.FromArgb(((int)((byte)64)), ((int)((byte)64)), ((int)((byte)64)));
        label4.Dock = System.Windows.Forms.DockStyle.Fill;
        label4.Font = new System.Drawing.Font("Trebuchet MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        label4.ForeColor = System.Drawing.Color.White;
        label4.Location = new System.Drawing.Point(0, 0);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(88, 64);
        label4.TabIndex = 1;
        label4.Text = "Страна";
        label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // labelCountry
        // 
        labelCountry.Dock = System.Windows.Forms.DockStyle.Bottom;
        labelCountry.Font = new System.Drawing.Font("Trebuchet MS", 10.8F);
        labelCountry.ForeColor = System.Drawing.Color.White;
        labelCountry.Location = new System.Drawing.Point(0, 41);
        labelCountry.Name = "labelCountry";
        labelCountry.Size = new System.Drawing.Size(396, 23);
        labelCountry.TabIndex = 1;
        // 
        // countryComboBox
        // 
        countryComboBox.Dock = System.Windows.Forms.DockStyle.Top;
        countryComboBox.Font = new System.Drawing.Font("Trebuchet MS", 10.8F);
        countryComboBox.FormattingEnabled = true;
        countryComboBox.Location = new System.Drawing.Point(0, 0);
        countryComboBox.Name = "countryComboBox";
        countryComboBox.Size = new System.Drawing.Size(396, 31);
        countryComboBox.TabIndex = 1;
        countryComboBox.DropDown += countryComboBox_DropDown;
        countryComboBox.SelectedIndexChanged += countryComboBox_SelectedIndexChanged;
        countryComboBox.TextChanged += countryComboBox_TextChanged;
        countryComboBox.Leave += countryComboBox_Leave;
        // 
        // BrandRedactorForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.Black;
        ClientSize = new System.Drawing.Size(678, 349);
        Controls.Add(splitContainer1);
        Text = "BrandRedactorForm";
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        splitContainer2.Panel1.ResumeLayout(false);
        splitContainer2.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
        splitContainer2.ResumeLayout(false);
        splitContainer9.Panel1.ResumeLayout(false);
        splitContainer9.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer9).EndInit();
        splitContainer9.ResumeLayout(false);
        splitContainer10.Panel1.ResumeLayout(false);
        splitContainer10.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer10).EndInit();
        splitContainer10.ResumeLayout(false);
        splitContainer11.Panel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer11).EndInit();
        splitContainer11.ResumeLayout(false);
        splitContainer3.Panel1.ResumeLayout(false);
        splitContainer3.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
        splitContainer3.ResumeLayout(false);
        splitContainer6.Panel1.ResumeLayout(false);
        splitContainer6.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer6).EndInit();
        splitContainer6.ResumeLayout(false);
        splitContainer4.Panel1.ResumeLayout(false);
        splitContainer4.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
        splitContainer4.ResumeLayout(false);
        splitContainer7.Panel1.ResumeLayout(false);
        splitContainer7.Panel2.ResumeLayout(false);
        splitContainer7.Panel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer7).EndInit();
        splitContainer7.ResumeLayout(false);
        splitContainer5.Panel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer5).EndInit();
        splitContainer5.ResumeLayout(false);
        splitContainer8.Panel1.ResumeLayout(false);
        splitContainer8.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer8).EndInit();
        splitContainer8.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label labelCountry;

    private System.Windows.Forms.TextBox nameTextBox;

    private System.Windows.Forms.ComboBox countryComboBox;

    private System.Windows.Forms.ComboBox brandComboBox;

    private System.Windows.Forms.Label label4;

    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Button createBtn;
    private System.Windows.Forms.Button updateBtn;
    private System.Windows.Forms.Button deleteBtn;

    private System.Windows.Forms.SplitContainer splitContainer11;

    private System.Windows.Forms.SplitContainer splitContainer10;

    private System.Windows.Forms.SplitContainer splitContainer6;
    private System.Windows.Forms.SplitContainer splitContainer7;
    private System.Windows.Forms.SplitContainer splitContainer8;
    private System.Windows.Forms.SplitContainer splitContainer9;

    private System.Windows.Forms.SplitContainer splitContainer5;

    private System.Windows.Forms.SplitContainer splitContainer4;

    private System.Windows.Forms.SplitContainer splitContainer2;
    private System.Windows.Forms.SplitContainer splitContainer3;

    private System.Windows.Forms.SplitContainer splitContainer1;

    #endregion
}