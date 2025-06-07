using Microsoft.EntityFrameworkCore;
using OnlineStore.Repository.Models;

namespace OnlineStore.Repository;

public class OnlineStoreDbContext : DbContext
{
    public DbSet<DatabaseRole> Roles { get; set; }
    
    public DbSet<DatabaseUser> Users { get; set; }
    
    public OnlineStoreDbContext(DbContextOptions<OnlineStoreDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=OnlineStore.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(OnlineStoreDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}