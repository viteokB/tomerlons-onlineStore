using System.ComponentModel;

namespace OnlineStore.UI.Forms;

partial class PurchaseForm
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
        justLabel = new System.Windows.Forms.Label();
        lblProductName = new System.Windows.Forms.Label();
        justLabel2 = new System.Windows.Forms.Label();
        lblPrice = new System.Windows.Forms.Label();
        numQuantity = new System.Windows.Forms.NumericUpDown();
        label1 = new System.Windows.Forms.Label();
        cmbWarehouse = new System.Windows.Forms.ComboBox();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        label5 = new System.Windows.Forms.Label();
        label6 = new System.Windows.Forms.Label();
        label7 = new System.Windows.Forms.Label();
        txtCity = new System.Windows.Forms.TextBox();
        txtStreet = new System.Windows.Forms.TextBox();
        txtBuilding = new System.Windows.Forms.TextBox();
        txtApartment = new System.Windows.Forms.TextBox();
        txtCountry = new System.Windows.Forms.Label();
        textBox1 = new System.Windows.Forms.TextBox();
        label8 = new System.Windows.Forms.Label();
        txtDescription = new System.Windows.Forms.RichTextBox();
        btnConfirm = new System.Windows.Forms.Button();
        btnCancel = new System.Windows.Forms.Button();
        lblAvailability = new System.Windows.Forms.Label();
        label9 = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
        SuspendLayout();
        // 
        // justLabel
        // 
        justLabel.Location = new System.Drawing.Point(12, 9);
        justLabel.Name = "justLabel";
        justLabel.Size = new System.Drawing.Size(132, 23);
        justLabel.TabIndex = 0;
        justLabel.Text = "Выбран продукт:";
        // 
        // lblProductName
        // 
        lblProductName.Location = new System.Drawing.Point(164, 9);
        lblProductName.Name = "lblProductName";
        lblProductName.Size = new System.Drawing.Size(241, 23);
        lblProductName.TabIndex = 1;
        // 
        // justLabel2
        // 
        justLabel2.Location = new System.Drawing.Point(12, 48);
        justLabel2.Name = "justLabel2";
        justLabel2.Size = new System.Drawing.Size(132, 23);
        justLabel2.TabIndex = 2;
        justLabel2.Text = "Цена продукта:";
        // 
        // lblPrice
        // 
        lblPrice.Location = new System.Drawing.Point(164, 48);
        lblPrice.Name = "lblPrice";
        lblPrice.Size = new System.Drawing.Size(141, 23);
        lblPrice.TabIndex = 3;
        // 
        // numQuantity
        // 
        numQuantity.Location = new System.Drawing.Point(164, 93);
        numQuantity.Name = "numQuantity";
        numQuantity.Size = new System.Drawing.Size(120, 27);
        numQuantity.TabIndex = 5;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(12, 143);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(100, 23);
        label1.TabIndex = 6;
        label1.Text = "Склад:";
        // 
        // cmbWarehouse
        // 
        cmbWarehouse.FormattingEnabled = true;
        cmbWarehouse.Location = new System.Drawing.Point(164, 140);
        cmbWarehouse.Name = "cmbWarehouse";
        cmbWarehouse.Size = new System.Drawing.Size(194, 28);
        cmbWarehouse.TabIndex = 7;
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(426, 9);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(70, 23);
        label2.TabIndex = 8;
        label2.Text = "Адресс:";
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(12, 93);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(132, 23);
        label3.TabIndex = 9;
        label3.Text = "Выберите кол-во:";
        // 
        // label4
        // 
        label4.Location = new System.Drawing.Point(451, 74);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(100, 23);
        label4.TabIndex = 10;
        label4.Text = "Город";
        label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // label5
        // 
        label5.Location = new System.Drawing.Point(451, 117);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(100, 23);
        label5.TabIndex = 11;
        label5.Text = "Улица";
        label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // label6
        // 
        label6.Location = new System.Drawing.Point(451, 160);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(100, 23);
        label6.TabIndex = 12;
        label6.Text = "Дом";
        label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // label7
        // 
        label7.Location = new System.Drawing.Point(430, 199);
        label7.Name = "label7";
        label7.Size = new System.Drawing.Size(121, 23);
        label7.TabIndex = 13;
        label7.Text = "Квартира/Офис";
        // 
        // txtCity
        // 
        txtCity.Location = new System.Drawing.Point(580, 70);
        txtCity.Name = "txtCity";
        txtCity.Size = new System.Drawing.Size(146, 27);
        txtCity.TabIndex = 14;
        // 
        // txtStreet
        // 
        txtStreet.Location = new System.Drawing.Point(580, 117);
        txtStreet.Name = "txtStreet";
        txtStreet.Size = new System.Drawing.Size(146, 27);
        txtStreet.TabIndex = 15;
        // 
        // txtBuilding
        // 
        txtBuilding.Location = new System.Drawing.Point(580, 158);
        txtBuilding.Name = "txtBuilding";
        txtBuilding.Size = new System.Drawing.Size(146, 27);
        txtBuilding.TabIndex = 16;
        // 
        // txtApartment
        // 
        txtApartment.Location = new System.Drawing.Point(580, 199);
        txtApartment.Name = "txtApartment";
        txtApartment.Size = new System.Drawing.Size(146, 27);
        txtApartment.TabIndex = 17;
        // 
        // txtCountry
        // 
        txtCountry.Location = new System.Drawing.Point(482, 32);
        txtCountry.Name = "txtCountry";
        txtCountry.Size = new System.Drawing.Size(69, 23);
        txtCountry.TabIndex = 18;
        txtCountry.Text = "Страна:";
        txtCountry.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(580, 28);
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(146, 27);
        textBox1.TabIndex = 19;
        // 
        // label8
        // 
        label8.Location = new System.Drawing.Point(12, 227);
        label8.Name = "label8";
        label8.Size = new System.Drawing.Size(100, 23);
        label8.TabIndex = 20;
        label8.Text = "Описание:";
        // 
        // txtDescription
        // 
        txtDescription.Location = new System.Drawing.Point(129, 227);
        txtDescription.Name = "txtDescription";
        txtDescription.Size = new System.Drawing.Size(229, 96);
        txtDescription.TabIndex = 21;
        txtDescription.Text = "";
        // 
        // btnConfirm
        // 
        btnConfirm.Location = new System.Drawing.Point(529, 251);
        btnConfirm.Name = "btnConfirm";
        btnConfirm.Size = new System.Drawing.Size(93, 34);
        btnConfirm.TabIndex = 22;
        btnConfirm.Text = "btnConfirm";
        btnConfirm.UseVisualStyleBackColor = true;
        // 
        // btnCancel
        // 
        btnCancel.Location = new System.Drawing.Point(638, 251);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new System.Drawing.Size(88, 34);
        btnCancel.TabIndex = 23;
        btnCancel.Text = "btnCancel";
        btnCancel.UseVisualStyleBackColor = true;
        // 
        // lblAvailability
        // 
        lblAvailability.Location = new System.Drawing.Point(164, 185);
        lblAvailability.Name = "lblAvailability";
        lblAvailability.Size = new System.Drawing.Size(100, 23);
        lblAvailability.TabIndex = 24;
        // 
        // label9
        // 
        label9.Location = new System.Drawing.Point(12, 185);
        label9.Name = "label9";
        label9.Size = new System.Drawing.Size(146, 23);
        label9.TabIndex = 25;
        label9.Text = "Есть на складе:";
        // 
        // PurchaseForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(750, 335);
        Controls.Add(label9);
        Controls.Add(lblAvailability);
        Controls.Add(btnCancel);
        Controls.Add(btnConfirm);
        Controls.Add(txtDescription);
        Controls.Add(label8);
        Controls.Add(textBox1);
        Controls.Add(txtCountry);
        Controls.Add(txtApartment);
        Controls.Add(txtBuilding);
        Controls.Add(txtStreet);
        Controls.Add(txtCity);
        Controls.Add(label7);
        Controls.Add(label6);
        Controls.Add(label5);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(cmbWarehouse);
        Controls.Add(label1);
        Controls.Add(numQuantity);
        Controls.Add(lblPrice);
        Controls.Add(justLabel2);
        Controls.Add(lblProductName);
        Controls.Add(justLabel);
        Text = "PurchaseForm";
        ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label lblAvailability;
    private System.Windows.Forms.Label label9;

    private System.Windows.Forms.Button btnConfirm;

    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.RichTextBox txtDescription;
    private System.Windows.Forms.Button btnCancel;

    private System.Windows.Forms.Label txtCountry;
    private System.Windows.Forms.TextBox textBox1;

    private System.Windows.Forms.TextBox txtCity;
    private System.Windows.Forms.TextBox txtStreet;
    private System.Windows.Forms.TextBox txtBuilding;
    private System.Windows.Forms.TextBox txtApartment;

    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;

    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Label lblPrice;
    private System.Windows.Forms.NumericUpDown numQuantity;
    private System.Windows.Forms.ComboBox cmbWarehouse;

    private System.Windows.Forms.Label justLabel2;
    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Label justLabel;
    private System.Windows.Forms.Label lblProductName;

    #endregion
}