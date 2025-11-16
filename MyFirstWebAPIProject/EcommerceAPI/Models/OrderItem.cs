using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }
        [Required]
        public int ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
        [Range(1,1000, ErrorMessage ="Quantity must be between 1 to 1000")]
        public int Quantity { get; set; }
        [Range(00.1, double.MaxValue, ErrorMessage = "Price can not be negative")]
        public decimal UnitPrice { get; set; }

    }
}
