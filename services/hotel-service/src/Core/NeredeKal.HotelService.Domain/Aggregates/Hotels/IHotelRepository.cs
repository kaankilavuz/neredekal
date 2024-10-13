using NeredeKal.SharedKernel.Repositories;

namespace NeredeKal.HotelService.Domain.Aggregates.Hotels
{
    public interface IHotelRepository : IRepository<Hotel, Guid>
    {

    }
}
