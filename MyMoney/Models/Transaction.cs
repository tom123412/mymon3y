namespace MyMoney.Models;

public partial class Transaction
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public decimal Amount { get; set; }

    public bool IsExempt { get; set; }

    public int CategoryId { get; set; }

    public int AccountId { get; set; }

    public long RowIndex { get; set; }

    public decimal Balance { get; set; }

    public string? AuditUser { get; set; }

    public DateTime? AuditDate { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;
}
