using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace RepositoryPattern.DTOs
{
    public class CustomerDTO
    {
        public int CustomerId {  get; set; }
        [Required]
        public string FullName {  get; set; }
        [Required]
        public string Email { get; set; }   

    }
}
