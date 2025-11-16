using mango.Web.Models.Dto;
using mango.Web.Models.Dto;
using mango.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using mango.Web.SweetAlert;

namespace mango.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly IcouponService _couponservice;
       
        public CouponController(IcouponService icouponService)
        {
            _couponservice = icouponService;
        }
        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto>? list = new();
            ResponseDto? responseDto = await _couponservice.GetAllCouponAsync();
            if (responseDto != null &&  responseDto.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(responseDto.Result));
            }
            else
            {
                TempData["error"] = responseDto.Message;
            }
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> CouponCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CouponCreate(CouponDto couponDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _couponservice.CreateCouponAsync(couponDto);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Coupon created successfully.";
                    return RedirectToAction(nameof(CouponIndex));
                }
                else
                {
                    TempData["error"] = response.Message;
                }
                
            }
            return View(couponDto);
        }

      
        public async Task<IActionResult> CouponDelete(int CouponId)
        {
            ResponseDto? response = await _couponservice.GetCouponByIdAsync(CouponId);
            if(response != null && response.IsSuccess)
            {
                CouponDto? model =JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(response.Result));
                
                return View(model);
            }
            else
            {
                TempData["error"] = response.Message;
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> CouponDelete(CouponDto couponDto)
        {
            ResponseDto? response = await _couponservice.DeleteCouponAsync(couponDto.CouponId);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Coupon Deleted successfully.";
                return RedirectToAction(nameof(CouponIndex));
            }
            else
            {
                TempData["error"] = response.Message;
            }
            return View(couponDto);
        }

        
    }
}
