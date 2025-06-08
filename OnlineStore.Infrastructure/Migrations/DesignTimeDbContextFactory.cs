using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace OnlineStore.Repository.Migrations;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OnlineStoreDbContext>
{
    public OnlineStoreDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<OnlineStoreDbContext>();
        optionsBuilder.UseSqlite("Data Source=OnlineStore.db");

        return new OnlineStoreDbContext(optionsBuilder.Options);
    }
}