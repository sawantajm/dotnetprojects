using Mango.Services.CuponAPI.Models;

namespace Mango.Services.CuponAPI.DTOS
{
    public class ResponseDTO
    {
        public object? Result { get; set; }
        public bool IsSucess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
