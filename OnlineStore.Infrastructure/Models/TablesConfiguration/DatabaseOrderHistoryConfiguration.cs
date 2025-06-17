using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Repository.Models;

namespace OnlineStore.Repository.Models.TablesConfiguration;

public class DatabaseOrderHistoryConfiguration : IEntityTypeConfiguration<DatabaseOrderHistory>
{
    public void Configure(EntityTypeBuilder<DatabaseOrderHistory> builder)
    {
        builder.ToTable("order_history");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.OrderId)
            .HasColumnName("order_id")
            .IsRequired();

        builder.HasOne(x => x.Order)
            .WithMany()
            .HasForeignKey(x => x.OrderId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.UserId)
            .HasColumnName("user_id")
            .IsRequired(false);

        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Property(x => x.DeliveryAddressId)
            .HasColumnName("delivery_address_id")
            .IsRequired();

        builder.HasOne(x => x.DeliveryAddress)
            .WithMany()
            .HasForeignKey(x => x.DeliveryAddressId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.DeliveryStatusId)
            .HasColumnName("delivery_status_id")
            .IsRequired();

        builder.HasOne(x => x.DeliveryStatus)
            .WithMany()
            .HasForeignKey(x => x.DeliveryStatusId)
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

        builder.Property(x => x.WharehouseId)
            .HasColumnName("warehouse_id")
            .IsRequired();

        builder.HasOne(x => x.Wharehouse)
            .WithMany()
            .HasForeignKey(x => x.WharehouseId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.ChangedById)
            .HasColumnName("changed_by")
            .IsRequired(false);

        builder.HasOne(x => x.ChangedByUser)
            .WithMany()
            .HasForeignKey(x => x.ChangedById)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Property(x => x.Count)
            .HasColumnName("count")
            .IsRequired();

        builder.Property(x => x.ProductPrice)
            .HasColumnName("product_price")
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.DeliveryPrice)
            .HasColumnName("delivery_price")
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.DeliveryDays)
            .HasColumnName("delivery_days")
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnName("description")
            .HasColumnType("nvarchar(500)")
            .IsRequired(false);

        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired();
    }
}