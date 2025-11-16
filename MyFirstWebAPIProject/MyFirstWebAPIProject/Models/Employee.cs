using System.ComponentModel.DataAnnotations;
namespace MyFirstWebAPIProject.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Position { get; set; }
        [Range(1,100)]
        public int Age { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }

    }
}
