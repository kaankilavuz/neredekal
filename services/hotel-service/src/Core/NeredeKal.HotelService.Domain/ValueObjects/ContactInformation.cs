using NeredeKal.SharedKernel.Entities;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace NeredeKal.HotelService.Domain.ValueObjects
{
    public class ContactInformation : ValueObject
    {
        public const int EmailMaxLength = 100;
        public const int PhoneMaxLength = 15;
        public string Email { get; private set; }
        public string Phone { get; private set; }


        public static ContactInformation Create(string email, string phone)
        {
            return new ContactInformation(email, phone);
        }

        protected ContactInformation() { }

        public ContactInformation(
            [Required] string email,
            [Required] string phone)
        {
            SetEmail(email);
            SetPhone(phone);
        }
        public bool SetEmail(string email)
        {
            Check(email, nameof(Email), EmailMaxLength);
            Email = email;
            return true;
        }
        public bool SetPhone(string phone)
        {
            Check(phone, nameof(Phone), PhoneMaxLength);
            Phone = phone;
            return true;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Email;
            yield return Phone;
        }
    }
}
