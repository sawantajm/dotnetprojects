using System;
using System.Collections.Generic;

namespace MilkManagementSystem.Models;

public partial class Milktype
{
    public int Milktypeid { get; set; }

    public string Milkname { get; set; } = null!;

    public DateTime? Dateadded { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Milkcollection> Milkcollections { get; set; } = new List<Milkcollection>();
}
