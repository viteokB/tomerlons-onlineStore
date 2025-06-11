using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineStore.Repository.Models.TablesConfiguration;

public class DatabaseCountryConfiguration : IEntityTypeConfiguration<DatabaseCountry>
{
    public void Configure(EntityTypeBuilder<DatabaseCountry> builder)
    {
        builder.ToTable("country");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.HasIndex(x => x.Name)
            .HasDatabaseName("ix_country_name");

        builder.Property(x => x.Code)
            .HasColumnName("code")
            .HasColumnType("varchar(3)")
            .IsRequired();
    }
}