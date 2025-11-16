using System;
using AutoMapper;
using Mango.services.Product.Api.Models;
using Mango.services.Product.Api.Models.Dto;
using Mango.services.ProductApi.Data;
using Mango.services.ProductApi.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.services.ProductApi.Controllers
{
    [Route("api/productAPI")]
    [ApiController]
   
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _appdbcontext;
        private readonly ResponseDTO _responseDTO;
        private IMapper _mapper;

        public ProductController(AppDbContext appDbContext, IMapper mapper)
        {
            _appdbcontext = appDbContext;
            _mapper = mapper;
            _responseDTO = new ResponseDTO();
        }

        [HttpGet]

        public ResponseDTO Get()
        {
            try
            {
                IEnumerable<Product1> objList = _appdbcontext.products.ToList();
                _responseDTO.Result= _mapper.Map<IEnumerable<ProductDto>>(objList);
            }
            catch (Exception ex)
            {
                _responseDTO.Issucess = false;
                _responseDTO.Message = ex.Message;

            }
            return _responseDTO;

        }
        [HttpGet("{id}")]
        public ResponseDTO Get(int id)
        {
            try
            {
                Product1 obj = _appdbcontext.products.First(u => u.ProductId == id);
                _responseDTO.Result = _mapper.Map<ProductDto>(obj);
            }
            catch(Exception ex)
            {
                _responseDTO.Issucess = false;
                _responseDTO.Message = ex.Message;
            }

            return _responseDTO;

        }
        [HttpPost]
        [Authorize(Roles ="ADMIN")]
        public ResponseDTO Post([FromBody] ProductDto productdto)
        {
            try
            {
                Product1 obj = _mapper.Map<Product1>(productdto);
                _appdbcontext.Add(obj);
                _appdbcontext.SaveChanges();

                _responseDTO.Result = _mapper.Map<Product1>(obj);
            }
            catch (Exception ex)
            {
                _responseDTO.Issucess = false;
                _responseDTO.Message = ex.Message;
            }

            return _responseDTO;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDTO Put([FromBody] ProductDto productdto)
        {
            try
            {
                Product1 obj = _mapper.Map<Product1>(productdto);
                _appdbcontext.Update(obj);
                _appdbcontext.SaveChanges();

            }
            catch (Exception ex)
            {
                _responseDTO.Issucess = false;
                _responseDTO.Message = ex.Message;
            }

            return _responseDTO;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDTO Delete(int id)
        {
            try
            {
                Product1 obj = _appdbcontext.products.First(x => x.ProductId == id);
                _appdbcontext.Remove(obj);
                _appdbcontext.SaveChanges();
            }
            
             catch (Exception ex)
            {
                _responseDTO.Issucess = false;
                _responseDTO.Message = ex.Message;
            }

            return _responseDTO;
        }
        

    }
}
