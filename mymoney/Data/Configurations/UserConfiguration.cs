using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mymoney.Models;
using mymoney.Models.Common;

namespace mymoney.Data.Configurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
            
        builder.Property(u => u.Name)
            .HasMaxLength(100)
            .IsRequired();
            
        builder.Property(u => u.CreatedAt)
            .IsRequired();
            
        builder.Property(u => u.UpdatedAt)
            .IsRequired();
            
        builder.Property(u => u.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        // Configure the Emails collection as owned type
        builder.OwnsMany(u => u.Emails, email =>
        {
            email.ToTable("UserEmails");
            
            email.WithOwner().HasForeignKey("UserId");
            
            email.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .IsRequired();
                
            email.HasKey("Id");
            
            // Store the email value directly
            email.Property<string>("Value")
                .HasColumnName("Email")
                .HasMaxLength(256)
                .IsRequired();
        });
            
        builder.HasMany(u => u.Accounts)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}