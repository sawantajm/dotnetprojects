using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilkManagementSystem.DTOS;
using MilkManagementSystem.Models;

namespace MilkManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly MilkMgtSystemContext _context;


        public CustomerController(MilkMgtSystemContext context)
        {
            _context = context;
            
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
            //LINQ used to find the user having customer role and not deleted.
            var Data = await _context.Customers.ToListAsync();

            try
            {
                if (Data != null)
                {
                    
                    var AllAvailableCustomer = Data.Where(cust => cust.Roleid == 3 && cust.Deleteflag == false);
                    return Ok(AllAvailableCustomer);
                }

                return BadRequest("No data Available");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
            

        [HttpGet("Customer/{id}")]

        public async Task<ActionResult> GetCustomerById(int id)
        {
            var data = await _context.Customers.FindAsync(id);
            if (data != null)
            {

                return Ok(data);

            }
            return NotFound("Record is not present..");
        }

        [HttpPost("AddCustomer")]
        public async Task<ActionResult> CreateNewCustomer([FromBody] CustomerDTO customerDTO)
        {
            var customer = new Customer
            {
                FirstName = customerDTO.FirstName,
                LastName = customerDTO.LastName,  
                Mobileno = customerDTO.MobileNo,
                Roleid = customerDTO.RoleId,
                Milktypeid = customerDTO.MilkTypeid,
                Dateadded = DateTime.Now,
                Datechanged = DateTime.Now,
                Deleteflag = false
            };

            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            return Ok(customer);
        }

    }
}
