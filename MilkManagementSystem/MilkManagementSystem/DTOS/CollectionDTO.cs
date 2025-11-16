using System.ComponentModel.DataAnnotations;
using MilkManagementSystem.Models;

namespace MilkManagementSystem.DTOS
{
    public class CollectionDTO
    {
        [Required]
        public int? Customerid { get; set; }

        public int? Milktypeid { get; set; }

        [Required]
        public decimal? Liter { get; set; }
        [Required]
        public double? Fat { get; set; }
        [Required]
        public double? Snf { get; set; }

        public float Rate { get; set; }
        public decimal? Total { get; set; }

        public DateTime? Dateadded { get; set; }
        public Shift shift { get; set; }
       public string MilkName { get; set; }
    }
}
