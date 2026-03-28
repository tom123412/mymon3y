using System.ComponentModel.DataAnnotations;

namespace MyMoney.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(0.01, 9999999.99)]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [MaxLength(100)]
        public string? Category { get; set; }

        [MaxLength(1000)]
        public string? Notes { get; set; }
    }
}
