using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeredeKal.HotelService.Domain.Aggregates.Hotels;
using Newtonsoft.Json;

namespace NeredeKal.HotelService.Persistence.EntityFrameworkCore.EntityTypeConfigurations
{
    public sealed class HotelEntityTypeConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.ToTable("AppHotels");
            builder.HasKey(q => q.Id);
            builder.HasIndex(q => q.Id);

            builder.Property(q => q.Name).IsRequired().HasMaxLength(Hotel.NameMaxLength);
            builder.Property(q => q.ContactName).IsRequired().HasMaxLength(Hotel.ContactNameMaxLength);
            builder.Property(q => q.ContactSurname).IsRequired().HasMaxLength(Hotel.ContactSurnameMaxLength);

            builder.Property(p => p.ExtraProperties)
                .HasConversion(
               v => JsonConvert.SerializeObject(v),
               v => JsonConvert.DeserializeObject<IDictionary<string, object>>(v));
        }
    }
}
