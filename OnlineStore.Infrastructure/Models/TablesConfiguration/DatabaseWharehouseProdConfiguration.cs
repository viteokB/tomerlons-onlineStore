using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineStore.Repository.Models.TablesConfiguration;

public class DatabaseWharehouseProdConfiguration : IEntityTypeConfiguration<DatabaseWharehouseProducts>
{
    public void Configure(EntityTypeBuilder<DatabaseWharehouseProducts> builder)
    {
        builder.ToTable("warehouse_products");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder.Property(x => x.ProductId)
            .HasColumnName("product_id")
            .IsRequired();
        
        builder.HasOne(x => x.Product)
            .WithMany(x => x.WhProducts)
            .HasForeignKey(x => x.ProductId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.WharehouseId)
            .HasColumnName("warehouse_id")
            .IsRequired();
        
        builder.HasOne(x => x.Wharehouse)
            .WithMany(x => x.WhProducts)
            .HasForeignKey(x => x.WharehouseId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.Property(x => x.ChangedById)
            .HasColumnName("changed_by")
            .IsRequired(false);
        
        builder.HasOne(x => x.ChangedBy)
            .WithMany()
            .HasForeignKey(x => x.ChangedById)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.Property(x => x.Count)
            .HasColumnName("count")
            .IsRequired();

        builder.Property(x => x.ChangedAt)
            .HasColumnName("changed_at")
            .IsRequired();
    }
}