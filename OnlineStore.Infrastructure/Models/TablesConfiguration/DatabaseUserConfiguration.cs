using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineStore.Repository.Models.TablesConfiguration;

public class DatabaseUserConfiguration : IEntityTypeConfiguration<DatabaseUser>
{
    public void Configure(EntityTypeBuilder<DatabaseUser> builder)
    {
        builder.ToTable("users");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnName("id");
        
        builder.Property(x => x.RoleId)
            .HasColumnName("role_id")
            .IsRequired();

        builder.Property(x => x.Email)
            .HasColumnName("email")
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.Property(x => x.HashedPassword)
            .HasColumnName("hashed_password")
            .HasColumnType("varchar(64)")
            .IsRequired();
        
        builder.HasIndex(x => x.Email)
            .HasDatabaseName("ix_user_email")
            .IsUnique();

        builder.HasIndex(x => x.HashedPassword)
            .HasDatabaseName("ix_hashed_password");
        
        builder.HasOne(x => x.Role)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}