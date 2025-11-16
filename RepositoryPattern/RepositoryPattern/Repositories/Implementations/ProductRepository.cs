using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data;
using RepositoryPattern.Models;

namespace RepositoryPattern.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly ECommerceDBContext _context;
        public ProductRepository(ECommerceDBContext eCommerceDBContext)
        { 
            _context = eCommerceDBContext;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        public async Task AddAsync(Product product)
        {
             await _context.Products.AddAsync(product); 
        }
        public void Update(Product product)
        {
            _context.Products.Update(product);  
        }
        public void Delete(Product product)
        {
            _context.Remove(product);
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Products.AnyAsync(P => P.ProductId ==id);
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
