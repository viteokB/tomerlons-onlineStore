using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Models.WhareHouse;

namespace OnlineStore.Repository.Models.TablesConfiguration;

public class DatabaseWarehouseConfiguration : IEntityTypeConfiguration<DatabaseWharehouse>
{
    public void Configure(EntityTypeBuilder<DatabaseWharehouse> builder)
    {
        builder.ToTable("wharehouse");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id");
        
        builder.Property(x => x.AddressId)
            .HasColumnName("address_id");
        
        builder.HasOne(w => w.Address)
            .WithMany(a => a.Wharehouses)
            .HasForeignKey(w => w.AddressId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(100)")
            .IsRequired();
    }
}