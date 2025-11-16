using mango.Web.Models.Dto;
using mango.Web.Services.IServices;
using mango.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace mango.Web.Controllers
{
    public class ProductContoller : Controller
    {
        private readonly IProudctService _productService;
        public ProductContoller(IProudctService proudctService)
        {
         
            _productService = proudctService;
        }
        [HttpGet]
        public async Task<IActionResult> ProductIndex()
        {
        
            List<ProductDto?> Productlist = new();
            ResponseDto responseDto = await _productService.GetAllProductAsync();
            if (responseDto != null && responseDto.IsSuccess)
            {
                Productlist = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(responseDto.Result));
            }
            return View(Productlist);
        }

        [HttpGet]
        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductDto productDto)
        {

          
            ResponseDto responseDto = await _productService.CreateProductAync(productDto);
            if (responseDto != null && responseDto.IsSuccess)
            {
                TempData["Success"] = "Product created sucessfully..";
                return RedirectToAction(nameof(ProductIndex));
            }
            return View(productDto);
        }

        [HttpGet]
        public async Task<IActionResult> ProductEdit(int Productid)
        {
            
            ResponseDto responseDto = await _productService.GetProductById(Productid);
            if (responseDto != null && responseDto.IsSuccess)
            {
               ProductDto? Productlist = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(responseDto.Result));
                return View(Productlist);
            }
            else
            {
                TempData["error"] = responseDto.Message;
            }
            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> ProductEdit(ProductDto productDto)
        {

            ResponseDto responseDto = await _productService.UpdateProduct(productDto);
            if (responseDto != null && responseDto.IsSuccess)
            {
               
                TempData["Success"] = "Product Updated sucessfully..";
                return RedirectToAction(nameof(ProductIndex));
            }
            else
            {
                TempData["error"] = responseDto.Message;
            }
            return View(productDto);
        }
        [HttpGet]
        public async Task<IActionResult> ProductDelete(int Productid)
        {

            ResponseDto responseDto = await _productService.GetProductById(Productid);
            if (responseDto != null && responseDto.IsSuccess)
            {
                ProductDto? Productlist = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(responseDto.Result));
                return View(Productlist);
            }
            else
            {
                TempData["error"] = responseDto.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductDto productDto)
        {

            ResponseDto responseDto = await _productService.DeleteProductAsync(productDto.ProductId);
            if (responseDto != null && responseDto.IsSuccess)
            {

                TempData["Success"] = "Product Deleted sucessfully..";
                return RedirectToAction(nameof(ProductIndex));
            }
            else
            {
                TempData["error"] = responseDto.Message;
            }
            return View(productDto);
        }
    }
}
