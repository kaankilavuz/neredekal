using Microsoft.EntityFrameworkCore;
using NeredeKal.HotelService.Domain.Aggregates.Hotels;
using NeredeKal.SharedKernel.Extensions;

namespace NeredeKal.HotelService.Persistence.EntityFrameworkCore.Repositories.Hotels
{
    public sealed class EfCoreHotelRepository : EfCoreRepositoryBase<Hotel, Guid>, IHotelRepository
    {
        public EfCoreHotelRepository(HotelServiceDbContext context) : base(context) { }

        public Task<int> GetCountAsync(string filter, CancellationToken cancellationToken)
        {
            var query = ApplyFilter(AsQueryable(), filter);
            var totalCount = query.CountAsync(cancellationToken);
            return totalCount;
        }

        public async Task<List<Hotel>> GetPagedListAsync(string filter, int skipCount, int maxResultCount, CancellationToken cancellationToken)
        {
            var query = ApplyFilter(AsQueryable(), filter);
            query = query.PageBy(skipCount, maxResultCount);

            var hotels = await query.ToListAsync(cancellationToken);
            return hotels;
        }

        private IQueryable<Hotel> ApplyFilter(IQueryable<Hotel> query, string filter)
        {
            return query.WhereIf(!string.IsNullOrWhiteSpace(filter),
               q => q.Name.Contains(filter)
               || q.ContactName.Contains(filter)
               || q.ContactSurname.Contains(filter));
        }
    }
}
