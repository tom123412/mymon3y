using Microsoft.EntityFrameworkCore;
using MyMoney.Models;

namespace MyMoney.Data;

public class ExpensesDbContext : DbContext
{
    public ExpensesDbContext(DbContextOptions<ExpensesDbContext> options)
        : base(options)
    {
    }

    public DbSet<Expense> Expenses { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Expense>(entity =>
        {
            entity.ToTable("Expenses");
            entity.Property(e => e.Description).HasMaxLength(200).IsRequired();
            entity.Property(e => e.Amount).HasPrecision(18, 2).IsRequired();
            entity.Property(e => e.Date).IsRequired();
            entity.Property(e => e.Category).HasMaxLength(100);
            entity.Property(e => e.Notes).HasMaxLength(1000);
        });

        base.OnModelCreating(modelBuilder);
    }
}
