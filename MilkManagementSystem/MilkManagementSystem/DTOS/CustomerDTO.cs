using System.ComponentModel.DataAnnotations;
using MilkManagementSystem.Models;

namespace MilkManagementSystem.DTOS
{
    public class CustomerDTO
    {
        public int Customerid { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [RegularExpression("^[0-9]*$")]
        [MinLength(1)]
        [MaxLength(10)]
        public string MobileNo { get; set; }

        public int RoleId { get; set; }
        public int MilkTypeid { get; set; }
        public DateTime Dateadded { get; set; }

        public DateTime Datechanged { get; set;  }

        public bool IsDeleted { get; set; }=false;

        public TypsOfMilk typsOfMilk { get; set; }

    }
}
