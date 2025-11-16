using System;
using System.Collections.Generic;

namespace MilkManagementSystem.Models;

public partial class Role
{
    public int Roleid { get; set; }

    public string Rolename { get; set; } = null!;

    public DateTime? Dateadded { get; set; }

    public DateTime? Datechanged { get; set; }

    public bool? Deleteflag { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
