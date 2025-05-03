using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mymoney.Models;

namespace mymoney.Data.Configurations;

public sealed class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Name)
            .HasMaxLength(100)
            .IsRequired();
            
        builder.Property(a => a.Description)
            .HasMaxLength(500);
            
        builder.Property(a => a.Balance)
            .HasPrecision(18, 2)
            .IsRequired();
            
        builder.Property(a => a.Type)
            .IsRequired();
            
        builder.Property(a => a.CreatedAt)
            .IsRequired();
            
        builder.Property(a => a.UpdatedAt)
            .IsRequired();
            
        builder.HasMany(a => a.Transactions)
            .WithOne(t => t.Account)
            .HasForeignKey(t => t.AccountId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}