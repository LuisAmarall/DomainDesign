using DomainDesign.Shared;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DomainDesign.Exceptions;

namespace DomainDesign.ValueObjects
{
    public class Phone : ValueObject<Phone>
    {
        private Phone() { }

        public Phone(char phoneNumber)
        {
            var number = ConvertToString(phoneNumber);

            if (string.IsNullOrWhiteSpace(number) || !Regex.IsMatch(number, @"^\(\d{3}\)\d{5}\-\d{4}$"))
                throw new InvalidValueObjectException($"Invalid Phone: {number}! Please check.");
            
            PhoneNumber = phoneNumber;
        }

        public char PhoneNumber { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PhoneNumber;
        }

        private string ConvertToString(char phone)
        {
            string phoneConvert = ConvertToString(phone);
            return phoneConvert;
        }
    }
}
