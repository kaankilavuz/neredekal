using NeredeKal.HotelService.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace NeredeKal.HotelService.Application.Hotels.Commons
{
    public record CreateOrUpdateContactInformationBaseInput
    {
        [Required]
        [MaxLength(ContactInformation.EmailMaxLength)]
        public string Email { get; init; }
        [Required]
        [MaxLength(ContactInformation.PhoneMaxLength)]
        public string Phone { get; init; }
        [Required]
        [MaxLength(Location.CityMaxLength)]
        public string City { get; init; }
        [Required]
        [MaxLength(Location.DistrictMaxLength)]
        public string District { get; init; }
        [Required]
        [MaxLength(Location.AddressMaxLength)]
        public string Address { get; init; }
    }

    public record CreateContactInformationInput : CreateOrUpdateContactInformationBaseInput;
    public record UpdateContactInformationInput : CreateOrUpdateContactInformationBaseInput;
}
