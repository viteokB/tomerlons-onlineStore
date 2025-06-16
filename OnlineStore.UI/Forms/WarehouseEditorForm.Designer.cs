using System.ComponentModel;

namespace OnlineStore.UI.Forms;

partial class WarehouseEditorForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WarehouseEditorForm));
        warehousesDataGridView = new System.Windows.Forms.DataGridView();
        productsDataGridView = new System.Windows.Forms.DataGridView();
        warehouseSearchTextBox = new System.Windows.Forms.TextBox();
        productSearchTextBox = new System.Windows.Forms.TextBox();
        warehouseSearchButton = new System.Windows.Forms.Button();
        productSearchButton = new System.Windows.Forms.Button();
        warehouseNameTextBox = new System.Windows.Forms.TextBox();
        isActiveCheckBox = new System.Windows.Forms.CheckBox();
        productCountNumeric = new System.Windows.Forms.NumericUpDown();
        btnUpdateWarehouse = new System.Windows.Forms.Button();
        updateProductCountButton = new System.Windows.Forms.Button();
        countryTextBox = new System.Windows.Forms.TextBox();
        cityTextBox = new System.Windows.Forms.TextBox();
        streetTextBox = new System.Windows.Forms.TextBox();
        houseNumberTextBox = new System.Windows.Forms.TextBox();
        apartmentTextBox = new System.Windows.Forms.TextBox();
        coordinateLatitudeNumeric = new System.Windows.Forms.NumericUpDown();
        coordinateLongitudeNumeric = new System.Windows.Forms.NumericUpDown();
        btnAddWarehouse = new System.Windows.Forms.Button();
        btnDeleteWarehouse = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        label5 = new System.Windows.Forms.Label();
        label6 = new System.Windows.Forms.Label();
        label7 = new System.Windows.Forms.Label();
        label8 = new System.Windows.Forms.Label();
        label9 = new System.Windows.Forms.Label();
        label10 = new System.Windows.Forms.Label();
        label11 = new System.Windows.Forms.Label();
        label12 = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)warehousesDataGridView).BeginInit();
        ((System.ComponentModel.ISupportInitialize)productsDataGridView).BeginInit();
        ((System.ComponentModel.ISupportInitialize)productCountNumeric).BeginInit();
        ((System.ComponentModel.ISupportInitialize)coordinateLatitudeNumeric).BeginInit();
        ((System.ComponentModel.ISupportInitialize)coordinateLongitudeNumeric).BeginInit();
        SuspendLayout();
        // 
        // warehousesDataGridView
        // 
        warehousesDataGridView.ColumnHeadersHeight = 29;
        warehousesDataGridView.Location = new System.Drawing.Point(32, 72);
        warehousesDataGridView.Name = "warehousesDataGridView";
        warehousesDataGridView.RowHeadersWidth = 51;
        warehousesDataGridView.Size = new System.Drawing.Size(362, 264);
        warehousesDataGridView.TabIndex = 0;
        // 
        // productsDataGridView
        // 
        productsDataGridView.ColumnHeadersHeight = 29;
        productsDataGridView.Location = new System.Drawing.Point(450, 72);
        productsDataGridView.Name = "productsDataGridView";
        productsDataGridView.RowHeadersWidth = 51;
        productsDataGridView.Size = new System.Drawing.Size(387, 266);
        productsDataGridView.TabIndex = 1;
        // 
        // warehouseSearchTextBox
        // 
        warehouseSearchTextBox.Location = new System.Drawing.Point(32, 25);
        warehouseSearchTextBox.Name = "warehouseSearchTextBox";
        warehouseSearchTextBox.Size = new System.Drawing.Size(240, 27);
        warehouseSearchTextBox.TabIndex = 2;
        // 
        // productSearchTextBox
        // 
        productSearchTextBox.Location = new System.Drawing.Point(450, 25);
        productSearchTextBox.Name = "productSearchTextBox";
        productSearchTextBox.Size = new System.Drawing.Size(240, 27);
        productSearchTextBox.TabIndex = 3;
        // 
        // warehouseSearchButton
        // 
        warehouseSearchButton.Location = new System.Drawing.Point(294, 11);
        warehouseSearchButton.Name = "warehouseSearchButton";
        warehouseSearchButton.Size = new System.Drawing.Size(100, 48);
        warehouseSearchButton.TabIndex = 4;
        warehouseSearchButton.Text = "Поиск склада";
        warehouseSearchButton.UseVisualStyleBackColor = true;
        // 
        // productSearchButton
        // 
        productSearchButton.Location = new System.Drawing.Point(737, 14);
        productSearchButton.Name = "productSearchButton";
        productSearchButton.Size = new System.Drawing.Size(100, 48);
        productSearchButton.TabIndex = 5;
        productSearchButton.Text = "Поиск товара";
        productSearchButton.UseVisualStyleBackColor = true;
        // 
        // warehouseNameTextBox
        // 
        warehouseNameTextBox.Location = new System.Drawing.Point(205, 344);
        warehouseNameTextBox.Name = "warehouseNameTextBox";
        warehouseNameTextBox.Size = new System.Drawing.Size(192, 27);
        warehouseNameTextBox.TabIndex = 6;
        // 
        // isActiveCheckBox
        // 
        isActiveCheckBox.Location = new System.Drawing.Point(205, 385);
        isActiveCheckBox.Name = "isActiveCheckBox";
        isActiveCheckBox.Size = new System.Drawing.Size(161, 24);
        isActiveCheckBox.TabIndex = 7;
        isActiveCheckBox.Text = "isActiveCheckBox";
        isActiveCheckBox.UseVisualStyleBackColor = true;
        // 
        // productCountNumeric
        // 
        productCountNumeric.Location = new System.Drawing.Point(717, 344);
        productCountNumeric.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        productCountNumeric.Name = "productCountNumeric";
        productCountNumeric.Size = new System.Drawing.Size(120, 27);
        productCountNumeric.TabIndex = 12;
        // 
        // btnUpdateWarehouse
        // 
        btnUpdateWarehouse.Location = new System.Drawing.Point(314, 672);
        btnUpdateWarehouse.Name = "btnUpdateWarehouse";
        btnUpdateWarehouse.Size = new System.Drawing.Size(86, 48);
        btnUpdateWarehouse.TabIndex = 13;
        btnUpdateWarehouse.Text = "Обновить склад";
        btnUpdateWarehouse.UseVisualStyleBackColor = true;
        // 
        // updateProductCountButton
        // 
        updateProductCountButton.Location = new System.Drawing.Point(752, 385);
        updateProductCountButton.Name = "updateProductCountButton";
        updateProductCountButton.Size = new System.Drawing.Size(85, 48);
        updateProductCountButton.TabIndex = 14;
        updateProductCountButton.Text = "обновить кол-во";
        updateProductCountButton.UseVisualStyleBackColor = true;
        // 
        // countryTextBox
        // 
        countryTextBox.Location = new System.Drawing.Point(205, 435);
        countryTextBox.Name = "countryTextBox";
        countryTextBox.Size = new System.Drawing.Size(192, 27);
        countryTextBox.TabIndex = 15;
        // 
        // cityTextBox
        // 
        cityTextBox.Location = new System.Drawing.Point(205, 468);
        cityTextBox.Name = "cityTextBox";
        cityTextBox.Size = new System.Drawing.Size(192, 27);
        cityTextBox.TabIndex = 16;
        // 
        // streetTextBox
        // 
        streetTextBox.Location = new System.Drawing.Point(205, 501);
        streetTextBox.Name = "streetTextBox";
        streetTextBox.Size = new System.Drawing.Size(192, 27);
        streetTextBox.TabIndex = 17;
        // 
        // houseNumberTextBox
        // 
        houseNumberTextBox.Location = new System.Drawing.Point(205, 534);
        houseNumberTextBox.Name = "houseNumberTextBox";
        houseNumberTextBox.Size = new System.Drawing.Size(192, 27);
        houseNumberTextBox.TabIndex = 18;
        // 
        // apartmentTextBox
        // 
        apartmentTextBox.Location = new System.Drawing.Point(205, 567);
        apartmentTextBox.Name = "apartmentTextBox";
        apartmentTextBox.Size = new System.Drawing.Size(192, 27);
        apartmentTextBox.TabIndex = 22;
        // 
        // coordinateLatitudeNumeric
        // 
        coordinateLatitudeNumeric.Location = new System.Drawing.Point(266, 600);
        coordinateLatitudeNumeric.Name = "coordinateLatitudeNumeric";
        coordinateLatitudeNumeric.Size = new System.Drawing.Size(131, 27);
        coordinateLatitudeNumeric.TabIndex = 23;
        // 
        // coordinateLongitudeNumeric
        // 
        coordinateLongitudeNumeric.Location = new System.Drawing.Point(266, 633);
        coordinateLongitudeNumeric.Name = "coordinateLongitudeNumeric";
        coordinateLongitudeNumeric.Size = new System.Drawing.Size(131, 27);
        coordinateLongitudeNumeric.TabIndex = 24;
        // 
        // btnAddWarehouse
        // 
        btnAddWarehouse.Location = new System.Drawing.Point(205, 672);
        btnAddWarehouse.Name = "btnAddWarehouse";
        btnAddWarehouse.Size = new System.Drawing.Size(86, 48);
        btnAddWarehouse.TabIndex = 28;
        btnAddWarehouse.Text = "Добавить склад";
        btnAddWarehouse.UseVisualStyleBackColor = true;
        // 
        // btnDeleteWarehouse
        // 
        btnDeleteWarehouse.Location = new System.Drawing.Point(100, 672);
        btnDeleteWarehouse.Name = "btnDeleteWarehouse";
        btnDeleteWarehouse.Size = new System.Drawing.Size(86, 48);
        btnDeleteWarehouse.TabIndex = 29;
        btnDeleteWarehouse.Text = "Удалить склад";
        btnDeleteWarehouse.UseVisualStyleBackColor = true;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(32, 347);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(154, 24);
        label1.TabIndex = 30;
        label1.Text = "Название склада";
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(32, 386);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(154, 24);
        label2.TabIndex = 31;
        label2.Text = "Активировать склад";
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(32, 423);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(69, 24);
        label3.TabIndex = 32;
        label3.Text = "Адресс:";
        // 
        // label4
        // 
        label4.Location = new System.Drawing.Point(107, 435);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(92, 24);
        label4.TabIndex = 33;
        label4.Text = "Страна:";
        label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // label5
        // 
        label5.Location = new System.Drawing.Point(65, 468);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(134, 24);
        label5.TabIndex = 34;
        label5.Text = "Город:";
        label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // label6
        // 
        label6.Location = new System.Drawing.Point(65, 504);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(134, 24);
        label6.TabIndex = 35;
        label6.Text = "Улица:";
        label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // label7
        // 
        label7.Location = new System.Drawing.Point(65, 537);
        label7.Name = "label7";
        label7.Size = new System.Drawing.Size(134, 24);
        label7.TabIndex = 36;
        label7.Text = "Номер здания:";
        label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // label8
        // 
        label8.Location = new System.Drawing.Point(12, 567);
        label8.Name = "label8";
        label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
        label8.Size = new System.Drawing.Size(187, 24);
        label8.TabIndex = 37;
        label8.Text = "Номер квартиры/офиса:";
        label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // label9
        // 
        label9.Location = new System.Drawing.Point(556, 348);
        label9.Name = "label9";
        label9.Size = new System.Drawing.Size(146, 23);
        label9.TabIndex = 38;
        label9.Text = "Количество товара:";
        // 
        // label10
        // 
        label10.Location = new System.Drawing.Point(160, 600);
        label10.Name = "label10";
        label10.Size = new System.Drawing.Size(100, 23);
        label10.TabIndex = 39;
        label10.Text = "Долгота:";
        label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // label11
        // 
        label11.Location = new System.Drawing.Point(160, 633);
        label11.Name = "label11";
        label11.Size = new System.Drawing.Size(100, 23);
        label11.TabIndex = 40;
        label11.Text = "Широта:";
        label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // label12
        // 
        label12.Location = new System.Drawing.Point(471, 504);
        label12.Name = "label12";
        label12.Size = new System.Drawing.Size(385, 216);
        label12.TabIndex = 41;
        label12.Text = resources.GetString("label12.Text");
        // 
        // WarehouseEditorForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(868, 732);
        Controls.Add(label12);
        Controls.Add(label11);
        Controls.Add(label10);
        Controls.Add(label9);
        Controls.Add(label8);
        Controls.Add(label7);
        Controls.Add(label6);
        Controls.Add(label5);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(btnDeleteWarehouse);
        Controls.Add(btnAddWarehouse);
        Controls.Add(coordinateLongitudeNumeric);
        Controls.Add(coordinateLatitudeNumeric);
        Controls.Add(apartmentTextBox);
        Controls.Add(houseNumberTextBox);
        Controls.Add(streetTextBox);
        Controls.Add(cityTextBox);
        Controls.Add(countryTextBox);
        Controls.Add(updateProductCountButton);
        Controls.Add(btnUpdateWarehouse);
        Controls.Add(productCountNumeric);
        Controls.Add(isActiveCheckBox);
        Controls.Add(warehouseNameTextBox);
        Controls.Add(productSearchButton);
        Controls.Add(warehouseSearchButton);
        Controls.Add(productSearchTextBox);
        Controls.Add(warehouseSearchTextBox);
        Controls.Add(productsDataGridView);
        Controls.Add(warehousesDataGridView);
        Text = "WarehouseEditorForm";
        ((System.ComponentModel.ISupportInitialize)warehousesDataGridView).EndInit();
        ((System.ComponentModel.ISupportInitialize)productsDataGridView).EndInit();
        ((System.ComponentModel.ISupportInitialize)productCountNumeric).EndInit();
        ((System.ComponentModel.ISupportInitialize)coordinateLatitudeNumeric).EndInit();
        ((System.ComponentModel.ISupportInitialize)coordinateLongitudeNumeric).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label label12;

    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label11;

    private System.Windows.Forms.Label label9;

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;

    private System.Windows.Forms.Button btnDeleteWarehouse;

    private System.Windows.Forms.Button btnAddWarehouse;

    private System.Windows.Forms.NumericUpDown coordinateLatitudeNumeric;
    private System.Windows.Forms.NumericUpDown coordinateLongitudeNumeric;

    private System.Windows.Forms.TextBox apartmentTextBox;

    private System.Windows.Forms.TextBox countryTextBox;
    private System.Windows.Forms.TextBox cityTextBox;
    private System.Windows.Forms.TextBox streetTextBox;
    private System.Windows.Forms.TextBox houseNumberTextBox;

    private System.Windows.Forms.Button updateProductCountButton;

    private System.Windows.Forms.Button btnUpdateWarehouse;

    private System.Windows.Forms.NumericUpDown productCountNumeric;

    private System.Windows.Forms.CheckBox isActiveCheckBox;

    private System.Windows.Forms.Button warehouseSearchButton;
    private System.Windows.Forms.TextBox warehouseNameTextBox;

    private System.Windows.Forms.Button productSearchButton;

    private System.Windows.Forms.TextBox warehouseSearchTextBox;
    private System.Windows.Forms.TextBox productSearchTextBox;

    private System.Windows.Forms.DataGridView warehousesDataGridView;
    private System.Windows.Forms.DataGridView productsDataGridView;

    #endregion
}