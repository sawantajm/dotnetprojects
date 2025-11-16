using System.ComponentModel.DataAnnotations;
using MilkManagementSystem.Models;

namespace MilkManagementSystem.DTOS
{
    public class FoodDeatilsDTO
    {

        
        [Required]
        public int? Customerid { get; set; }

        [Required]
        public int? Quantity { get; set; }
        [Required]
        public List<FoodDTO> FoodItems { get; set; }
      
    }
}
