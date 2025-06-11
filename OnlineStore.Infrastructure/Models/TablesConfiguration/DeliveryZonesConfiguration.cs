using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineStore.Repository.Models.TablesConfiguration;

public class DeliveryZonesConfiguration : IEntityTypeConfiguration<DatabaseDeliveryZones>
{
    public void Configure(EntityTypeBuilder<DatabaseDeliveryZones> builder)
    {
        builder.ToTable("delivery_zones");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.WharehouseId)
            .HasColumnName("wharehouse_id");
        
        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(100)")
            .IsRequired();
        
        builder.Property(x => x.MinDistance)
            .HasColumnName("min_distance")
            .IsRequired();
        
        builder.Property(x => x.MaxDistance)
            .HasColumnName("max_distance")
            .IsRequired();

        builder.Property(x => x.DeliveryPrice)
            .HasColumnName("delivery_price")
            .IsRequired();
        
        builder.Property(x => x.DeliveryDays)
            .HasColumnName("delivery_days")
            .IsRequired();
    }
}