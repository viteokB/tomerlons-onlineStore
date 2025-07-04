﻿using System.ComponentModel;

namespace OnlineStore.UI.Forms;

partial class AuthorForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthorForm));
        splitContainer1 = new System.Windows.Forms.SplitContainer();
        splitContainer3 = new System.Windows.Forms.SplitContainer();
        label1 = new System.Windows.Forms.Label();
        pictureBox1 = new System.Windows.Forms.PictureBox();
        splitContainer2 = new System.Windows.Forms.SplitContainer();
        label2 = new System.Windows.Forms.Label();
        splitContainer4 = new System.Windows.Forms.SplitContainer();
        label4 = new System.Windows.Forms.Label();
        splitContainer5 = new System.Windows.Forms.SplitContainer();
        label3 = new System.Windows.Forms.Label();
        label5 = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
        splitContainer3.Panel1.SuspendLayout();
        splitContainer3.Panel2.SuspendLayout();
        splitContainer3.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
        splitContainer2.Panel1.SuspendLayout();
        splitContainer2.Panel2.SuspendLayout();
        splitContainer2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
        splitContainer4.Panel1.SuspendLayout();
        splitContainer4.Panel2.SuspendLayout();
        splitContainer4.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer5).BeginInit();
        splitContainer5.Panel1.SuspendLayout();
        splitContainer5.Panel2.SuspendLayout();
        splitContainer5.SuspendLayout();
        SuspendLayout();
        // 
        // splitContainer1
        // 
        splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer1.Location = new System.Drawing.Point(0, 0);
        splitContainer1.Name = "splitContainer1";
        // 
        // splitContainer1.Panel1
        // 
        splitContainer1.Panel1.Controls.Add(splitContainer3);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(splitContainer2);
        splitContainer1.Size = new System.Drawing.Size(800, 450);
        splitContainer1.SplitterDistance = 280;
        splitContainer1.TabIndex = 0;
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
        splitContainer3.Panel1.Controls.Add(label1);
        // 
        // splitContainer3.Panel2
        // 
        splitContainer3.Panel2.Controls.Add(pictureBox1);
        splitContainer3.Size = new System.Drawing.Size(280, 450);
        splitContainer3.SplitterDistance = 63;
        splitContainer3.TabIndex = 0;
        // 
        // label1
        // 
        label1.BackColor = System.Drawing.Color.BlueViolet;
        label1.Dock = System.Windows.Forms.DockStyle.Fill;
        label1.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        label1.ForeColor = System.Drawing.SystemColors.Desktop;
        label1.Location = new System.Drawing.Point(0, 0);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(280, 63);
        label1.TabIndex = 0;
        label1.Text = "Фото автора";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // pictureBox1
        // 
        pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
        pictureBox1.Image = ((System.Drawing.Image)resources.GetObject("tomerlonPicture"));
        pictureBox1.Location = new System.Drawing.Point(0, 0);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new System.Drawing.Size(280, 383);
        pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        // 
        // splitContainer2
        // 
        splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer2.Location = new System.Drawing.Point(0, 0);
        splitContainer2.Name = "splitContainer2";
        splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // splitContainer2.Panel1
        // 
        splitContainer2.Panel1.Controls.Add(label2);
        // 
        // splitContainer2.Panel2
        // 
        splitContainer2.Panel2.Controls.Add(splitContainer4);
        splitContainer2.Size = new System.Drawing.Size(516, 450);
        splitContainer2.SplitterDistance = 62;
        splitContainer2.TabIndex = 0;
        // 
        // label2
        // 
        label2.BackColor = System.Drawing.Color.BlueViolet;
        label2.Dock = System.Windows.Forms.DockStyle.Fill;
        label2.Font = new System.Drawing.Font("Trebuchet MS", 13.8F);
        label2.ForeColor = System.Drawing.SystemColors.Desktop;
        label2.Location = new System.Drawing.Point(0, 0);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(516, 62);
        label2.TabIndex = 0;
        label2.Text = "О авторе";
        label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
        splitContainer4.Panel1.Controls.Add(label4);
        // 
        // splitContainer4.Panel2
        // 
        splitContainer4.Panel2.Controls.Add(splitContainer5);
        splitContainer4.Size = new System.Drawing.Size(516, 384);
        splitContainer4.SplitterDistance = 140;
        splitContainer4.TabIndex = 0;
        // 
        // label4
        // 
        label4.Dock = System.Windows.Forms.DockStyle.Fill;
        label4.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        label4.ForeColor = System.Drawing.SystemColors.Desktop;
        label4.Location = new System.Drawing.Point(0, 0);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(516, 140);
        label4.TabIndex = 0;
        label4.Text = "    Привет, я Томерлон\r\n    Мой контакт в телеграмм @tomerlon7187";
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
        splitContainer5.Panel1.BackColor = System.Drawing.Color.BlueViolet;
        splitContainer5.Panel1.Controls.Add(label3);
        splitContainer5.Panel1.Font = new System.Drawing.Font("Trebuchet MS", 13.8F);
        splitContainer5.Panel1.ForeColor = System.Drawing.SystemColors.Desktop;
        // 
        // splitContainer5.Panel2
        // 
        splitContainer5.Panel2.Controls.Add(label5);
        splitContainer5.Size = new System.Drawing.Size(516, 240);
        splitContainer5.SplitterDistance = 59;
        splitContainer5.TabIndex = 0;
        // 
        // label3
        // 
        label3.Dock = System.Windows.Forms.DockStyle.Fill;
        label3.Location = new System.Drawing.Point(0, 0);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(516, 59);
        label3.TabIndex = 0;
        label3.Text = "О приложении";
        label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label5
        // 
        label5.Dock = System.Windows.Forms.DockStyle.Fill;
        label5.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        label5.ForeColor = System.Drawing.SystemColors.Desktop;
        label5.Location = new System.Drawing.Point(0, 0);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(516, 177);
        label5.TabIndex = 0;
        label5.Text = "    Оконное приложение на Windows Forms\r\n    Онлайн-магазин автодеталей\r\n    Версия: v0.666";
        // 
        // AuthorForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.Blue;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(splitContainer1);
        Text = "AuthorForm";
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        splitContainer3.Panel1.ResumeLayout(false);
        splitContainer3.Panel2.ResumeLayout(false);
        splitContainer3.Panel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
        splitContainer3.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        splitContainer2.Panel1.ResumeLayout(false);
        splitContainer2.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
        splitContainer2.ResumeLayout(false);
        splitContainer4.Panel1.ResumeLayout(false);
        splitContainer4.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
        splitContainer4.ResumeLayout(false);
        splitContainer5.Panel1.ResumeLayout(false);
        splitContainer5.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer5).EndInit();
        splitContainer5.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label label5;

    private System.Windows.Forms.Label label4;

    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.SplitContainer splitContainer5;

    private System.Windows.Forms.SplitContainer splitContainer4;

    private System.Windows.Forms.PictureBox pictureBox1;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.SplitContainer splitContainer3;

    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.SplitContainer splitContainer2;

    #endregion
}