using api.dataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.dataAccess.Mappings;

public class UserPasswordMapping: IEntityTypeConfiguration<UserPassword>
{
    public void Configure(EntityTypeBuilder<UserPassword> builder)
    {
        builder.ToTable("user_passwords", "dbo");
        builder.HasKey(userPassword => userPassword.Id).HasName("PK_User_Passwords");
        
        builder.Property(userPassword => userPassword.Id).HasColumnType("uuid").HasColumnName("id");
        builder.Property(userPassword => userPassword.UserId).HasColumnType("uuid").HasColumnName("user_id");
        builder.Property(userPassword => userPassword.Password).HasColumnType("character varying").HasColumnName("password");
        
        builder.Property(userPassword => userPassword.CreatedBy).HasColumnName("created_by")
            .HasMaxLength(36)
            .IsFixedLength();
        builder.Property(userPassword => userPassword.CreatedTime)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("created_time");
        builder.Property(userPassword => userPassword.ModifiedBy)
            .HasMaxLength(36)
            .IsFixedLength()
            .HasColumnName("modified_by");
        builder.Property(userPassword => userPassword.LastModifiedTime)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("last_modified_time");
        
        builder.Property(userPassword => userPassword.Deleted).HasColumnName("deleted").HasDefaultValue(false);
    }
}