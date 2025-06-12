using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Repository;
using OnlineStore.Services.Login;
using OnlineStore.Services.Products;
using OnlineStore.UI.Forms;
using Presentation.NavigationService;
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
        services.AddScoped<IProductService, ProductService>();
    }
    
    private static void RegisterPresentation(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddSingleton<INavigationService, NavigationService>();
    
        // Регистрация View
        services.AddTransient<ILoginView, LoginForm>();
        services.AddTransient<IMainView, MainForm>();
        services.AddTransient<IRegisterView, RegisterForm>();
        services.AddTransient<IAuthorView, AuthorForm>();
        services.AddTransient<ITypeRedactorView, TypeRedactorForm>();
        
        // Регистрация Presenters
        services.AddTransient<LoginPresenter>();
        services.AddTransient<RegisterPresenter>();
        services.AddTransient<MainPresenter>();
        services.AddTransient<AuthorPresenter>();
        services.AddTransient<TypeCrudPresenter>();
        
        // Регистрация фабрик презентеров
        services.AddTransient<Func<LoginPresenter>>(provider => 
            provider.GetRequiredService<LoginPresenter>);

        services.AddTransient<Func<RegisterPresenter>>(provider => 
            provider.GetRequiredService<RegisterPresenter>);

        services.AddTransient<Func<MainPresenter>>(provider => 
            provider.GetRequiredService<MainPresenter>);

        services.AddTransient<Func<AuthorPresenter>>(provider =>
            provider.GetRequiredService<AuthorPresenter>);
        
        services.AddTransient<Func<TypeCrudPresenter>>(provider =>
            provider.GetRequiredService<TypeCrudPresenter>);
    }
}