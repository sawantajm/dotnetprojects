using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EcommerceAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public DateTime Orderdate { get; set; }

        [Required]
        public int CustomerId { get; set; }
        [JsonIgnore]
        public Customer Customer { get; set; }

        [Required]
        public string Orderstatus { get; set; }
        [Required]
        public decimal OrderAmount { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
