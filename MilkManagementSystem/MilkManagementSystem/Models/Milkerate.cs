using System;
using System.Collections.Generic;

namespace MilkManagementSystem.Models;

public partial class Milkerate
{
    public int Id { get; set; }

    public double? Fatrate { get; set; }

    public double? Snfrate { get; set; }
}
