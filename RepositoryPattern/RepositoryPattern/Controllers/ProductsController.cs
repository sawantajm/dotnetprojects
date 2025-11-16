using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using RepositoryPattern.DTOs;
using RepositoryPattern.Models;
using RepositoryPattern.Repositories;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductsController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
       
        public async Task<IActionResult> GetAllProduct()
        {
            var AllProdcuts = await _productRepository.GetAllAsync();
            if(AllProdcuts == null)
            {
                return BadRequest();
            }
            var productDto = AllProdcuts.Select(p => new ProductDTO
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                CategoryId=p.CategoryId,
                CategoryName =p.Category?.Name
            });
            return Ok(productDto);
        }

        [HttpGet("{id}")]

       public async  Task<IActionResult> GetProductById(int id)
        {
            var GetProductDeatails = await _productRepository.GetByIdAsync(id);
            if (GetProductDeatails == null)
            {
                return BadRequest();
            }
            var productDto = new ProductDTO
            {
                ProductId = GetProductDeatails.ProductId,
                Name = GetProductDeatails.Name,
                Description = GetProductDeatails.Description,
                Price = GetProductDeatails.Price,
                CategoryId = GetProductDeatails.CategoryId,
                CategoryName = GetProductDeatails.Category?.Name
            };
            return Ok(productDto);
       }

        [HttpPost]

        public async Task<IActionResult> CreateNewProduct( [FromBody] ProductDTO productDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            bool IsCategoryExists = await _productRepository.ExistsAsync(productDTO.CategoryId);

            if(!IsCategoryExists)
            {
                return BadRequest($"Invalid category: {productDTO.CategoryName} ");
            }

            var product = new Product
            {
                Name = productDTO.Name,
                Description = productDTO.Description,
                Price = Convert.ToDecimal(productDTO.Price),
                CategoryId =productDTO.CategoryId

            };

            await _productRepository.AddAsync(product);
            await _productRepository.SaveAsync();

            product.ProductId = productDTO.ProductId;
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductDetails(int id, [FromBody] ProductDTO productDTO)
        {
            if(id != productDTO.ProductId )
            {
                return BadRequest();
            }
            if(ModelState.IsValid)
            {
                return BadRequest();
            }

            var ExistingProduct = await _productRepository.GetByIdAsync(id);
            if(ExistingProduct == null)
            {
                return NotFound();
            }

            bool IsCategoryExists =  await _categoryRepository.ExistsAsync(productDTO.CategoryId);
            if(!IsCategoryExists)
            {
                return NotFound();
            }
            ExistingProduct.Name = productDTO.Name;
            ExistingProduct.Description = productDTO.Description;
            ExistingProduct.Price = Convert.ToDecimal(productDTO.Price);
            ExistingProduct.CategoryId = productDTO.CategoryId;

            _productRepository.Update(ExistingProduct);
            await _productRepository.SaveAsync();


            return Ok();
        }
    }
}
