using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineStore.Repository.Models.TablesConfiguration;

public class DatabaseProductHistoryConfiguration : IEntityTypeConfiguration<DatabaseProductHistory>
{
    public void Configure(EntityTypeBuilder<DatabaseProductHistory> builder)
    {
        builder.ToTable("products_history");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.ProductId)
            .HasColumnName("product_id")
            .IsRequired();

        builder.HasOne(x => x.Product)
            .WithMany(x => x.ProductHistories)
            .HasForeignKey(x => x.ProductId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.TypeId)
            .HasColumnName("type_id")
            .IsRequired(false);
                
        builder.HasOne(x => x.Type)
            .WithMany()
            .HasForeignKey(x => x.TypeId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.Property(x => x.CountryId)
            .HasColumnName("country_id")
            .IsRequired(false);
        
        builder.HasOne(x => x.Country)
            .WithMany()
            .HasForeignKey(x => x.CountryId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.Property(x => x.ChangedById)
            .HasColumnName("changed_by")
            .IsRequired(false);
        
        builder.HasOne(x => x.ChangedBy)
            .WithMany()
            .HasForeignKey(x => x.ChangedById)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.Property(x => x.BrandId)
            .HasColumnName("brand_id")
            .IsRequired(false);
        
        builder.HasOne(x => x.Brand)
            .WithMany()
            .HasForeignKey(x => x.BrandId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(x => x.PhotoPath)
            .HasColumnName("photo_path")
            .HasMaxLength(150)
            .IsRequired(false);
        
        builder.Property(x => x.CatalogNumber)
            .HasColumnName("catalog_number")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(x => x.BasePrice)
            .HasColumnName("base_price")
            .IsRequired();
        
        builder.Property(x => x.IsActive)
            .HasColumnName("is_active")
            .IsRequired();
        
        builder.Property(x => x.ChangedAt)
            .HasColumnName("changed_at")
            .IsRequired();
    }
}