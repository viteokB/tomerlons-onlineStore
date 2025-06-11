using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineStore.Repository.Models.TablesConfiguration;

public class DatabaseAddressConfiguration : IEntityTypeConfiguration<DatabaseAddress>
{
    public void Configure(EntityTypeBuilder<DatabaseAddress> builder)
    {
        builder.ToTable("address");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id");
        
        builder.Property(x => x.Country)
            .HasColumnName("country")
            .HasColumnType("varchar(100)")
            .IsRequired();
        
        builder.Property(x => x.City)
            .HasColumnName("city")
            .HasColumnType("varchar(100)")
            .IsRequired();
        
        builder.Property(x => x.Street)
            .HasColumnName("street")
            .HasColumnType("varchar(100)")
            .IsRequired();
        
        builder.Property(x => x.HouseNumber)
            .HasColumnName("house_number")
            .HasColumnType("varchar(10)")
            .IsRequired();
        
        builder.Property(x => x.ApartmentNumber)
            .HasColumnName("apartment_number")
            .HasColumnType("varchar(10)")
            .IsRequired(false);
        
        builder.Property(x => x.Coordinate)
            .HasColumnName("coordinate")
            .HasSrid(4326)
            .IsRequired();

        builder.HasMany(x => x.Wharehouses)
            .WithOne(x => x.Address)
            .OnDelete(DeleteBehavior.NoAction);
    }
}