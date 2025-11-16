using AutoMapper;
using mango.services.CouponApi.Data;
using mango.services.CouponApi.Models;
using mango.services.CouponApi.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mango.services.CouponApi.Controllers
{
    [Route("api/CouponApi")]
    [ApiController]
    [Authorize]
    public class CouponController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;
        public CouponController(AppDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();

        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupon> ObjList = _db.Coupons.ToList();
                _response.Result = _mapper.Map<IEnumerable<CouponDto>>(ObjList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpGet("{id}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Coupon ObjList = _db.Coupons.First(u => u.CouponId == id);
               _response.Result= _mapper.Map<CouponDto>(ObjList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message= ex.Message;
            }
            return _response;
        }

        [HttpGet("GetByCode/{code}")]

        public ResponseDto GetByCode(string code)
        {
            try
            {
                Coupon ObjList = _db.Coupons.First(u => u.CouponCode.ToLower() == code.ToLower());
                _response.Result = _mapper.Map<CouponDto>(ObjList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto CreateCoupon([FromBody] CouponDto couponDto)
        {
            try
            {
                var data = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Add(data);
                _db.SaveChanges();
                _response.Result = _mapper.Map<CouponDto>(data);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Put([FromBody] CouponDto couponDto)
        {
            try
            {
                var data = _mapper.Map<Coupon>(couponDto);
               if(ModelState.IsValid)
                {
                    _db.Coupons.Update(data);
                    _db.SaveChanges();
                }
                _response.Result = _mapper.Map<CouponDto>(data);
            }
            catch( Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Delete(int id)
        {
            try
            {
                var data = _db.Coupons.FirstOrDefault(u => u.CouponId == id);
                if (ModelState.IsValid)
                {
                    _db.Coupons.Remove(data);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
