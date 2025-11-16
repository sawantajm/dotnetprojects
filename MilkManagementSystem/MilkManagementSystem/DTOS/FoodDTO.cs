using System.ComponentModel.DataAnnotations;

namespace MilkManagementSystem.DTOS
{
    public class FoodDTO
    {
        [Required]
        public int Foodid { get; set; }
        [Required]
        public string FoodName { get; set; } = null!;
        [Required]
        public int? SellingRate { get; set; }
        [Required]
        public int? Stock { get; set; }
        [Required]
        public DateTime? Dateadded { get; set; }
        public bool? Deleteflag { get; set; }
    }
}
