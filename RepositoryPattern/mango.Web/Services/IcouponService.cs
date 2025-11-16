using mango.Web.Models.Dto;
using mango.Web.Models.Dto;

namespace mango.Web.Services
{
    public interface IcouponService
    {
        Task<ResponseDto?> GetCouponAsync(string CouponId);
        Task<ResponseDto?> GetAllCouponAsync();
        Task<ResponseDto?> GetCouponByIdAsync(int id);
        Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto);
        Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto);
        Task<ResponseDto?> DeleteCouponAsync(int id);
    }
}
