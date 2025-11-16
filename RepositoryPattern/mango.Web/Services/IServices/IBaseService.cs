using mango.Web.Models;
using mango.Web.Models.Dto;

namespace mango.Web.Services.IServices
{
    public interface IBaseService
    {
        Task<ResponseDto?> Sendasync (RequestDto requestdto, bool withBearer = true );
    }
}
