﻿using OnlineStore.Core;
using OnlineStore.Core.Models;
using Presentation.Views;

namespace OnlineStore.UI.Forms;

public partial class MainForm : Form, IMainView
{
    private readonly ApplicationContext _applicationContext;
    
    public MainForm(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
        InitializeComponent();
    }

    public new void Show()
    {
        _applicationContext.MainForm = this;
        Application.Run(_applicationContext);
    }

    public event Action? OpenModalLoginDialog;
    public event Action? OpenModalRegisterDialog;
    public event Action? OpenModalAuthorDialog;
    
    public event Action? OpenTypesRedactorDialog;
    
    public event Action? OpenCountryRedactorDialog;
    
    public event Action? OpenBrandRedactorDialog;
    
    public event Action? OpenProductRedactorDialog;
    
    public event Action? OpenWarehouseRedactorDialog;
    
    public event Action? OpenUserCartDialog;
    
    public event Action? OpenAdminOrdersDialog;
    
    public event Action? OpenProducts;
    
    public event Action? OpenStatistics;

    public User User { get; set; }

    public void ShowError(string message)
    {
        MessageBox.Show(this, message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public void ShowMessage(string message)
    {
        MessageBox.Show(this, message, @"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void button1_Click(object sender, EventArgs e)
    {
        OpenModalLoginDialog?.Invoke();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        OpenModalRegisterDialog?.Invoke();
    }

    private void button3_Click(object sender, EventArgs e)
    {
        OpenModalAuthorDialog?.Invoke();
    }

    private void button4_Click(object sender, EventArgs e)
    {
        OpenTypesRedactorDialog?.Invoke();
    }

    private void button5_Click(object sender, EventArgs e)
    {
        OpenCountryRedactorDialog?.Invoke();
    }

    private void button6_Click(object sender, EventArgs e)
    {
        OpenBrandRedactorDialog?.Invoke();
    }

    private void button7_Click(object sender, EventArgs e)
    {
        OpenProductRedactorDialog?.Invoke();
    }
    
    private void button8_Click(object sender, EventArgs e)
    {
        OpenStatistics?.Invoke();
    }

    private void warehouseDialog_Click(object sender, EventArgs e)
    {
        OpenWarehouseRedactorDialog?.Invoke();
    }

    private void btnUserCart_Click(object sender, EventArgs e)
    {
        OpenUserCartDialog?.Invoke();
    }

    private void btnAdminOrders_Click(object sender, EventArgs e)
    {
        OpenAdminOrdersDialog?.Invoke();
    }

    private void btnProductForm_Click(object sender, EventArgs e)
    {
        OpenProducts?.Invoke();
    }
}