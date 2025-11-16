using System.ComponentModel.DataAnnotations;

namespace mango.services.CouponApi.Models
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }
        [Required]
        public string CouponCode { get; set; }
        [Required]
        public double DiscountAmmount { get; set; }
        public int minAmmount { get; set; }

    }
}
