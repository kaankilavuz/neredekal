using NeredeKal.SharedKernel.Repositories;

namespace NeredeKal.HotelService.Domain.Aggregates.Hotels
{
    public interface IHotelRepository : IRepository<Hotel, Guid>
    {
        Task<List<Hotel>> GetPagedListAsync(string filter, int skipCount, int maxResultCount, CancellationToken cancellationToken);
        Task<int> GetCountAsync(string filter, CancellationToken cancellationToken);
    }
}
