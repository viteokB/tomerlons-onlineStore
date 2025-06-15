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
        productSearchTextBox.Location = new System.Drawing.Point(450, 18);
        productSearchTextBox.Name = "productSearchTextBox";
        productSearchTextBox.Size = new System.Drawing.Size(240, 27);
        productSearchTextBox.TabIndex = 3;
        // 
        // warehouseSearchButton
        // 
        warehouseSearchButton.Location = new System.Drawing.Point(294, 18);
        warehouseSearchButton.Name = "warehouseSearchButton";
        warehouseSearchButton.Size = new System.Drawing.Size(100, 41);
        warehouseSearchButton.TabIndex = 4;
        warehouseSearchButton.Text = "Wh search";
        warehouseSearchButton.UseVisualStyleBackColor = true;
        // 
        // productSearchButton
        // 
        productSearchButton.Location = new System.Drawing.Point(717, 11);
        productSearchButton.Name = "productSearchButton";
        productSearchButton.Size = new System.Drawing.Size(100, 41);
        productSearchButton.TabIndex = 5;
        productSearchButton.Text = "pr search";
        productSearchButton.UseVisualStyleBackColor = true;
        // 
        // warehouseNameTextBox
        // 
        warehouseNameTextBox.Location = new System.Drawing.Point(32, 358);
        warehouseNameTextBox.Name = "warehouseNameTextBox";
        warehouseNameTextBox.Size = new System.Drawing.Size(150, 27);
        warehouseNameTextBox.TabIndex = 6;
        // 
        // isActiveCheckBox
        // 
        isActiveCheckBox.Location = new System.Drawing.Point(32, 415);
        isActiveCheckBox.Name = "isActiveCheckBox";
        isActiveCheckBox.Size = new System.Drawing.Size(150, 24);
        isActiveCheckBox.TabIndex = 7;
        isActiveCheckBox.Text = "isActiveCheckBox";
        isActiveCheckBox.UseVisualStyleBackColor = true;
        // 
        // productCountNumeric
        // 
        productCountNumeric.Location = new System.Drawing.Point(697, 395);
        productCountNumeric.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        productCountNumeric.Name = "productCountNumeric";
        productCountNumeric.Size = new System.Drawing.Size(120, 27);
        productCountNumeric.TabIndex = 12;
        // 
        // btnUpdateWarehouse
        // 
        btnUpdateWarehouse.Location = new System.Drawing.Point(319, 735);
        btnUpdateWarehouse.Name = "btnUpdateWarehouse";
        btnUpdateWarehouse.Size = new System.Drawing.Size(75, 48);
        btnUpdateWarehouse.TabIndex = 13;
        btnUpdateWarehouse.Text = "up button";
        btnUpdateWarehouse.UseVisualStyleBackColor = true;
        // 
        // updateProductCountButton
        // 
        updateProductCountButton.Location = new System.Drawing.Point(742, 541);
        updateProductCountButton.Name = "updateProductCountButton";
        updateProductCountButton.Size = new System.Drawing.Size(75, 48);
        updateProductCountButton.TabIndex = 14;
        updateProductCountButton.Text = "up warehouse";
        updateProductCountButton.UseVisualStyleBackColor = true;
        // 
        // countryTextBox
        // 
        countryTextBox.Location = new System.Drawing.Point(213, 358);
        countryTextBox.Name = "countryTextBox";
        countryTextBox.Size = new System.Drawing.Size(181, 27);
        countryTextBox.TabIndex = 15;
        // 
        // cityTextBox
        // 
        cityTextBox.Location = new System.Drawing.Point(213, 415);
        cityTextBox.Name = "cityTextBox";
        cityTextBox.Size = new System.Drawing.Size(181, 27);
        cityTextBox.TabIndex = 16;
        // 
        // streetTextBox
        // 
        streetTextBox.Location = new System.Drawing.Point(213, 469);
        streetTextBox.Name = "streetTextBox";
        streetTextBox.Size = new System.Drawing.Size(181, 27);
        streetTextBox.TabIndex = 17;
        // 
        // houseNumberTextBox
        // 
        houseNumberTextBox.Location = new System.Drawing.Point(213, 528);
        houseNumberTextBox.Name = "houseNumberTextBox";
        houseNumberTextBox.Size = new System.Drawing.Size(181, 27);
        houseNumberTextBox.TabIndex = 18;
        // 
        // apartmentTextBox
        // 
        apartmentTextBox.Location = new System.Drawing.Point(213, 580);
        apartmentTextBox.Name = "apartmentTextBox";
        apartmentTextBox.Size = new System.Drawing.Size(181, 27);
        apartmentTextBox.TabIndex = 22;
        // 
        // coordinateLatitudeNumeric
        // 
        coordinateLatitudeNumeric.Location = new System.Drawing.Point(274, 631);
        coordinateLatitudeNumeric.Name = "coordinateLatitudeNumeric";
        coordinateLatitudeNumeric.Size = new System.Drawing.Size(120, 27);
        coordinateLatitudeNumeric.TabIndex = 23;
        // 
        // coordinateLongitudeNumeric
        // 
        coordinateLongitudeNumeric.Location = new System.Drawing.Point(274, 682);
        coordinateLongitudeNumeric.Name = "coordinateLongitudeNumeric";
        coordinateLongitudeNumeric.Size = new System.Drawing.Size(120, 27);
        coordinateLongitudeNumeric.TabIndex = 24;
        // 
        // btnAddWarehouse
        // 
        btnAddWarehouse.Location = new System.Drawing.Point(223, 735);
        btnAddWarehouse.Name = "btnAddWarehouse";
        btnAddWarehouse.Size = new System.Drawing.Size(75, 48);
        btnAddWarehouse.TabIndex = 28;
        btnAddWarehouse.Text = "add warehouse";
        btnAddWarehouse.UseVisualStyleBackColor = true;
        // 
        // btnDeleteWarehouse
        // 
        btnDeleteWarehouse.Location = new System.Drawing.Point(126, 735);
        btnDeleteWarehouse.Name = "btnDeleteWarehouse";
        btnDeleteWarehouse.Size = new System.Drawing.Size(75, 48);
        btnDeleteWarehouse.TabIndex = 29;
        btnDeleteWarehouse.Text = "del warehouse";
        btnDeleteWarehouse.UseVisualStyleBackColor = true;
        // 
        // WarehouseEditorForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(922, 809);
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