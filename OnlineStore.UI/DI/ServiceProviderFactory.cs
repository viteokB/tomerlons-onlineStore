using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Repository;
using OnlineStore.Services.DeliveryService;
using OnlineStore.Services.HistoryService;
using OnlineStore.Services.Login;
using OnlineStore.Services.Orders;
using OnlineStore.Services.Products;
using OnlineStore.Services.WarehouseService;
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
        services.AddScoped<IWarehouseService, WarehouseService>();
        services.AddScoped<IDeliveryService, DeliveryService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IHistoryService, HistoryService>();
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
        services.AddTransient<ICountryRedactorView, CountryRedactorForm>();
        services.AddTransient<IBrandRedactorView, BrandRedactorForm>();
        services.AddTransient<IAddProductView, ProductRedactorForm>();
        services.AddTransient<IWarehouseEditorView, WarehouseEditorForm>();
        services.AddTransient<IUserCartView, UserCartForm>();
        services.AddTransient<IAdminOrdersView, AdminOrdersForm>();
        services.AddTransient<IProductView, ProductForm>();
        services.AddTransient<IPurchaseView, PurchaseForm>();
        services.AddTransient<IProductStatisticsView, StatisticForm>();

        // Регистрация Presenters
        services.AddTransient<LoginPresenter>();
        services.AddTransient<RegisterPresenter>();
        services.AddTransient<MainPresenter>();
        services.AddTransient<AuthorPresenter>();
        services.AddTransient<TypeCrudPresenter>();
        services.AddTransient<CountryCrudPresenter>();
        services.AddTransient<BrandCrudPresenter>();
        services.AddTransient<AddProductPresenter>();
        services.AddTransient<WarehouseEditorPresenter>();
        services.AddTransient<UserCartPresenter>();
        services.AddTransient<AdminOrdersPresenter>();
        services.AddTransient<ProductPresenter>();
        services.AddTransient<PurchasePresenter>();
        services.AddTransient<ProductStatisticsPresenter>();

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
        
        services.AddTransient<Func<CountryCrudPresenter>>(provider =>
            provider.GetRequiredService<CountryCrudPresenter>);
        
        services.AddTransient<Func<BrandCrudPresenter>>(provider =>
            provider.GetRequiredService<BrandCrudPresenter>);
        
        services.AddTransient<Func<AddProductPresenter>>(provider =>
            provider.GetRequiredService<AddProductPresenter>);
        
        services.AddTransient<Func<WarehouseEditorPresenter>>(provider =>
            provider.GetRequiredService<WarehouseEditorPresenter>);
        
        services.AddTransient<Func<UserCartPresenter>>(provider =>
            provider.GetRequiredService<UserCartPresenter>);
        
        services.AddTransient<Func<AdminOrdersPresenter>>(provider =>
            provider.GetRequiredService<AdminOrdersPresenter>);
        
        services.AddTransient<Func<ProductPresenter>>(provider =>
            provider.GetRequiredService<ProductPresenter>);
        
        services.AddTransient<Func<PurchasePresenter>>(provider =>
            provider.GetRequiredService<PurchasePresenter>);

        services.AddTransient<Func<ProductStatisticsPresenter>>(provider =>
            provider.GetRequiredService<ProductStatisticsPresenter>);
    }
}