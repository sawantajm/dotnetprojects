using mango.Web.Models.Dto;
using mango.Web.Models;

namespace mango.Web.Services.IServices
{
    public interface IProudctService
    {
        Task<ResponseDto> GetProductAsync(string productid);

        Task<ResponseDto> GetAllProductAsync();

        Task<ResponseDto> GetProductById(int productid);

        Task<ResponseDto> CreateProductAync(ProductDto product);

        Task<ResponseDto> UpdateProduct(ProductDto product);
        Task<ResponseDto> DeleteProductAsync(int productid);
    }
}
