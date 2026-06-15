using DomainDesign.Exceptions;
using DomainDesign.Shared;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DomainDesign.ValueObjects
{
    public class Phone : ValueObject<Phone>
    {
        private Phone() { }

        public Phone(string phoneNumber)
        {
            var number = Regex.Replace(phoneNumber, @"\D", "");

            if (string.IsNullOrWhiteSpace(number) || number.Length < 10 || number.Length > 11)
                throw new InvalidValueObjectException($"Invalid Phone: {phoneNumber}");

            if (!Regex.IsMatch(number, @"^\d{10,11}$"))
                throw new InvalidValueObjectException($"Invalid Phone format: {phoneNumber}");

            PhoneNumber = phoneNumber.Trim();
        }

        public string PhoneNumber { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PhoneNumber;
        }
    }
}
