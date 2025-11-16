using System.ComponentModel.DataAnnotations;
namespace Testapi1.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Student name is required..")]
       
        public string Name { get; set; }

        [Required(ErrorMessage ="Please enter Email..")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int standard { get; set; }




    }
}
