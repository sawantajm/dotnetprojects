using System.Runtime.InteropServices;
using EcommerceAPI.Data;
using EcommerceAPI.DTOs;
using EcommerceAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ECommerceDbContext _context;

        public CustomerController(ECommerceDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("Rgister")]

        public async Task<ActionResult<Customer>> RegisterCustomers([FromForm] CustomerRegistrationDTO registrationDTO)
        {
            if (await _context.Customers.AnyAsync(c => c.Email == registrationDTO.Email))
            {
                return BadRequest("Customer is alredy Exist..");
            }

            var customer = new Customer
            {
                Name = registrationDTO.Name,
                Email = registrationDTO.Email,
                Password = registrationDTO.password
            };
            if (customer != null)
            {
               await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return Ok();
        }
        [HttpPost("Login")]
        public async Task<ActionResult<Customer>> Login([FromBody] CustomerLoginDTO customerLoginDTO)
        {
            var customerLogin = await _context.Customers.FirstOrDefaultAsync(c => c.Email == customerLoginDTO.Email && c.Password == customerLoginDTO.Password);
            if(customerLogin == null)
            {
                return Unauthorized("invalid UserId or Password");
            }
            return Ok(new { Message = "Login Sucessfull.." });
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>>  GetCustomers(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if(customer ==null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

    }
}
