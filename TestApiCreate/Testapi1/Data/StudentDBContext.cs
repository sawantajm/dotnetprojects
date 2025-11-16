using Microsoft.EntityFrameworkCore;
using Testapi1.Models;

namespace Testapi1.Data
{
    public class StudentDBContext : DbContext
    {

        public StudentDBContext(DbContextOptions<StudentDBContext> options) : base (options)
        {

        }

        public DbSet<Student> Students { get; set; }
           
    }
}
