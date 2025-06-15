using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Models;
using OnlineStore.Repository.Models;

namespace OnlineStore.Repository;

public sealed class OnlineStoreDbContext : DbContext
{
    public DbSet<DatabaseRole> Roles { get; set; }
    public DbSet<DatabaseUser> Users { get; set; }
    public DbSet<DatabaseType> Types { get; set; }
    public DbSet<DatabaseBrand> Brands { get; set; }
    public DbSet<DatabaseCountry> Countries { get; set; }
    public DbSet<DatabaseProduct> Products { get; set; }
    public DbSet<DatabaseProductHistory> ProductsHistory { get; set; }
    public DbSet<DatabaseWharehouse> Warehouses { get; set; }
    public DbSet<DatabaseWharehouseProducts> WarehousesProducts { get; set; }
    public DbSet<DatabaseWharehouseProdHistory> WarehousesProductsHistory { get; set; }
    public DbSet<DatabaseAddress> Addresses { get; set; }
    public DbSet<DatabaseDeliveryZones> DeliveryZones { get; set; }
    public DbSet<DatabaseDeliveryZonesHistory> DeliveryZonesHistory { get; set; }
    public DbSet<DatabaseOrder> DatabaseOrders { get; set; }
    public DbSet<DatabaseOrderHistory> DatabaseOrderHistory { get; set; }
    
    public OnlineStoreDbContext(DbContextOptions<OnlineStoreDbContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(OnlineStoreDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}