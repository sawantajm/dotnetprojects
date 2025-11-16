using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data;
using RepositoryPattern.Models;

namespace RepositoryPattern.Repositories.Implementations
{
    public class OrderRepository :IOrderRepository
    {
        private readonly ECommerceDBContext _context;
        public OrderRepository(ECommerceDBContext ecommerceDBContext)
        {
            _context = ecommerceDBContext;
        }
        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.orders.AsNoTracking().ToListAsync();
        }
       public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.orders.FindAsync(id);
        }
        public async Task AddAsync(Order order)
        {
            await _context.orders.AddAsync(order);
        }
       public  void Update(Order order)
        {
            _context.orders.Update(order);
        }
        public void Delete(Order order)
        {
            _context.Remove(order);
        }
       public async Task<bool> ExistsAsync(int id)
        {
            return await _context.orders.AnyAsync(O => O.OrderId == id);
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();  
        }
    }
}
