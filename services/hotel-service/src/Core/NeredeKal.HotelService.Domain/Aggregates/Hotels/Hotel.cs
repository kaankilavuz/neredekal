using NeredeKal.HotelService.Domain.ValueObjects;
using NeredeKal.SharedKernel.Entities;
using System.ComponentModel.DataAnnotations;

namespace NeredeKal.HotelService.Domain.Aggregates.Hotels
{
    public class Hotel : AggregateRoot<Guid>
    {
        #region constants

        public const int NameMaxLength = 250;
        public const int ContactNameMaxLength = 250;
        public const int ContactSurnameMaxLength = 250;

        #endregion

        public string Name { get; private set; }
        public string ContactName { get; private set; }
        public string ContactSurname { get; private set; }
        public bool IsActive { get; set; }
        public ContactInformation ContactInformation { get; private set; }
        public Location Location { get; private set; }
        protected Hotel()
        {

        }
        public Hotel(
            [Required] string name,
            [Required] string contactName,
            [Required] string contactSurname,
            ContactInformation contactInformation,
            Location location,
            bool isActive = true)
        {
            SetName(name);
            SetContactName(contactName);
            SetContactSurname(contactSurname);
            SetContactInformation(contactInformation);
            SetLocation(location);
            IsActive = isActive;
        }

        public bool SetName(string name)
        {
            Check(name, nameof(Name), NameMaxLength);
            Name = name;
            return true;
        }
        public bool SetContactName(string contactName)
        {
            Check(contactName, nameof(ContactName), ContactNameMaxLength);
            ContactName = contactName;
            return true;
        }
        public bool SetContactSurname(string contactSurname)
        {
            Check(contactSurname, nameof(ContactSurname), ContactSurnameMaxLength);
            ContactSurname = contactSurname;
            return true;
        }
        public bool SetContactInformation(ContactInformation contactInformation)
        {
            if (contactInformation is null)
                throw new NullReferenceException(typeof(ContactInformation).Name);

            ContactInformation = contactInformation;
            return true;
        }

        public bool SetLocation(Location location)
        {
            if (location is null)
                throw new NullReferenceException(typeof(Location).Name);

            Location = location;
            return true;
        }
    }
}
