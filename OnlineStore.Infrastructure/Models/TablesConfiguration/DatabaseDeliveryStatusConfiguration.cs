using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineStore.Repository.Models.TablesConfiguration;

public class DatabaseDeliveryStatusConfiguration : IEntityTypeConfiguration<DatabaseDeliveryStatus>
{
    public void Configure(EntityTypeBuilder<DatabaseDeliveryStatus> builder)
    {
        builder.ToTable("delivery_status");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(20)")
            .IsRequired();
    }
}