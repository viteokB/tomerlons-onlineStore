using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineStore.Repository.Models.TablesConfiguration;

public class DatabaseBrandsConfiguration : IEntityTypeConfiguration<DatabaseBrand>
{
    public void Configure(EntityTypeBuilder<DatabaseBrand> builder)
    {
        builder.ToTable("brands");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.HasIndex(x => x.Name)
            .HasDatabaseName("ix_brands_name");
        
        builder.HasOne(x => x.Country)
            .WithMany(x => x.Brands)
            .HasForeignKey(x => x.CountryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}