using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Repository;
using OnlineStore.Services.Login;
using OnlineStore.UI.Forms;
using Presentation.Common;
using Presentation.PresenterFactoryMethods;
using Presentation.Presenters;
using Presentation.Views;

namespace OnlineStore.UI.DI;

public static class ServiceProviderFactory
{
    public static IServiceProvider CreateServiceProvider()
    {
        var services = new ServiceCollection();
        var config = ConfigurationBuilder.Build();
        services.AddSingleton<IConfiguration>(config);
        
        // Adding ApplicationContext
        services.AddSingleton<ApplicationContext>();
        
        // Registration of different layers
        services.RegisterInfrastructure(config);
        services.RegisterServices(config);
        services.RegisterPresentation(config);
        
        return services.BuildServiceProvider();
    }

    private static void RegisterInfrastructure(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);
    }
    
    private static void RegisterServices(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddScoped<IUserService, UserService>();
    }
    
    private static void RegisterPresentation(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        // Views
        services.AddScoped<ILoginView, LoginForm>();
        services.AddScoped<IMainView, MainForm>();

        // Presenters походу не надо
        
        // PresenterFactoryMethods
        services.AddSingleton<IPresenterFactoryMethod<LoginPresenter>, LoginPresenterFactoryMethod>();
        services.AddSingleton<IPresenterFactoryMethod<MainPresenter>, MainPresenterFactoryMethod>();
    }
}