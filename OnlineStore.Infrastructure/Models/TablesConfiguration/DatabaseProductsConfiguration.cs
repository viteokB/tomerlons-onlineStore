using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineStore.Repository.Models.TablesConfiguration;

public class DatabaseProductsConfiguration : IEntityTypeConfiguration<DatabaseProduct>
{
    public void Configure(EntityTypeBuilder<DatabaseProduct> builder)
    {
        builder.ToTable("products");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.TypeId)
            .HasColumnType("type_id");
        
        builder.HasOne(x => x.Type)
            .WithMany(t => t.Products)
            .HasForeignKey(x => x.TypeId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.Property(x => x.CountryId)
            .HasColumnType("country_id");
        
        builder.HasOne(x => x.Country)
            .WithMany(c => c.Products)
            .HasForeignKey(x => x.CountryId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.Property(x => x.ChangedById)
            .HasColumnType("changed_by");
        
        builder.HasOne(x => x.ChangedBy)
            .WithMany()
            .HasForeignKey(x => x.ChangedById)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.Property(x => x.BrandId)
            .HasColumnType("brand_id");
        
        builder.HasOne(x => x.Brand)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.BrandId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Property(x => x.Name)
            .HasColumnType("name")
            .HasColumnType("nvarchar(100)")
            .IsRequired();
        
        builder.Property(x => x.PhotoPath)
            .HasColumnType("photo_path")
            .HasColumnType("nvarchar(150)")
            .IsRequired(false);
        
        builder.Property(x => x.CatalogNumber)
            .HasColumnType("catalog_number")
            .HasColumnType("nvarchar(100)")
            .IsRequired();
        
        builder.Property(x => x.BasePrice)
            .HasColumnType("base_price")
            .IsRequired();
        
        builder.Property(x => x.IsActive)
            .HasColumnType("is_active")
            .IsRequired();
        
        builder.Property(x => x.ChangedAt)
            .HasColumnType("changed_at")
            .IsRequired();
    }
}