
using AutoMapper;
using Mango.services.Product.Api.Models;
using Mango.services.Product.Api.Models.Dto;

namespace Mango.services.ProductApi
{
    public class MappingConfig 
    {
        public static MapperConfiguration RegisterMaps()
        {
            var Mappingcon = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product1>().ReverseMap();
            });
            return Mappingcon;
        }
    }
}
