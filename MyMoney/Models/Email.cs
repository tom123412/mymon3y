namespace MyMoney.Models;

public partial class Email
{
    public int Id { get; set; }

    public required string Email1 { get; set; }

    public int User { get; set; }

    public string? AuditUser { get; set; }

    public DateTime? AuditDate { get; set; }

    public required virtual User UserNavigation { get; set; }
}
