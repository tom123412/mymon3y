namespace mymoney.Models;

public sealed class Account
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal Balance { get; set; }
    public AccountType Type { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}

public enum AccountType
{
    Checking,
    Savings,
    CreditCard,
    Investment,
    Cash
}