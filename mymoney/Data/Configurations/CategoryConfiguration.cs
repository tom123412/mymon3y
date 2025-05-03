using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mymoney.Models;

namespace mymoney.Data.Configurations;

public sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();
            
        builder.Property(c => c.Description)
            .HasMaxLength(500);
            
        builder.Property(c => c.Type)
            .IsRequired();
            
        builder.Property(c => c.CreatedAt)
            .IsRequired();
            
        builder.Property(c => c.UpdatedAt)
            .IsRequired();
            
        // Relationship is defined in Transaction configuration
        builder.HasMany(c => c.Transactions)
            .WithOne(t => t.Category)
            .HasForeignKey(t => t.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}