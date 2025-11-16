using System.Runtime.CompilerServices;
using Azure;
using Mango.Services.CuponAPI.Data;
using Mango.Services.CuponAPI.DTOS;
using Mango.Services.CuponAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CuponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuponController : ControllerBase
    {
        private readonly AppDbContext _context;
        private ResponseDTO _response;

        public CuponController(AppDbContext context)
        {
            _context = context;
            _response = new ResponseDTO();
        }

        [HttpGet]

        public async Task<ActionResult<Response>> Get()
        {
            try
            {
                IEnumerable<Cupon>CouponList = await _context.cupons.ToListAsync();

                _response.Result = CouponList;
                

            }
            catch(Exception ex)
            {
                _response.IsSucess = false;
                _response.Message = ex.Message;
            }
            return Ok(_response);
        }

        [HttpGet("id")]

        public async Task<ActionResult<Response>> Get(int id)
        {
            try
            {
                Cupon CuponList = await _context.cupons.FirstOrDefaultAsync(u => u.CouponId == id);
                CuponDTO cupondto = new CuponDTO()
                {
                    CouponId = CuponList.CouponId,
                    CuponCode = CuponList.CuponCode,
                    Discount = CuponList.Discount,
                    minAmmount = CuponList.minAmmount
                };
                if(CuponList != null)
                {
                    return BadRequest();
                }

                _response.Result = cupondto;
               

            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.Message = ex.Message;
            }
            return Ok(_response);
        }
    }
}
