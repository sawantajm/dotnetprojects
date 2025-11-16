using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RepositoryPattern.Data;
using RepositoryPattern.Models;
using RepositoryPattern.Repositories;
using RepositoryPattern.Repositories.Implementations;

namespace RepositoryPattern.UOW
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly ECommerceDBContext _dbContext;
        private IDbContextTransaction? _transaction;

        public ICategoryRepository Categories { get;  }
        public IOrderRepository Orders { get;}
        public IProductRepository Products { get; }
        public ICustomerRepository Customers { get; }   

        public UnitOfWork(ECommerceDBContext dBContext)
        {
            _dbContext = dBContext;
            Categories = new CategoryRepository(_dbContext);
            Products = new ProductRepository(_dbContext);
            Orders = new OrderRepository(_dbContext);
            Customers = new CustomerRepository(_dbContext);
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public Task <int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_transaction != null)
            {
                return _transaction;
            }

            _transaction = await _dbContext.Database.BeginTransactionAsync();
            return _transaction;
        }

        public async Task CommiteAsync()
        {
            if( _transaction ==null)
            {
                throw new InvalidOperationException("No Active Transaction to Commit..");
            }
            await _dbContext.SaveChangesAsync();
            await _transaction.CommitAsync();
        }
        public async Task RollbackAsync()
        {
            if (_transaction == null)
                throw new InvalidOperationException("No active transaction to rollback.");
            // Undo all changes made within the transaction scope
            await _transaction.RollbackAsync();
            // Dispose transaction resources and clear _transaction field
            await DisposeTransactionAsync();
        }
        // Helper method to asynchronously dispose the transaction and clear reference
        private async Task DisposeTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }
        // Dispose method to clean up managed resources
        public void Dispose()
        {
            // Dispose transaction if active
            _transaction?.Dispose();
            // Dispose DbContext
            _dbContext.Dispose();
        }
    }
}
