using NeredeKal.HotelService.Domain.ValueObjects;

namespace NeredeKal.HotelService.Domain.Aggregates.Hotels
{
    public class HotelBuilder
    {
        private string _name;
        private string _contactName;
        private string _contactSurname;
        private Location _location;
        private ContactInformation _contactInformation;
        private bool _isActive;

        public HotelBuilder WithLocation(string city, string district, string address)
        {
            _location = Location.Create(city, district, address);
            return this;
        }
        public HotelBuilder WithContactInformation(string email, string phone)
        {
            if (_location == null)
                throw new NullReferenceException(nameof(Location));

            _contactInformation = ContactInformation.Create(email, phone);
            return this;
        }

        public HotelBuilder WithHotelDetails(string name, string contactName, string contactSurname, bool isActive = true)
        {
            if (_contactInformation == null)
                throw new NullReferenceException(nameof(ContactInformation));

            _name = name;
            _contactName = contactName;
            _contactSurname = contactSurname;
            _isActive = isActive;
            return this;
        }

        public Hotel Build()
        {
            return new Hotel(_name, _contactName, _contactSurname, _contactInformation, _location, _isActive);
        }
    }
}
