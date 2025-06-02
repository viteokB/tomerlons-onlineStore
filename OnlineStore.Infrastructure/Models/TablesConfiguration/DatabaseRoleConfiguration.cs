using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineStore.Repository.Models.TablesConfiguration;

public class DatabaseRoleConfiguration : IEntityTypeConfiguration<DatabaseRole>
{
    public void Configure(EntityTypeBuilder<DatabaseRole> builder)
    {
        builder.ToTable("roles");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(50)")
            .IsRequired();
        
        builder.HasIndex(x => x.Name)
            .HasDatabaseName("ix_role_name");
        
        builder.HasMany(x => x.Users)
            .WithOne(x => x.Role)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}