using System.ComponentModel;

namespace OnlineStore.UI.Forms;

partial class LoginForm
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
        loginButton = new System.Windows.Forms.Button();
        emailTextBox = new System.Windows.Forms.TextBox();
        passwordTextBox = new System.Windows.Forms.TextBox();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        registerOpenButton = new System.Windows.Forms.Button();
        panel1 = new System.Windows.Forms.Panel();
        label5 = new System.Windows.Forms.Label();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // loginButton
        // 
        loginButton.BackColor = System.Drawing.Color.Green;
        loginButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
        loginButton.Cursor = System.Windows.Forms.Cursors.Hand;
        loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        loginButton.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        loginButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
        loginButton.Location = new System.Drawing.Point(56, 258);
        loginButton.Name = "loginButton";
        loginButton.Size = new System.Drawing.Size(193, 46);
        loginButton.TabIndex = 3;
        loginButton.Text = "logIn";
        loginButton.UseVisualStyleBackColor = false;
        loginButton.Click += LoginButton_Click;
        // 
        // emailTextBox
        // 
        emailTextBox.Font = new System.Drawing.Font("Trebuchet MS", 10.2F);
        emailTextBox.Location = new System.Drawing.Point(56, 119);
        emailTextBox.Name = "emailTextBox";
        emailTextBox.Size = new System.Drawing.Size(193, 27);
        emailTextBox.TabIndex = 1;
        // 
        // passwordTextBox
        // 
        passwordTextBox.Font = new System.Drawing.Font("Trebuchet MS", 10.2F);
        passwordTextBox.Location = new System.Drawing.Point(56, 200);
        passwordTextBox.Name = "passwordTextBox";
        passwordTextBox.PasswordChar = '*';
        passwordTextBox.Size = new System.Drawing.Size(193, 27);
        passwordTextBox.TabIndex = 2;
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        label1.Location = new System.Drawing.Point(56, 93);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(49, 23);
        label1.TabIndex = 3;
        label1.Visible = false;
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        label2.Location = new System.Drawing.Point(56, 174);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(85, 23);
        label2.TabIndex = 4;
        label2.Visible = false;
        // 
        // label3
        // 
        label3.Font = new System.Drawing.Font("Trebuchet MS", 10.2F);
        label3.Location = new System.Drawing.Point(56, 93);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(55, 23);
        label3.TabIndex = 5;
        label3.Text = "email";
        // 
        // label4
        // 
        label4.Font = new System.Drawing.Font("Trebuchet MS", 10.2F);
        label4.Location = new System.Drawing.Point(56, 176);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(95, 23);
        label4.TabIndex = 6;
        label4.Text = "password";
        // 
        // registerOpenButton
        // 
        registerOpenButton.BackColor = System.Drawing.Color.Teal;
        registerOpenButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
        registerOpenButton.Cursor = System.Windows.Forms.Cursors.Hand;
        registerOpenButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        registerOpenButton.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        registerOpenButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
        registerOpenButton.Location = new System.Drawing.Point(192, 321);
        registerOpenButton.Name = "registerOpenButton";
        registerOpenButton.Size = new System.Drawing.Size(92, 36);
        registerOpenButton.TabIndex = 7;
        registerOpenButton.Text = "register";
        registerOpenButton.UseVisualStyleBackColor = false;
        registerOpenButton.Click += registerOpenButton_Click;
        // 
        // panel1
        // 
        panel1.BackColor = System.Drawing.Color.DarkRed;
        panel1.Controls.Add(label5);
        panel1.Dock = System.Windows.Forms.DockStyle.Top;
        panel1.Location = new System.Drawing.Point(0, 0);
        panel1.Name = "panel1";
        panel1.Size = new System.Drawing.Size(302, 78);
        panel1.TabIndex = 8;
        // 
        // label5
        // 
        label5.Dock = System.Windows.Forms.DockStyle.Fill;
        label5.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        label5.Location = new System.Drawing.Point(0, 0);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(302, 78);
        label5.TabIndex = 0;
        label5.Text = "LogIn";
        label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // LoginForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.DarkOrchid;
        BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        ClientSize = new System.Drawing.Size(302, 371);
        Controls.Add(panel1);
        Controls.Add(registerOpenButton);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(passwordTextBox);
        Controls.Add(emailTextBox);
        Controls.Add(loginButton);
        ForeColor = System.Drawing.SystemColors.ButtonHighlight;
        Location = new System.Drawing.Point(19, 19);
        panel1.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label label5;

    private System.Windows.Forms.Panel panel1;

    private System.Windows.Forms.Button registerOpenButton;

    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.TextBox emailTextBox;
    private System.Windows.Forms.TextBox passwordTextBox;
    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Button loginButton;

    #endregion
}