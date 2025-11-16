namespace RepositoryPattern.DTOs
{
    public class OrderDTO
    {
        public int? OrderId { get; set; }

        public DateTime Orderdate { get; set; }
        public int CustomerId { get; set; } 

        public string? CustomerName { get; set; }   

        public decimal OrderAmount { get; set; }
        public List<OrderItemDTO> OrderItem { get; set; } = new();
    }
}
