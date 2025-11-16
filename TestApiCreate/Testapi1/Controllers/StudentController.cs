using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Testapi1.Data;
using Testapi1.Models;

namespace Testapi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDBContext _dbcontext;

        public StudentController(StudentDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public async Task<ActionResult <IEnumerable<Student>>> GetAllStudent ()
        {
            try
            {
                var AllStudent = await _dbcontext.Students.ToListAsync();

                if (AllStudent == null)
                {
                    return NotFound("Data not Available...");
                }
                return Ok(AllStudent);
            }catch (Exception ex)
            {
                return Ok(ex.ToString());
            }
            
        }
        [HttpPost("CreateNewStudent")]
        
        public async Task<ActionResult<Student>> CreateStudent([FromBody] Student student)
        {
            var StudentExist = await _dbcontext.Students.FirstOrDefaultAsync(X => X.Email == student.Email);

            if(StudentExist != null)
            {
                return BadRequest("Student is already Present..");
            }

           await _dbcontext.Students.AddAsync(student);

            await _dbcontext.SaveChangesAsync();
            return Ok("Data saved sucessfully..");
            
        }

        [HttpPut ("{id}")]

        public async Task<ActionResult<Student>> UpdateData(int id, [FromBody] Student st)
        {
            var StudentExist = await _dbcontext.Students.FindAsync(id);
            if(StudentExist == null)
            {
                return BadRequest("Data Not found...");
            }


            StudentExist.Name = st.Name;
            StudentExist.Email = st.Email;
            StudentExist.Age = st.Age;
            StudentExist.standard = st.standard;
            
            


            //await _dbcontext.Students.(StudentExist);
            await _dbcontext.SaveChangesAsync();
            return Ok("Data saved sucessfully..");

        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteData(int id)
        {
            var StudentExist = await _dbcontext.Students.FindAsync(id);

            if (StudentExist == null)
            {
                return BadRequest("Data Not found...");
            }
            _dbcontext.Students.Remove(StudentExist);
            await _dbcontext.SaveChangesAsync();
            return Ok("Data Deleted sucessfully..");
        }
    }
}
