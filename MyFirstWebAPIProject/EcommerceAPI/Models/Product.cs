using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Product Name is required")]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage ="Product Category is required")]
        public string Category { get; set; }
        [Range(00.01,10000, ErrorMessage ="Price must be beetween 00.01 to 10000")]
        [Required]
        public decimal Price { get; set; }

        [Range(0,int.MaxValue,ErrorMessage ="Stock can not  be in negative Value")]
        public int Stock { get; set; }


        
    }
}
