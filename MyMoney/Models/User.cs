using System;
using System.Collections.Generic;

namespace MyMoney.Models;

public partial class User
{
    public int Id { get; set; }

    public string? AuditUser { get; set; }

    public DateTime? AuditDate { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<Email> Emails { get; set; } = new List<Email>();
}
