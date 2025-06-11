using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineStore.Repository.Models.TablesConfiguration;

public class DatabaseTypesConfiguration : IEntityTypeConfiguration<DatabaseType>
{
    public void Configure(EntityTypeBuilder<DatabaseType> builder)
    {
        builder.ToTable("types");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id");
        
        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnName("description")
            .HasColumnType("varchar(250)")
            .IsRequired();
    }
}