using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using AspNetCoreGeneratedDocument;
using mango.Web.Models;
using mango.Web.Models.Dto;
using mango.Web.Services.IServices;
using Newtonsoft.Json;
using static mango.Web.Utility.SD;

namespace mango.Web.Services
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITockenProvider _tockenProvider;
        public BaseService(IHttpClientFactory httpClientFactory, ITockenProvider tockenProvider)
        {
            _httpClientFactory = httpClientFactory;
            _tockenProvider = tockenProvider;
        }
        public async Task<ResponseDto?> Sendasync(RequestDto requestdto , bool withBearer = true)
        {
            HttpClient client = _httpClientFactory.CreateClient("MangoApi");
            HttpRequestMessage message = new();
            message.Headers.Add("Accept", "application/json");

            //tocken
            if (withBearer)
            {
                var tocken = _tockenProvider.GetTocken();
                message.Headers.Add("Authorization", $"Bearer {tocken}");
            }
            message.RequestUri = new Uri(requestdto.Url);
            if (requestdto != null)
            {
               message.Content = new StringContent(JsonConvert.SerializeObject(requestdto.Data),Encoding.UTF8,"application/json");
            }
            HttpResponseMessage? apiResponse = null;

          
            switch(requestdto.ApiType)
            {
                case ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
                case ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                default:
                    message.Method = HttpMethod.Get;
                    break;
            }
            
            apiResponse = await client.SendAsync(message);

            try
            {
                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { IsSuccess = false, Message = "Not Found" };
                    case HttpStatusCode.Forbidden:
                        return new() { IsSuccess = false, Message = "Access Denied" };
                    case HttpStatusCode.Unauthorized:
                        return new() { IsSuccess = false, Message = "UnAuthorized" };
                    case HttpStatusCode.InternalServerError:
                        return new() { IsSuccess = false, Message = "Internal Server Error." };

                    default:
                        var apicontent = await apiResponse.Content.ReadAsStringAsync();
                        var apiresponseDto = JsonConvert.DeserializeObject<ResponseDto>(apicontent);

                        return apiresponseDto;
                }
            }
            catch (Exception ex)
            {
                var dto = new ResponseDto
                {
                    Message = ex.Message.ToString(),
                    IsSuccess = false
                };
                return dto;
            }

            
        }
    }
}
