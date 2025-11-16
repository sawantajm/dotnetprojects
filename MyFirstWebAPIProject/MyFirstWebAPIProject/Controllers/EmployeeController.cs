using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebAPIProject.Models;
using MyFirstWebAPIProject.Repositories;

namespace MyFirstWebAPIProject.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public ActionResult <IEnumerable<Employee>> GetALLEmployees()
        {
            var Employees = _employeeRepository.GetALLEmployee();
            return Ok(Employees);
        }
        [HttpGet("{id}")]
        public ActionResult <IEnumerable<Employee>> GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if(employee !=null)
            {
                return Ok(employee);
            }
            else
            {
                return BadRequest($"Employee is not present for {id}");
            }
        }
        [HttpPost]

        public ActionResult<Employee> CreateNewEmployee([FromBody] Employee employee)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _employeeRepository.Addemployee(employee);

            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]

        public IActionResult UpdateEmployeeById(int id ,[FromBody] Employee employee)
        {
            if(id != employee.Id)
            {
                return BadRequest();
            }
            if (!_employeeRepository.IsExist(employee.Id))
            {
                return BadRequest();
            }
            _employeeRepository.UpdateEmployee(employee);
            return Ok();
        }

        //partially update an existing employee
        [HttpPatch("{id}")]

        public ActionResult PatchEmployee(int id, [FromBody] Employee employee)
        {
            var employeeExist = _employeeRepository.GetById(id);
            if (employeeExist == null)
            {
                return BadRequest();
            }

            employeeExist.Name = employee.Name ?? employeeExist.Name;
            employeeExist.Position = employee.Position ?? employeeExist.Position;
            employeeExist.Age = employee.Age != 0 ? employee.Age : employeeExist.Age;
            employeeExist.EmailAddress = employee.EmailAddress ?? employeeExist.EmailAddress;
            _employeeRepository.UpdateEmployee(employeeExist);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            if (!_employeeRepository.IsExist(id))
            {
                return BadRequest();
            }
            _employeeRepository.Delete(id);
            return NoContent();
        }

    }
}

