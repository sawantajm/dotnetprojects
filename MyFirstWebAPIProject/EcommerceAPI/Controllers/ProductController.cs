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
    public class ProductController : ControllerBase
    {
        private readonly ECommerceDbContext _context;

        public ProductController(ECommerceDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetProducts")]

        public async Task<ActionResult<IEnumerable<Product>>> GetProducts([FromQuery] string? name, [FromQuery] string? Category, [FromQuery] decimal? MinPrice, decimal? MaxPrice)
        {
            
            try
            {
                var Query = _context.Products.AsQueryable();
                if (!string.IsNullOrEmpty(name))
                {
                    Query = Query.Where(x => x.Name.Contains(name));
                }
                if (!string.IsNullOrEmpty(Category))
                {
                    Query = Query.Where(x => x.Category.Contains(Category));
                }
                if (MinPrice.HasValue)
                {
                    Query = Query.Where(x => x.Price >= MinPrice.Value);
                }
                if (MaxPrice.HasValue)
                {
                    Query = Query.Where(x => x.Price <= MaxPrice.Value);
                }

                var products = await _context.Products.ToListAsync();
                return Ok(products);

            }
            catch(Exception ex)
            {
                return Ok("Product in not available...");
            }
           
        }

       [HttpGet("{id}")]

       public async Task<ActionResult<IEnumerable<Product>>> GetProdutsById([FromRoute] int id)
        {
            var Product = await _context.Products.FindAsync(id);

            if(Product == null)
            {
                return BadRequest();
            }

            return Ok(Product);
        }

        [HttpPost("AddProducts")]
        public async Task<ActionResult<Product>> AddProducts([FromBody] ProductCreateDTO productCreateDTO)
        {
            var product = new Product
            {
                Name = productCreateDTO.Name,
                Category = productCreateDTO.Category,
                Description = productCreateDTO.Description,
                Price = productCreateDTO.Price,
                Stock = productCreateDTO.Stock
            };

           await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return Ok("Data Saved sucessfully...");
        }

        [HttpPut("UpdateProductPrice/{id}")]
        
        public async Task<ActionResult<Product>> UpdateProductPrice([FromRoute] int id, [FromQuery] decimal price)
        {
            var FindProduct = await _context.Products.FindAsync(id);

            if(FindProduct ==null)
            {
                return BadRequest("Product is not available Update Faild");
            }
            FindProduct.Price = price;
            await _context.SaveChangesAsync();
            return Ok("Data Updated successfully..");

        }

        [HttpGet("Paged")]
        public async Task<ActionResult<Product>> GetPagging([FromQuery] int PageNumber =1, [FromQuery] int pageSize=5)
        {
            var product = await _context.Products
                                                .Skip((PageNumber - 1) * pageSize)
                                                .Take(pageSize)
                                                .AsNoTracking()
                                                .ToListAsync();

            return Ok(product);
        }

        //Upload Image

        [HttpPost("{id}/ImageUpload")]

        public async Task<ActionResult<Product>> UploadProductImage([FromRoute] int id, IFormFile file)
        {
            if(file== null || file.Length == 0)
            {
                return BadRequest("Please select the Image...");
            }
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            var fileName = Path.GetFileName(file.FileName);
            return Ok(new { Message = "Image uploaded successfully.", FileName = fileName });
        }
        
    }
}
