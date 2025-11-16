using System.ComponentModel.DataAnnotations;

namespace Mango.Services.CuponAPI.Models
{
    public class Cupon
    {
        [Key]
        public int CouponId { get; set; }
        [Required]
        public string CuponCode { get; set; }
        [Required]
        public double Discount { get; set; }
        public int minAmmount { get; set; }
    }
}
