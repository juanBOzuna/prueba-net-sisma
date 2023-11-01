using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BankAPI.Data.BanksModals;

public partial class Client
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [MaxLength(40)]
    public string PhoneNumber { get; set; } = null!;

    [MaxLength(50)]
    [EmailAddress]
    public string? Email { get; set; }

    public DateTime? RegDate { get; set; }

    //[JsonIgnore]
    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
