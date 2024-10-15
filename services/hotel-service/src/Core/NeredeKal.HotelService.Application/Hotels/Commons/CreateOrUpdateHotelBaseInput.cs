using NeredeKal.HotelService.Domain.Aggregates.Hotels;
using System.ComponentModel.DataAnnotations;

namespace NeredeKal.HotelService.Application.Hotels.Commons
{
    public record CreateOrUpdateHotelBaseInput
    {
        [Required]
        [MaxLength(Hotel.NameMaxLength)]
        public string Name { get; init; }
        [Required]
        [MaxLength(Hotel.ContactNameMaxLength)]
        public string ContactName { get; init; }
        [Required]
        [MaxLength(Hotel.ContactSurnameMaxLength)]
        public string ContactSurname { get; init; }
        public bool IsActive { get; init; } = true;
    }
}
