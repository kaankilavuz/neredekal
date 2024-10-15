using NeredeKal.SharedKernel.Entities;
using System.ComponentModel.DataAnnotations;

namespace NeredeKal.HotelService.Domain.ValueObjects
{
    public class Location : ValueObject
    {
        public const int CityMaxLength = 100;
        public const int DistrictMaxLength = 100;
        public const int AddressMaxLength = 300;

        public string City { get; private set; }
        public string District { get; private set; }
        public string Address { get; private set; }
        protected Location() { }
        public static Location Create(string city, string district, string address)
        {
            return new Location(city, district, address);
        }


        public Location(
            [Required] string city,
            [Required] string district,
            [Required] string address)
        {
            SetCity(city);
            SetDistrict(district);
            SetAddress(address);
        }

        public bool SetCity(string city)
        {
            Check(city, nameof(City), CityMaxLength);
            City = city;
            return true;
        }
        public bool SetDistrict(string district)
        {
            Check(district, nameof(District), DistrictMaxLength);
            District = district;
            return true;
        }
        public bool SetAddress(string address)
        {
            Check(address, nameof(Address), AddressMaxLength);
            Address = address;
            return true;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return City;
            yield return District;
            yield return Address;
        }
    }
}
