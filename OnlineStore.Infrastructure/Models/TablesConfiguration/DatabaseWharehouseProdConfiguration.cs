using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineStore.Repository.Models.TablesConfiguration;

public class DatabaseWharehouseProdConfiguration : IEntityTypeConfiguration<DatabaseWharehouseProducts>
{
    public void Configure(EntityTypeBuilder<DatabaseWharehouseProducts> builder)
    {
        builder.ToTable("warehouse_products");

        builder.Property(x => x.ProductId)
            .HasColumnName("id");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.ProductId)
            .HasColumnName("product_id")
            .IsRequired();
        
        builder.HasOne(x => x.Product)
            .WithMany(x => x.WhProducts)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.ProductId)
            .HasColumnName("product_id");
        
        builder.HasOne(x => x.Wharehouse)
            .WithMany(x => x.WhProducts)
            .HasForeignKey(x => x.WharehouseId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Property(x => x.ChangedById)
            .HasColumnName("changed_by");
        
        builder.HasOne(x => x.ChangedBy)
            .WithMany()
            .HasForeignKey(x => x.ChangedById)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.Property(x => x.Count)
            .HasColumnName("count");

        builder.Property(x => x.ChangedAt)
            .HasColumnName("changed_at");
    }
}