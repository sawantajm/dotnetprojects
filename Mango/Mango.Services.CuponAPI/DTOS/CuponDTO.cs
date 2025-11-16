namespace Mango.Services.CuponAPI.DTOS
{
    public class CuponDTO
    {
        public int CouponId { get; set; }
        public string CuponCode { get; set; }
        public double Discount { get; set; }
        public int minAmmount { get; set; }
    }
}
