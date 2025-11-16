using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.DTOs
{
    public class CustomerRegistrationDTO
    {
        [Required(ErrorMessage = "Customer Name Is Required.")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Email Is Required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100)]
        public string password { get; set; }
        
    }
}
