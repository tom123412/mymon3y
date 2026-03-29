namespace MyMoney.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }

    public int CategoryTypeId { get; set; }

    public string? AuditUser { get; set; }

    public DateTime? AuditDate { get; set; }

    public virtual CategoryType CategoryType { get; set; } = null!;
}
