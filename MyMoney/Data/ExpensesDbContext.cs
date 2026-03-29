using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MyMoney.Models;

namespace MyMoney.Data;

public partial class ExpensesDbContext : DbContext
{
    public ExpensesDbContext()
    {
    }

    public ExpensesDbContext(DbContextOptions<ExpensesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategoryType> CategoryTypes { get; set; }

    public virtual DbSet<Email> Emails { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable(tb => tb.HasTrigger("AuditAccounts"));

            entity.Property(e => e.AuditDate).HasColumnType("datetime");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Accounts_Users");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable(tb => tb.HasTrigger("AuditCategories"));

            entity.HasIndex(e => e.CategoryTypeId, "IX_FK_CategoryCategoryType");

            entity.Property(e => e.AuditDate).HasColumnType("datetime");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.HasOne(d => d.CategoryType).WithMany(p => p.Categories)
                .HasForeignKey(d => d.CategoryTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CategoryCategoryType");
        });

        modelBuilder.Entity<CategoryType>(entity =>
        {
            entity.ToTable(tb => tb.HasTrigger("AuditCategoryTypes"));

            entity.Property(e => e.AuditDate).HasColumnType("datetime");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(256)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Email>(entity =>
        {
            entity.ToTable(tb => tb.HasTrigger("AuditEmails"));

            entity.Property(e => e.AuditDate).HasColumnType("datetime");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Email1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Email");

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.Emails)
                .HasForeignKey(d => d.User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Emails_Users");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.ToTable(tb =>
                {
                    tb.HasTrigger("AuditTransactions");
                    tb.HasTrigger("UpdateBalance");
                });

            entity.HasIndex(e => e.AccountId, "IX_FK_TransactionAccount");

            entity.HasIndex(e => e.CategoryId, "IX_FK_TransactionCategory");

            entity.HasIndex(e => new { e.AccountId, e.CategoryId, e.RowIndex, e.Amount }, "IX_Transactions_Account_Category_RowIndex_Amount");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AuditDate).HasColumnType("datetime");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransactionAccount");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable(tb => tb.HasTrigger("AuditUsers"));

            entity.Property(e => e.AuditDate).HasColumnType("datetime");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(256)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
