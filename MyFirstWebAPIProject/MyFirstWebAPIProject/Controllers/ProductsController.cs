using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebAPIProject.Models;

namespace MyFirstWebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private List<Product> _products = new List<Product>
        {
            new Product { Id =1 ,Name ="Laptop", Price=1000.00m ,Category="Electronics"},
            new Product{ Id =2 ,Name ="Desktop", Price=2000.00m ,Category="Electronics" },
            new Product {Id =3 ,Name ="Mobile", Price=300.00m ,Category="Electronics" }
        };
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(_products);
        }
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound(new { Message = $"Product with ID {id} not found." });
            }
            return Ok(product);
        }
        [HttpPost]
        public ActionResult<Product> PostProduct([FromBody] Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);

            return CreatedAtAction(nameof(GetProduct), new { Id = product.Id }, product);
        }
        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, [FromBody] Product updateprodut)
        {
            if (id != updateprodut.Id)
            {
                return BadRequest(new { Message = "ID Mismatch Betweeen Rout and body" });
            }
            var existingProduct = _products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound(new { messgae = $"Product with ID {id} Not Found..." });

            }
            existingProduct.Name = updateprodut.Name;
            existingProduct.Price = updateprodut.Price;
            existingProduct.Category = updateprodut.Category;
            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id ==id);
            if(product == null)
            {
                return NotFound(new { message = $"product with id {id} not found.." });
            }
            _products.Remove(product);

            return NoContent();
        }

    } 
}

