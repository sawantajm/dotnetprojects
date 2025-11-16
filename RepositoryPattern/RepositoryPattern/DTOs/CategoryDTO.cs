using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern.DTOs
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Category name is required.")]
        public string Name { get; set; }

        public string? Description { get; set; }    
    }
}
