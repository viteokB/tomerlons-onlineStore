using Microsoft.EntityFrameworkCore;
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
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}