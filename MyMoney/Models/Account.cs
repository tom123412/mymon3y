namespace MyMoney.Models;

public partial class Account
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public bool IsActive { get; set; }

    public required string AuditUser { get; set; }

    public DateTime AuditDate { get; set; }

    public int User { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = [];

    public required virtual User UserNavigation { get; set; }
}
