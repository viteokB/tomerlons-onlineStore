using System.ComponentModel;

namespace OnlineStore.UI.Forms;

partial class RegisterForm
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
        roleComboBox = new System.Windows.Forms.ComboBox();
        emailTextBox = new System.Windows.Forms.TextBox();
        passwordTextBox = new System.Windows.Forms.TextBox();
        registerButton = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        repeatPasswordTextBox = new System.Windows.Forms.TextBox();
        goLoginButton = new System.Windows.Forms.Button();
        label5 = new System.Windows.Forms.Label();
        panel1 = new System.Windows.Forms.Panel();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // roleComboBox
        // 
        roleComboBox.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        roleComboBox.FormattingEnabled = true;
        roleComboBox.Location = new System.Drawing.Point(74, 121);
        roleComboBox.Name = "roleComboBox";
        roleComboBox.Size = new System.Drawing.Size(220, 31);
        roleComboBox.TabIndex = 0;
        // 
        // emailTextBox
        // 
        emailTextBox.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        emailTextBox.Location = new System.Drawing.Point(74, 183);
        emailTextBox.Name = "emailTextBox";
        emailTextBox.Size = new System.Drawing.Size(220, 27);
        emailTextBox.TabIndex = 1;
        // 
        // passwordTextBox
        // 
        passwordTextBox.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        passwordTextBox.Location = new System.Drawing.Point(74, 245);
        passwordTextBox.Name = "passwordTextBox";
        passwordTextBox.PasswordChar = '*';
        passwordTextBox.Size = new System.Drawing.Size(220, 27);
        passwordTextBox.TabIndex = 2;
        // 
        // registerButton
        // 
        registerButton.BackColor = System.Drawing.Color.Green;
        registerButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        registerButton.Font = new System.Drawing.Font("Trebuchet MS", 12F);
        registerButton.ForeColor = System.Drawing.SystemColors.Desktop;
        registerButton.Location = new System.Drawing.Point(74, 355);
        registerButton.Name = "registerButton";
        registerButton.Size = new System.Drawing.Size(220, 41);
        registerButton.TabIndex = 4;
        registerButton.Text = "Register";
        registerButton.UseVisualStyleBackColor = false;
        registerButton.Click += registerButton_Click;
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        label1.ForeColor = System.Drawing.SystemColors.Desktop;
        label1.Location = new System.Drawing.Point(74, 90);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(60, 28);
        label1.TabIndex = 6;
        label1.Text = "role:";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Trebuchet MS", 12F);
        label2.ForeColor = System.Drawing.SystemColors.Desktop;
        label2.Location = new System.Drawing.Point(74, 152);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(71, 28);
        label2.TabIndex = 7;
        label2.Text = "email:";
        label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // label3
        // 
        label3.Font = new System.Drawing.Font("Trebuchet MS", 12F);
        label3.ForeColor = System.Drawing.SystemColors.Desktop;
        label3.Location = new System.Drawing.Point(74, 214);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(103, 28);
        label3.TabIndex = 8;
        label3.Text = "password:";
        label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // label4
        // 
        label4.Font = new System.Drawing.Font("Trebuchet MS", 12F);
        label4.ForeColor = System.Drawing.SystemColors.Desktop;
        label4.Location = new System.Drawing.Point(74, 277);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(172, 28);
        label4.TabIndex = 10;
        label4.Text = "repeat password:";
        label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // repeatPasswordTextBox
        // 
        repeatPasswordTextBox.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        repeatPasswordTextBox.Location = new System.Drawing.Point(74, 308);
        repeatPasswordTextBox.Name = "repeatPasswordTextBox";
        repeatPasswordTextBox.PasswordChar = '*';
        repeatPasswordTextBox.Size = new System.Drawing.Size(220, 27);
        repeatPasswordTextBox.TabIndex = 3;
        // 
        // goLoginButton
        // 
        goLoginButton.BackColor = System.Drawing.Color.DarkOrchid;
        goLoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        goLoginButton.Font = new System.Drawing.Font("Trebuchet MS", 12F);
        goLoginButton.ForeColor = System.Drawing.SystemColors.Desktop;
        goLoginButton.Location = new System.Drawing.Point(250, 420);
        goLoginButton.Name = "goLoginButton";
        goLoginButton.Size = new System.Drawing.Size(103, 33);
        goLoginButton.TabIndex = 5;
        goLoginButton.Text = "Go login";
        goLoginButton.UseVisualStyleBackColor = false;
        goLoginButton.Click += goLoginButton_Click;
        // 
        // label5
        // 
        label5.Dock = System.Windows.Forms.DockStyle.Fill;
        label5.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        label5.ForeColor = System.Drawing.SystemColors.Desktop;
        label5.Location = new System.Drawing.Point(0, 0);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(365, 72);
        label5.TabIndex = 12;
        label5.Text = "Registration";
        label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // panel1
        // 
        panel1.BackColor = System.Drawing.Color.Maroon;
        panel1.Controls.Add(label5);
        panel1.Dock = System.Windows.Forms.DockStyle.Top;
        panel1.Location = new System.Drawing.Point(0, 0);
        panel1.Name = "panel1";
        panel1.Size = new System.Drawing.Size(365, 72);
        panel1.TabIndex = 13;
        // 
        // RegisterForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.RoyalBlue;
        ClientSize = new System.Drawing.Size(365, 465);
        Controls.Add(panel1);
        Controls.Add(goLoginButton);
        Controls.Add(label4);
        Controls.Add(repeatPasswordTextBox);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(registerButton);
        Controls.Add(passwordTextBox);
        Controls.Add(emailTextBox);
        Controls.Add(roleComboBox);
        Text = "RegisterForm";
        panel1.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Panel panel1;

    private System.Windows.Forms.Label label5;

    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox repeatPasswordTextBox;

    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Button registerButton;
    private System.Windows.Forms.Button goLoginButton;

    private System.Windows.Forms.TextBox emailTextBox;
    private System.Windows.Forms.TextBox passwordTextBox;

    private System.Windows.Forms.ComboBox roleComboBox;
    private System.Windows.Forms.Label label1;

    #endregion
}