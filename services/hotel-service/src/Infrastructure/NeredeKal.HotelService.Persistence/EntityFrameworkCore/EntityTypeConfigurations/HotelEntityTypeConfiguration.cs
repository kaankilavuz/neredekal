using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeredeKal.HotelService.Domain.Aggregates.Hotels;
using NeredeKal.HotelService.Domain.ValueObjects;
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

            builder.OwnsOne(o => o.ContactInformation, contactAct =>
            {
                contactAct.Property(p => p.Email).IsRequired().HasMaxLength(ContactInformation.EmailMaxLength);
                contactAct.Property(p => p.Phone).IsRequired().HasMaxLength(ContactInformation.PhoneMaxLength);
            });

            builder.OwnsOne(o => o.Location, locationAct =>
            {
                locationAct.Property(p => p.City).IsRequired().HasMaxLength(Location.CityMaxLength);
                locationAct.Property(p => p.District).IsRequired().HasMaxLength(Location.DistrictMaxLength);
                locationAct.Property(p => p.Address).IsRequired().HasMaxLength(Location.AddressMaxLength);
            });
        }
    }
}
