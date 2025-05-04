using mymoney.Models.Common;

namespace mymoney.Models;

public sealed class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsActive { get; set; } = true;
    
    public ICollection<Email> Emails { get; set; } = [];
    public ICollection<Account> Accounts { get; set; } = [];
}