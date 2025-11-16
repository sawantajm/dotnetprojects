using System.Net.NetworkInformation;
using AutoMapper;
using mango.services.CouponApi.Models;
using mango.services.CouponApi.Models.Dto;

namespace mango.services.CouponApi
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMap()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Coupon, CouponDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
