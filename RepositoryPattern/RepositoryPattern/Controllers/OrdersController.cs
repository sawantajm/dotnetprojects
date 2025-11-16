using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.DTOs;
using RepositoryPattern.Models;
using RepositoryPattern.Repositories;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _proudctRepository;

        public OrdersController(IOrderRepository orderRepository, ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _proudctRepository = productRepository;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllOrders()
        {
            var orderdetails = await _orderRepository.GetAllAsync();
            var OrderDto = orderdetails.Select(O => new OrderDTO
            {
                OrderId = O.OrderId,
                Orderdate = O.OrderDate,
                CustomerId = O.CustomerId,
                CustomerName = O.Customer?.FullName,
                OrderAmount = O.OrderAmount,
                OrderItem = O.OrderItems.Select(order => new OrderItemDTO
                {   OrderItemId = order.OrderItemId,
                    Productid = order.ProductId,
                    ProductName = order.Product?.Name,
                    Quantity = order.Quantity,
                    UnitPrice = order.UnitPrice
                }).ToList() ?? new List<OrderItemDTO>()
            });

            return Ok(OrderDto);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var orderdetails = await _orderRepository.GetByIdAsync(id);

            if(orderdetails == null)
            {
                return NotFound("Order not longer...");
            }

            var orderDto = new OrderDTO
            {
                OrderId = orderdetails.OrderId,
                Orderdate = orderdetails.OrderDate,
                CustomerId = orderdetails.CustomerId,
                CustomerName = orderdetails.Customer?.FullName,
                OrderAmount = orderdetails.OrderAmount,
                OrderItem = orderdetails.OrderItems.Select(order => new OrderItemDTO
                {
                    OrderItemId = order.OrderItemId,
                    Productid = order.ProductId,
                    ProductName = order.Product?.Name,
                    Quantity = order.Quantity,
                    UnitPrice = order.UnitPrice
                }).ToList() ?? new List<OrderItemDTO>()
            };

            return Ok(orderDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewOrder([FromBody] OrderDTO orderDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool IscustomerExist = await _customerRepository.ExistsAsync(orderDto.CustomerId);

            if(!IscustomerExist)
            {
                return BadRequest("Invalid Customer..");
            }

            foreach(var item in orderDto.OrderItem)
            {
                bool IsproductExist = await _proudctRepository.ExistsAsync(item.Productid);
                if (!IsproductExist)
                    return BadRequest($"Invalid ProductId: {item.Productid}");
            }
            var newOrder = new Order
            {
                CustomerId = orderDto.CustomerId,
                OrderDate = DateTime.UtcNow,
                OrderAmount = Convert.ToDecimal(orderDto.OrderItem.Sum(i => i.Quantity * i.UnitPrice)),
                OrderItems = orderDto.OrderItem.Select(o => new OrderItem 
                {
                    ProductId = o.Productid,
                    Quantity =o.Quantity,
                    UnitPrice = Convert.ToDecimal(o.UnitPrice)    
                }).ToList()

            };
            await _orderRepository.AddAsync(newOrder);
            await _orderRepository.SaveAsync();

            orderDto.OrderId = newOrder.OrderId;
            orderDto.Orderdate = newOrder.OrderDate;

            return Ok(orderDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrders(int id, [FromBody] OrderDTO orderDTO)
        {
            if(id != orderDTO.OrderId)
            {
                return BadRequest("ID MisMatch");
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existing = await _orderRepository.GetByIdAsync(id);       
            
            if(existing == null)
            {
                return NotFound();
            }
            bool IsCustomerExisting = await _customerRepository.ExistsAsync(orderDTO.CustomerId);
            if(!IsCustomerExisting)
            {
                return NotFound($"Invalid Customer{orderDTO.CustomerName}");
            }

            foreach(var item in orderDTO.OrderItem)
            {
                bool IsProducExist = await _proudctRepository.ExistsAsync(item.Productid);
                if(!IsProducExist)
                {
                    return NotFound($"Invalid Product{item.ProductName}");
                }
            }

            existing.CustomerId = orderDTO.CustomerId;
            existing.OrderDate = orderDTO.Orderdate;
            existing.OrderAmount = Convert.ToDecimal(orderDTO.OrderItem.Sum(i => i.Quantity * i.UnitPrice));

            // Update OrderItems: Clear existing and add new (simplified)
            existing.OrderItems.Clear();
            existing.OrderItems = orderDTO.OrderItem.Select(i => new OrderItem
            {
                ProductId = i.Productid,
                Quantity = i.Quantity,
                UnitPrice = Convert.ToDecimal(i.UnitPrice)
            }).ToList();
            _orderRepository.Update(existing);
            await _orderRepository.SaveAsync();

            return Ok();

        }
    }
}
