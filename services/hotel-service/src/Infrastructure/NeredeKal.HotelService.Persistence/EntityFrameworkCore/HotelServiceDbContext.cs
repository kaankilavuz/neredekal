using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NeredeKal.HotelService.Persistence.EntityFrameworkCore.Interceptors;

namespace NeredeKal.HotelService.Persistence.EntityFrameworkCore
{
    public sealed class HotelServiceDbContext : DbContext
    {
        private IConfiguration Configuration { get; }
        public HotelServiceDbContext(
            DbContextOptions<HotelServiceDbContext> options,
            IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("Default")).AddInterceptors(new SaveChangesInterceptor());
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HotelServiceDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
