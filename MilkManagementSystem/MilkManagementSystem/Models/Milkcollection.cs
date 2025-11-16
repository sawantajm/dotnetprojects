using System;
using System.Collections.Generic;

namespace MilkManagementSystem.Models;

public partial class Milkcollection
{
    public int? Customerid { get; set; }

    public int? Milktypeid { get; set; }

    public decimal? Liter { get; set; }

    public double? Fat { get; set; }

    public double? Snf { get; set; }

    public decimal? Total { get; set; }

    public DateTime? Dateadded { get; set; }

    public string Guid { get; set; } = null!;

    public double? Rate { get; set; }

    public string? Collectionshift { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Milktype? Milktype { get; set; }
}
