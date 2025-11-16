using mango.Web.Models.Dto;
using mango.Web.Models;
using mango.Web.Models.Dto;
using mango.Web.Services.IServices;
using static mango.Web.Utility.SD;

namespace mango.Web.Services
{
    public class CouponService : IcouponService
    {
        private readonly IBaseService _baseservice;

        public CouponService(IBaseService baseService)
        {
                _baseservice = baseService;
        }
        public async Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto)
        {
            return await _baseservice.Sendasync(new RequestDto()
            {
                ApiType = ApiType.POST,
                Data=couponDto,
                Url = CouponApiBase + "/api/CouponApi/" 
            });
        }

        public async Task<ResponseDto?> DeleteCouponAsync(int id)
        {
            return await _baseservice.Sendasync(new RequestDto()
            {
                ApiType = ApiType.DELETE,
                Url = CouponApiBase + "/api/CouponApi/" + id
            });
        }

        public async Task<ResponseDto?> GetAllCouponAsync()
        {
            return await _baseservice.Sendasync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = CouponApiBase + "/api/CouponApi"
            });
        }

        public async Task<ResponseDto?> GetCouponAsync(string couponCode)
        {
            return await _baseservice.Sendasync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = CouponApiBase + "/api/CouponApi/GetByCode" + couponCode
            });
        }

        public async Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            return await _baseservice.Sendasync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = CouponApiBase + "/api/CouponApi/" + id
            });
        }

        public async Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto)
        {
            return await _baseservice.Sendasync(new RequestDto()
            {
                ApiType = ApiType.PUT,
                Data = couponDto,
                Url = CouponApiBase + "/api/CouponApi/"
            });
        }
    }
}
