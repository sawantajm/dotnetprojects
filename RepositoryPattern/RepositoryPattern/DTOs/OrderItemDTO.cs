namespace RepositoryPattern.DTOs
{
    public class OrderItemDTO
    {
        public int? OrderItemId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal? UnitPrice { get; set; }

        public int Productid { get; set; }

    }
}
