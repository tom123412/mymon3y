using System.ComponentModel.DataAnnotations;

namespace MyMoney.Models;

public class Expense
{
    [Key]
    public int Id { get; set; }

    public required string Description { get; set; } = string.Empty;

    [Range(0.01, 9999999.99)]
    public decimal Amount { get; set; }

    public DateTime Date { get; set; }

    public string? Category { get; set; }

    public string? Notes { get; set; }
}
