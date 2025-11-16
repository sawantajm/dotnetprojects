using System;
using System.Collections.Generic;

namespace MilkManagementSystem.Models;

public partial class Food
{
    public int Foodid { get; set; }

    public string FoodName { get; set; } = null!;

    public int? SellingRate { get; set; }

    public int? ByingRate { get; set; }

    public int? Stock { get; set; }

    public DateTime? Dateadded { get; set; }

    public DateTime? DateChanged { get; set; }

    public bool? Deleteflag { get; set; }

    public virtual ICollection<FoodDetail> FoodDetails { get; set; } = new List<FoodDetail>();
}
