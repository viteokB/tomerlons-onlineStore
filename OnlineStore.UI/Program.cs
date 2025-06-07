using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.UI.DI;
using Presentation.Common;
using Presentation.Presenters;

namespace OnlineStore.UI;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        
        var serviceProvider = ServiceProviderFactory.CreateServiceProvider();
        
        var loginFactoryMethod = serviceProvider.GetService<IPresenterFactoryMethod<LoginPresenter>>();
        
        loginFactoryMethod?.CreatePresenter()
            .Run();
    }
}