namespace mymoney.Models;

public sealed class Transaction
{
    public int Id { get; set; }
    public required string Description { get; set; }
    public decimal Amount { get; set; }
    public TransactionType Type { get; set; }
    public DateTime TransactionDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    public int AccountId { get; set; }
    public Account Account { get; set; } = null!;
    
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
}

public enum TransactionType
{
    Income,
    Expense,
    Transfer
}