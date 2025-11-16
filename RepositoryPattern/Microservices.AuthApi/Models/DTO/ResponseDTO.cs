namespace Microservices.AuthApi.Models.DTO
{
    public class ResponseDTO
    {
        public object? Result { get; set; }
        public bool Issucess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
