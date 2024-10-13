using Microsoft.Extensions.DependencyInjection;
using NeredeKal.HotelService.Domain.Aggregates.Hotels;
using NeredeKal.HotelService.Persistence.EntityFrameworkCore;
using NeredeKal.HotelService.Persistence.EntityFrameworkCore.Repositories;
using NeredeKal.HotelService.Persistence.EntityFrameworkCore.Repositories.Hotels;
using NeredeKal.HotelService.Persistence.EntityFrameworkCore.Uow;
using NeredeKal.SharedKernel.Repositories;
using NeredeKal.SharedKernel.Uow;

namespace NeredeKal.HotelService.Persistence.EntityFrameworkCore.DIs
{
    public static class Dependencies
    {
        public static IServiceCollection AddEntityFrameworkCore(this IServiceCollection services) => services.AddDbContext<HotelServiceDbContext>(ServiceLifetime.Scoped);
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services) => services.AddScoped<IUnitOfWork, UnitOfWork>();
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IHotelRepository, EfCoreHotelRepository>();
            return services;
        }
    }
}
