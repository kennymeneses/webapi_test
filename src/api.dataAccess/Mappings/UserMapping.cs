using api.dataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.dataAccess.Mappings;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users", "dbo");
        builder.HasKey(user => user.Id).HasName("PK_Users");
        
        builder.Property(user => user.Id).HasColumnType("uuid").HasColumnName("id");
        builder.Property(user => user.FirstName).HasColumnType("character varying").HasColumnName("first_name");
        builder.Property(user => user.LastName).HasColumnType("character varying").HasColumnName("last_name");
        builder.Property(user => user.Email).HasColumnType("character varying").HasColumnName("email");
        builder.Property(user => user.Gender).HasConversion<int>().HasColumnName("gender");
        builder.Property(user => user.Type).HasConversion<int>().HasColumnName("type");
        builder.Property(user => user.BirthDate).HasColumnType("date").HasColumnName("birthdate");
        
        builder.Property(user => user.CreatedBy).HasColumnName("created_by")
            .HasMaxLength(36)
            .IsFixedLength();
        builder.Property(user => user.CreatedTime)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("created_time");
        builder.Property(user => user.ModifiedBy)
            .HasMaxLength(36)
            .IsFixedLength()
            .HasColumnName("modified_by");
        builder.Property(user => user.LastModifiedTime)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("last_modified_time");
        
        builder.Property(user => user.Deleted).HasColumnName("deleted").HasDefaultValue(false);
    }
}