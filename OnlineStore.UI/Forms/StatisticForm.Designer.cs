﻿using System.ComponentModel;

namespace OnlineStore.UI.Forms;

partial class StatisticForm
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
        btnApplyFilter = new Button();
        dtpStartDate = new DateTimePicker();
        dtpEndDate = new DateTimePicker();
        priceHistoryChart = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
        warehouseHistoryChart = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
        label1 = new Label();
        label2 = new Label();
        productsComboBox = new ComboBox();
        label3 = new Label();
        SuspendLayout();
        // 
        // btnApplyFilter
        // 
        btnApplyFilter.Location = new Point(451, 12);
        btnApplyFilter.Name = "btnApplyFilter";
        btnApplyFilter.Size = new Size(191, 71);
        btnApplyFilter.TabIndex = 0;
        btnApplyFilter.Text = "применить фильтр";
        btnApplyFilter.UseVisualStyleBackColor = true;
        // 
        // dtpStartDate
        // 
        dtpStartDate.Location = new Point(12, 12);
        dtpStartDate.Name = "dtpStartDate";
        dtpStartDate.Size = new Size(187, 27);
        dtpStartDate.TabIndex = 1;
        // 
        // dtpEndDate
        // 
        dtpEndDate.Location = new Point(218, 12);
        dtpEndDate.Name = "dtpEndDate";
        dtpEndDate.Size = new Size(203, 27);
        dtpEndDate.TabIndex = 2;
        // 
        // priceHistoryChart
        // 
        priceHistoryChart.Location = new Point(26, 128);
        priceHistoryChart.MatchAxesScreenDataRatio = false;
        priceHistoryChart.Name = "priceHistoryChart";
        priceHistoryChart.Size = new Size(616, 238);
        priceHistoryChart.TabIndex = 3;
        // 
        // warehouseHistoryChart
        // 
        warehouseHistoryChart.Location = new Point(26, 425);
        warehouseHistoryChart.MatchAxesScreenDataRatio = false;
        warehouseHistoryChart.Name = "warehouseHistoryChart";
        warehouseHistoryChart.Size = new Size(635, 224);
        warehouseHistoryChart.TabIndex = 4;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(241, 105);
        label1.Name = "label1";
        label1.Size = new Size(197, 20);
        label1.TabIndex = 6;
        label1.Text = "Изменение цены продукта";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(218, 369);
        label2.Name = "label2";
        label2.Size = new Size(242, 20);
        label2.TabIndex = 7;
        label2.Text = "Изменение количества на складе";
        // 
        // productsComboBox
        // 
        productsComboBox.FormattingEnabled = true;
        productsComboBox.Location = new Point(176, 55);
        productsComboBox.Name = "productsComboBox";
        productsComboBox.Size = new Size(245, 28);
        productsComboBox.TabIndex = 8;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(101, 58);
        label3.Name = "label3";
        label3.Size = new Size(69, 20);
        label3.TabIndex = 9;
        label3.Text = "Продукт:";
        // 
        // StatisticForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(680, 661);
        Controls.Add(label3);
        Controls.Add(productsComboBox);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(warehouseHistoryChart);
        Controls.Add(priceHistoryChart);
        Controls.Add(dtpEndDate);
        Controls.Add(dtpStartDate);
        Controls.Add(btnApplyFilter);
        Name = "StatisticForm";
        Text = "StatisticForm";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button btnApplyFilter;
    private DateTimePicker dtpStartDate;
    private DateTimePicker dtpEndDate;
    private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart priceHistoryChart;
    private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart warehouseHistoryChart;
    private Label label1;
    private Label label2;
    private ComboBox productsComboBox;
    private Label label3;
}