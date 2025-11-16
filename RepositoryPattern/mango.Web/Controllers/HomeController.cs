using System.Diagnostics;
using mango.Web.Models;
using mango.Web.Models.Dto;
using mango.Web.Services;
using mango.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace mango.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProudctService _productservice;
        public HomeController(ILogger<HomeController> logger,IProudctService proudctService)
        {
            _logger = logger;
            _productservice = proudctService;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductDto?> Productlist = new();
            ResponseDto? responseDto = await _productservice.GetAllProductAsync();
            if (responseDto != null && responseDto.IsSuccess)
            {
                Productlist = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(responseDto.Result));
            }
            else
            {
                TempData["error"] = responseDto.Message;
            }
            return View(Productlist);
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
