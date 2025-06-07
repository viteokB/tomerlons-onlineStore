using Microsoft.EntityFrameworkCore;
using OnlineStore.Repository.Models;

namespace OnlineStore.Repository;

public sealed class OnlineStoreDbContext : DbContext
{
    public DbSet<DatabaseRole> Roles { get; set; }
    
    public DbSet<DatabaseUser> Users { get; set; }
    
    public OnlineStoreDbContext(DbContextOptions<OnlineStoreDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(OnlineStoreDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}