using AS.FOS.Order.Application.Interfaces;
using AS.FOS.Order.Persistence.Context;

namespace AS.FOS.Order.Persistence
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly OrderDBContext _dbContext;

        public UnitOfWork(OrderDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task BeginTransactionAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task CommitTransactionAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task RollbackTransactionAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveChangesAsync(CancellationToken token)
        {
            return await _dbContext.SaveChangesAsync(token);
        }
    }
}
