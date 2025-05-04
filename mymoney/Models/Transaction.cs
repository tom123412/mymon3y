namespace mymoney.Models;

public sealed class Transaction
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime TransactionDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    public int AccountId { get; set; }
    public Account Account { get; set; } = null!;
}