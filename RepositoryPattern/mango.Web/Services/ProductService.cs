using mango.Web.Models;
using mango.Web.Models.Dto;
using mango.Web.Services.IServices;
using mango.Web.Models;
using static mango.Web.Utility.SD;

namespace mango.Web.Services
{
    public class ProductService : IProudctService
    {
        private readonly IBaseService _baseservice;

        public ProductService(IBaseService baseService)
        {
                _baseservice = baseService;
        }
        public async Task<ResponseDto> CreateProductAync(ProductDto product)
        {

            return await _baseservice.Sendasync(new RequestDto()
            {
                ApiType = ApiType.POST,
                Data=product,
                Url = ProductApiBase + "/api/productAPI"

            });
        }

        public async Task<ResponseDto> DeleteProductAsync(int productid)
        {

            return await _baseservice.Sendasync(new RequestDto()
            {
                ApiType = ApiType.DELETE,
                Url = ProductApiBase + "/api/productAPI/" + productid

            });
        }

        public async Task<ResponseDto> GetAllProductAsync()
        {
           return await _baseservice.Sendasync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = ProductApiBase + "/api/productAPI"

           });
            
        }

        public async Task<ResponseDto> GetProductAsync(string productid)
        {
            return await _baseservice.Sendasync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = ProductApiBase + "/api/productAPI/" + productid,

            });

        }

        public async Task<ResponseDto> GetProductById(int productid)
        {
            return await _baseservice.Sendasync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = ProductApiBase + "/api/productAPI/" + productid,

            });
        }

        public async  Task<ResponseDto> UpdateProduct(ProductDto product)
        {
            return await _baseservice.Sendasync(new RequestDto()
            {
                ApiType = ApiType.PUT,
                Data= product,
                Url = ProductApiBase + "/api/productAPI/" + product.ProductId

            });
        }
    }
}
