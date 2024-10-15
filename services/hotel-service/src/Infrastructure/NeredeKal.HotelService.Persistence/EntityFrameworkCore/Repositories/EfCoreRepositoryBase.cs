using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NeredeKal.HotelService.Persistence.EntityFrameworkCore;
using NeredeKal.SharedKernel.Entities;
using NeredeKal.SharedKernel.Repositories;

namespace NeredeKal.HotelService.Persistence.EntityFrameworkCore.Repositories
{
    public abstract class EfCoreRepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : struct
    {
        protected HotelServiceDbContext Context { get; }

        protected EfCoreRepositoryBase(HotelServiceDbContext context)
        {
            Context = context;
        }
        public IQueryable<TEntity> AsQueryable() => Context.Set<TEntity>().AsQueryable();
        public async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken)
        {
            var entityEntry = await Context.AddAsync(entity, cancellationToken);
            return entityEntry.Entity;
        }
        public async Task<TEntity> ExecuteDeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await Context.Set<TEntity>().Where(w => w.Id.Equals(entity.Id)).ExecuteDeleteAsync(cancellationToken);
            return entity;
        }
        public async Task<TEntity?> FindAsync(TKey key, CancellationToken cancellationToken)
        {
            return await Context.Set<TEntity>().FindAsync(key, cancellationToken);
        }
    }
}
