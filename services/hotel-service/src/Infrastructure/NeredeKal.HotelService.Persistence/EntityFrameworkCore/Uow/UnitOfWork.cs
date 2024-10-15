using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NeredeKal.HotelService.Persistence.EntityFrameworkCore;
using NeredeKal.SharedKernel.Uow;
using System.Data;

namespace NeredeKal.HotelService.Persistence.EntityFrameworkCore.Uow
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private HotelServiceDbContext Context { get; }

        public UnitOfWork(HotelServiceDbContext context)
        {
            Context = context;
        }

        public async Task<IDbTransaction> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken cancellationToken = default)
        {
            var transaction = await Context.Database.BeginTransactionAsync(isolationLevel, cancellationToken);
            return transaction.GetDbTransaction();
        }

        public ValueTask DisposeAsync()
        {
            return Context.DisposeAsync();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return Context.SaveChangesAsync(cancellationToken);
        }
    }
}
