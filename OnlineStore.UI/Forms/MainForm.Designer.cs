using System.ComponentModel;

namespace OnlineStore.UI.Forms;

partial class MainForm
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
        button1 = new Button();
        button2 = new Button();
        button3 = new Button();
        button4 = new Button();
        button5 = new Button();
        button6 = new Button();
        button7 = new Button();
        warehouseDialog = new Button();
        btnUserCart = new Button();
        btnAdminOrders = new Button();
        btnProductForm = new Button();
        button8 = new Button();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new Point(224, 142);
        button1.Name = "button1";
        button1.Size = new Size(75, 36);
        button1.TabIndex = 0;
        button1.Text = "login";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // button2
        // 
        button2.Location = new Point(339, 142);
        button2.Name = "button2";
        button2.Size = new Size(75, 36);
        button2.TabIndex = 1;
        button2.Text = "register";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // button3
        // 
        button3.Location = new Point(25, 12);
        button3.Name = "button3";
        button3.Size = new Size(75, 36);
        button3.TabIndex = 2;
        button3.Text = "About";
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click;
        // 
        // button4
        // 
        button4.Location = new Point(576, 142);
        button4.Name = "button4";
        button4.Size = new Size(115, 36);
        button4.TabIndex = 3;
        button4.Text = "typesRedactor";
        button4.UseVisualStyleBackColor = true;
        button4.Click += button4_Click;
        // 
        // button5
        // 
        button5.Location = new Point(576, 203);
        button5.Name = "button5";
        button5.Size = new Size(115, 36);
        button5.TabIndex = 4;
        button5.Text = "countryDialog";
        button5.UseVisualStyleBackColor = true;
        button5.Click += button5_Click;
        // 
        // button6
        // 
        button6.Location = new Point(576, 266);
        button6.Name = "button6";
        button6.Size = new Size(115, 36);
        button6.TabIndex = 5;
        button6.Text = "brandDialog";
        button6.UseVisualStyleBackColor = true;
        button6.Click += button6_Click;
        // 
        // button7
        // 
        button7.Location = new Point(576, 88);
        button7.Name = "button7";
        button7.Size = new Size(115, 36);
        button7.TabIndex = 6;
        button7.Text = "productRedactory";
        button7.UseVisualStyleBackColor = true;
        button7.Click += button7_Click;
        // 
        // warehouseDialog
        // 
        warehouseDialog.Location = new Point(576, 329);
        warehouseDialog.Name = "warehouseDialog";
        warehouseDialog.Size = new Size(115, 36);
        warehouseDialog.TabIndex = 7;
        warehouseDialog.Text = "warehouseDialog";
        warehouseDialog.UseVisualStyleBackColor = true;
        warehouseDialog.Click += warehouseDialog_Click;
        // 
        // btnUserCart
        // 
        btnUserCart.Location = new Point(339, 199);
        btnUserCart.Name = "btnUserCart";
        btnUserCart.Size = new Size(75, 44);
        btnUserCart.TabIndex = 8;
        btnUserCart.Text = "User cart";
        btnUserCart.UseVisualStyleBackColor = true;
        btnUserCart.Click += btnUserCart_Click;
        // 
        // btnAdminOrders
        // 
        btnAdminOrders.Location = new Point(576, 380);
        btnAdminOrders.Name = "btnAdminOrders";
        btnAdminOrders.Size = new Size(115, 44);
        btnAdminOrders.TabIndex = 9;
        btnAdminOrders.Text = "Admin orders";
        btnAdminOrders.UseVisualStyleBackColor = true;
        btnAdminOrders.Click += btnAdminOrders_Click;
        // 
        // btnProductForm
        // 
        btnProductForm.Location = new Point(339, 262);
        btnProductForm.Name = "btnProductForm";
        btnProductForm.Size = new Size(75, 44);
        btnProductForm.TabIndex = 10;
        btnProductForm.Text = "products";
        btnProductForm.UseVisualStyleBackColor = true;
        btnProductForm.Click += btnProductForm_Click;
        // 
        // button8
        // 
        button8.Location = new Point(576, 32);
        button8.Name = "button8";
        button8.Size = new Size(115, 36);
        button8.TabIndex = 11;
        button8.Text = "dashboard";
        button8.UseVisualStyleBackColor = true;
        button8.Click += button8_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(button8);
        Controls.Add(btnProductForm);
        Controls.Add(btnAdminOrders);
        Controls.Add(btnUserCart);
        Controls.Add(warehouseDialog);
        Controls.Add(button7);
        Controls.Add(button6);
        Controls.Add(button5);
        Controls.Add(button4);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(button1);
        Name = "MainForm";
        Text = "MainForm";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button btnProductForm;

    private System.Windows.Forms.Button btnUserCart;
    private System.Windows.Forms.Button btnAdminOrders;

    private System.Windows.Forms.Button warehouseDialog;
    
    private System.Windows.Forms.Button button7;

    private System.Windows.Forms.Button button6;

    private System.Windows.Forms.Button button5;

    private System.Windows.Forms.Button button4;

    private System.Windows.Forms.Button button3;

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;

    #endregion

    private Button button8;
}