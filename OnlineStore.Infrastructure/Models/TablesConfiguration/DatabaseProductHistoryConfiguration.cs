using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineStore.Repository.Models.TablesConfiguration;

public class DatabaseProductHistoryConfiguration : IEntityTypeConfiguration<DatabaseProductHistory>
{
    public void Configure(EntityTypeBuilder<DatabaseProductHistory> builder)
    {
        builder.ToTable("products_history");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.ProductId)
            .HasColumnName("product_history_id");

        builder.Property(x => x.TypeId)
            .HasColumnType("type_id");
                
        builder.HasOne(x => x.Type)
            .WithMany()
            .HasForeignKey(x => x.TypeId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.Property(x => x.ProductId)
            .HasColumnType("product_id");

        builder.HasOne(x => x.Product)
            .WithMany(x => x.ProductHistories)
            .HasForeignKey(x => x.ProductId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.Property(x => x.CountryId)
            .HasColumnType("country_id");
        
        builder.HasOne(x => x.Country)
            .WithMany()
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
            .WithMany()
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