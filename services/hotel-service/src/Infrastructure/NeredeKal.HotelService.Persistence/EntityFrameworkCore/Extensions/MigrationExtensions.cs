using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace NeredeKal.HotelService.Persistence.EntityFrameworkCore.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope serviceScope = app.ApplicationServices.CreateScope();
            using HotelServiceDbContext context = serviceScope.ServiceProvider.GetRequiredService<HotelServiceDbContext>();
            context.Database.Migrate();
        }
    }
}
