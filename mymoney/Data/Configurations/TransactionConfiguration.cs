using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mymoney.Models;

namespace mymoney.Data.Configurations;

public sealed class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(t => t.Id);
        
        builder.Property(t => t.Description)
            .HasMaxLength(200)
            .IsRequired();
            
        builder.Property(t => t.Amount)
            .HasPrecision(18, 2)
            .IsRequired();
            
        builder.Property(t => t.Type)
            .IsRequired();
            
        builder.Property(t => t.TransactionDate)
            .IsRequired();
            
        builder.Property(t => t.CreatedAt)
            .IsRequired();
            
        builder.Property(t => t.UpdatedAt)
            .IsRequired();
            
        // Relationships are defined in Account and Category configurations
        builder.HasOne(t => t.Account)
            .WithMany(a => a.Transactions)
            .HasForeignKey(t => t.AccountId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.HasOne(t => t.Category)
            .WithMany(c => c.Transactions)
            .HasForeignKey(t => t.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}