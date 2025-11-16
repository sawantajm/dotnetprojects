using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.DTOs;
using RepositoryPattern.Models;
using RepositoryPattern.Repositories;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;


        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            var GetAllCustomer = await _customerRepository.GetAllAsync();
            var customerDtos = GetAllCustomer.Select(C => new CustomerDTO
            {
                CustomerId = C.CustomerId,
                FullName = C.FullName,
                Email = C.Email
            });
            return Ok(customerDtos);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult>GetCustomerById(int id)
        {
            var Customer = await _customerRepository.GetByIdAsync(id);
            if(Customer == null)
            {
                return NotFound($"Customer is {id} not available in database.");
            }
            var customerdtos = new CustomerDTO
            {
                CustomerId = Customer.CustomerId,
                FullName = Customer.FullName,
                Email = Customer.Email
            };
            return Ok(customerdtos);

        }

        [HttpPost]

        public async Task<IActionResult> CreateCutomer([FromBody] CustomerDTO customerDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var CustDto = new Customer
            {
                FullName = customerDTO.FullName,
                Email = customerDTO.Email

            };
            await _customerRepository.AddAsync(CustDto);
            await _customerRepository.SaveAsync();

            CustDto.CustomerId = customerDTO.CustomerId;

            return Ok($"Data Inserted sucessfully..");

        }
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateCustomer(int id, CustomerDTO customerDTO)
        {
           if(id != customerDTO.CustomerId)
            {
                return BadRequest($" {customerDTO.FullName} is not available..");
            }
            if (!ModelState.IsValid)
            {
                return NotFound($"Customer is {customerDTO.FullName} not available..");
            }
            var CustomerExtists = await _customerRepository.GetByIdAsync(id);
            if(CustomerExtists ==null)
            {
                return NotFound($"Customer is {customerDTO.FullName} not available..");
            }
            CustomerExtists.Email = customerDTO.Email;
            CustomerExtists.FullName = customerDTO.FullName;

             _customerRepository.Update(CustomerExtists);
            await _customerRepository.SaveAsync();

            return Ok("Data Updated successfully..");

        }

    }
}
