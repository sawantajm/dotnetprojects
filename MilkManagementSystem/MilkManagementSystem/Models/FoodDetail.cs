using System;
using System.Collections.Generic;

namespace MilkManagementSystem.Models;

public partial class FoodDetail
{
    public int Srno { get; set; }

    public int? FoodId { get; set; }

    public string? Foodname { get; set; }

    public int? Quantity { get; set; }

    public int Rate { get; set; }

    public int? Amount { get; set; }

    public int? Customerid { get; set; }

    public DateTime? Dateadded { get; set; }

    public DateTime? Datechanged { get; set; }

    public bool? Deleteflag { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Food? Food { get; set; }
}
