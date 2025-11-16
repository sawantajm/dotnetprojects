using static mango.Web.Utility.SD;

namespace mango.Web.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessTocken { get; set; }
    }
}
