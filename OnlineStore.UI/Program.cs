using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.UI.DI;
using OnlineStore.UI.Forms;
using Presentation.Common;
using Presentation.NavigationService;
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
        var navigationService = serviceProvider.GetService<INavigationService>();
        navigationService
            .NavigateToMain();
    }
}