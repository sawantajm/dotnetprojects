using ASPNetCoreAPIAURD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreAPIAURD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAPIController : ControllerBase
    {
        private readonly DotNetCoreExeContext _Context;
        public EmployeeAPIController(DotNetCoreExeContext _Context)
        {
            this._Context = _Context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployee()
        {
            var EMPData = await _Context.Employees.ToListAsync();
            return Ok(EMPData);
        }

        [HttpGet("id")]
        public async Task<ActionResult<List<Employee>>> GetEmployeeById(int id)
        {
            var EMPData = await _Context.Employees.FindAsync(id);
            if(EMPData ==null)
            {
                return BadRequest("Record Not Found....");
            }

            return Ok(EMPData);
        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> GetEmployeeById(Employee emp)
        {
                   await _Context.Employees.AddAsync(emp);
                  await _Context.SaveChangesAsync();
            return Ok("Recored inserted sucessfully");

        }

        [HttpPut("id")]
        public async Task<ActionResult<List<Employee>>> UpdateEmployeeById(int? id,Employee emp)
        {
            if(id != emp.Id)
            {
                return BadRequest("Please check entered data it is not matching with database");
            }
             _Context.Entry(emp).State = EntityState.Modified;
            await _Context.SaveChangesAsync();
            return Ok(emp);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<List<Employee>>> DeleteEmployeeById(int? id)
        {
            var EmpData = await _Context.Employees.FindAsync(id);
            if(EmpData !=null)
            {
                _Context.Employees.Remove(EmpData);
                await _Context.SaveChangesAsync();
                return Ok("Data Deleted Sucessfully");
            }
            return BadRequest("Recored Not Found");
        }
    }
}
