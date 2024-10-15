using NeredeKal.HotelService.Domain.Aggregates.Hotels;
using NeredeKal.HotelService.Persistence.EntityFrameworkCore;
using NeredeKal.HotelService.Persistence.EntityFrameworkCore.Repositories;

namespace NeredeKal.HotelService.Persistence.EntityFrameworkCore.Repositories.Hotels
{
    public sealed class EfCoreHotelRepository : EfCoreRepositoryBase<Hotel, Guid>, IHotelRepository
    {
        public EfCoreHotelRepository(HotelServiceDbContext context) : base(context) { }
    }
}
