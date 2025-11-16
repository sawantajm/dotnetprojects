using EcommerceAPI.Data;
using EcommerceAPI.DTOs;
using EcommerceAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private ECommerceDbContext _context;

        public OrdersController(ECommerceDbContext eCommerceDbContext)
        {
            _context = eCommerceDbContext;
        }

        [HttpPost("CreateOrder")]
        public async Task<ActionResult<Order>> CreateOrders([FromBody] OrderDTO orderDTO)
        {
            var  Customer = await _context.Orders.FindAsync(orderDTO.CustomerId);
            if (Customer ==null)
            {
                return BadRequest("Customer does not exist...");
            }
            var Order = new Order
            {
                CustomerId = orderDTO.CustomerId,
                Orderdate = DateTime.Now,
                Orderstatus = "Processing",
                OrderAmount = 0,
                OrderItems = new List<OrderItem>()

            };

            decimal TotalAmount = 0;

            foreach(var item in orderDTO.Items)
            {
                var Product = await _context.Products.FindAsync(item.ProductId);

                if(Product ==null)
                {
                    return BadRequest($"Product ID {item.ProductId} does not exist...");
                }
                if(Product.Stock < item.Quantity)
                {
                    return BadRequest($"Insufficient stock for the product {Product.Name} ");
                }
                //deduct Stock
                Product.Stock -= item.Quantity;

                //Calculate Total Amount 
                TotalAmount += item.Quantity * Product.Price;

                //Create Order Item

                var OrderItem = new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = Product.Price,

                };

                Order.OrderItems.Add(OrderItem);
            }
            Order.OrderAmount = TotalAmount;
            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrderById), new { id = Order.Id }, Order);
           

        }

        [HttpGet("GetOrderById/{id}")]
        public async Task<ActionResult<Order>> GetOrderById (int id)
        {
            var Order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(OI => OI.Product)
                .Include(o => o.Customer)
                .FirstOrDefaultAsync( o => o.Id ==id);

            if(Order ==null)
            {
                return NotFound();
            }
            return Ok(Order);

        }


    }
}
