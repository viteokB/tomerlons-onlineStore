using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Repository.Models;

namespace OnlineStore.Repository.Models.TablesConfiguration;

public class DatabaseWharehouseProdHistoryConfiguration : IEntityTypeConfiguration<DatabaseWharehouseProdHistory>
{
    public void Configure(EntityTypeBuilder<DatabaseWharehouseProdHistory> builder)
    {
        builder.ToTable("warehouse_products_history");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.WarehouseProdId)
            .HasColumnName("warehouse_prod_id")
            .IsRequired();

        builder.HasOne(x => x.WharehouseProducts)
            .WithMany()
            .HasForeignKey(x => x.WarehouseProdId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.WharehouseId)
            .HasColumnName("warehouse_id")
            .IsRequired();

        builder.HasOne(x => x.Wharehouse)
            .WithMany()
            .HasForeignKey(x => x.WharehouseId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.ProductId)
            .HasColumnName("product_id")
            .IsRequired();

        builder.HasOne(x => x.Product)
            .WithMany()
            .HasForeignKey(x => x.ProductId)
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