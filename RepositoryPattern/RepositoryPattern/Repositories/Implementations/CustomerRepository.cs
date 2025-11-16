using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data;
using RepositoryPattern.Models;

namespace RepositoryPattern.Repositories.Implementations
{
    public class CustomerRepository :ICustomerRepository
    {
        private readonly ECommerceDBContext _context;
        public CustomerRepository(ECommerceDBContext eCommerceDBContext) 
        {
            _context = eCommerceDBContext;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.AsNoTracking().ToListAsync();
        }
        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }
        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);   
        }
        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);    
        }
        public void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Customers.AnyAsync( c => c.CustomerId == id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
