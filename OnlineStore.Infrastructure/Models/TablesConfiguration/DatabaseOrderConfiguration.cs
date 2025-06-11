using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineStore.Repository.Models.TablesConfiguration;

public class DatabaseOrderConfiguration : IEntityTypeConfiguration<DatabaseOrder>
{
    public void Configure(EntityTypeBuilder<DatabaseOrder> builder)
    {
        builder.ToTable("order");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id");
        
        builder.Property(x => x.UserId)
            .HasColumnName("user_id");
        
        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.Property(x => x.DeliveryAddressId)
            .HasColumnName("delivery_address_id");
        
        builder.HasOne(x => x.DeliveryAddress)
            .WithMany()
            .HasForeignKey(x => x.DeliveryAddressId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(x => x.DeliveryStatusId)
            .HasColumnName("delivery_status_id");
        
        builder.HasOne(x => x.DeliveryStatus)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.DeliveryStatusId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(x => x.ProductId)
            .HasColumnName("product_id");
        
        builder.HasOne(x => x.Product)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(x => x.WharehouseId)
            .HasColumnName("wharehouse_id");
        
        builder.HasOne(x => x.Wharehouse)
            .WithMany(x => x.WhOrders)
            .HasForeignKey(x => x.WharehouseId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(x => x.ChangedById)
            .HasColumnName("changed_by");
        
        builder.HasOne(x => x.ChangedByUser)
            .WithMany()
            .HasForeignKey(x => x.ChangedById)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.Property(x => x.Count)
            .HasColumnName("count");
        
        builder.Property(x => x.ProductPrice)
            .HasColumnName("product_price");
        
        builder.Property(x => x.DeliveryPrice)
            .HasColumnName("delivery_price");
        
        builder.Property(x => x.DeliveryDays)
            .HasColumnName("delivery_days");
        
        builder.Property(x => x.Description)
            .HasColumnName("description");
        
        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at");
        
        builder.Property(x => x.UpdatedAt)
            .HasColumnName("updated_at");
    }
}