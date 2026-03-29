namespace MyMoney.Models;

public partial class CategoryType
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public string? AuditUser { get; set; }

    public DateTime? AuditDate { get; set; }

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
