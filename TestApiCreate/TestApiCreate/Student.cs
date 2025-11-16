using System.ComponentModel.DataAnnotations;

namespace TestApiCreate
{
    public class Student
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string email { get; set; }

        [Required(ErrorMessage = "Standard is required...")]
        public int standard { get; set; }
    }
}
