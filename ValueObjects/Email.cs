using DomainDesign.Shared;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DomainDesign.Exceptions;

namespace DomainDesign.ValueObjects
{
    public class Email : ValueObject<Email>
    {
        private Email() { }

        public Email(string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(emailAddress) || !Regex.IsMatch(emailAddress, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new InvalidValueObjectException($"Invalid E-mail: {emailAddress}! Please check.");

            EmailAddress = emailAddress.Trim();
        }

        public string EmailAddress { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return EmailAddress;
        }
    }
}
