using NeredeKal.SharedKernel.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NeredeKal.SharedKernel.Repositories
{
    public interface IRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : struct
    {
        IQueryable<TEntity> AsQueryable();
        Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity?> FindAsync(TKey key, CancellationToken cancellationToken);
    }
}
