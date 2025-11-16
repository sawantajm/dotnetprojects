using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.DTOs;
using RepositoryPattern.Models;
using RepositoryPattern.Repositories;
using RepositoryPattern.Repositories.Implementations;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryrepository;

        public CategoriesController(ICategoryRepository categoryrepository)
        {
            _categoryrepository = categoryrepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryrepository.GetAllAsync();
            var CategoryDto = categories.Select(C => new CategoryDTO
            {
                Name = C.Name,
                CategoryId = C.CategoryId,
                Description = C.Description
            });
            return Ok(CategoryDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
            {
            var categoryById = await _categoryrepository.GetByIdAsync(id);

            if (categoryById == null)
            {
                return BadRequest(" Not found");
            }
            var categoryByIdDto = new CategoryDTO
            {
                Name = categoryById.Name,
                CategoryId = categoryById.CategoryId,
                Description = categoryById.Description
            };

            return Ok(categoryByIdDto);

        }

        [HttpPost]
        public async Task<IActionResult> CreateNewCategory([FromBody] CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("");

            }
            var category = new Category
            {
                Name = categoryDTO.Name,
                Description = categoryDTO.Description

            };
            await _categoryrepository.AddAsync(category);
            await _categoryrepository.SaveAsync();
            categoryDTO.CategoryId = category.CategoryId;
            return Ok(categoryDTO);
        }
    }
}
