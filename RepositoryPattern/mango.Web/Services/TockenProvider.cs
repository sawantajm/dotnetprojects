using mango.Web.Services.IServices;
using mango.Web.Utility;

namespace mango.Web.Services
{
    public class TockenProvider : ITockenProvider
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public TockenProvider(IHttpContextAccessor httpContextAccessor)
        {
                _contextAccessor = httpContextAccessor;
        }
        public void ClearTocken()
        {
            _contextAccessor.HttpContext?.Response.Cookies.Delete(SD.TockenCookie);
        }

        public string? GetTocken()
        {
            string? tocken = null;
            bool? hastocken = _contextAccessor.HttpContext?.Request.Cookies.TryGetValue(SD.TockenCookie,out tocken);
            return hastocken is true? tocken : null;
        }

        public void SetTocken(string tocken)
        {
            _contextAccessor.HttpContext?.Response.Cookies.Append(SD.TockenCookie,tocken);
        }
    }
}
