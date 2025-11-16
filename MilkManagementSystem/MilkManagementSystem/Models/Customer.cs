using System;
using System.Collections.Generic;

namespace MilkManagementSystem.Models;

public partial class Customer
{
    public int Customerid { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Mobileno { get; set; } = null!;

    public int? Roleid { get; set; }

    public int? Milktypeid { get; set; }

    public DateTime? Dateadded { get; set; }

    public DateTime? Datechanged { get; set; }

    public bool? Deleteflag { get; set; }

    public virtual ICollection<FoodDetail> FoodDetails { get; set; } = new List<FoodDetail>();

    public virtual ICollection<Milkcollection> Milkcollections { get; set; } = new List<Milkcollection>();

    public virtual Milktype? Milktype { get; set; }

    public virtual Role? Role { get; set; }
}
