using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Core.Interfaces;
using OnlineStore.Repository.Repository;

namespace OnlineStore.Repository;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var dbConnectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new NullReferenceException("Default connection string is null");

        services.AddDbContext<OnlineStoreDbContext>(options =>
        {
            options.UseSqlite(dbConnectionString);
        });
        
        // repositories registration
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        // services.AddScoped<IOrderRepository>();
        services.AddScoped<IProductsRepository, ProductsRepository>();
        services.AddScoped<ITypeRepository, TypeRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IWarehouseRepository, WarehouseRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();

        return services;
    }
}