using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data;
using RepositoryPattern.Models;

namespace RepositoryPattern.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ECommerceDBContext _context;
        public CategoryRepository(ECommerceDBContext eCommerceDBContext)
        {
            _context= eCommerceDBContext;
        }
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
           return await _context.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int CategoryId)
        {
            return await _context.Categories.FindAsync(CategoryId);
        }

        public async Task AddAsync(Category category)
        {
             await _context.Categories.AddAsync(category);
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }
        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Categories.AnyAsync(p => p.CategoryId == id);
        }
        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
        public async Task GetAllCategories()
        {
            await _context.Categories.ToListAsync();
        }
    }
}
