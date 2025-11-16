using System.Data;
using Microsoft.EntityFrameworkCore.Storage;
using RepositoryPattern.Repositories;

namespace RepositoryPattern.UOW
{
    public interface IUnitOfWork:IDisposable
    {
         ICategoryRepository Categories { get; }
         IOrderRepository Orders { get; }
         IProductRepository Products { get; }
         ICustomerRepository Customers { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();

        Task<IDbContextTransaction> BeginTransactionAsync();
        
        Task CommiteAsync();

        Task RollbackAsync();
    }
}
