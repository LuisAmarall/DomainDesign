using DomainDesign.Shared;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DomainDesign.Exceptions;

namespace DomainDesign.ValueObjects
{
    public class Password : ValueObject<Password>
    {
        private Password() { }

        public Password(string key)
        {
            if (string.IsNullOrWhiteSpace(key) || !Regex.IsMatch(key, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new InvalidValueObjectException($"Invalid Email: {key}! Please check.");
            
            Key = key.Trim();
        }

        public string Key { get; }

        public static Password Create(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new RequiredFieldException($"{key}: Please note that the password field does not allow null or empty values.");

            var hashedKey = HashPassword(key);

            return new Password(hashedKey);
        }

        private static string HashPassword(string key)
        {
            return key;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Key;
        }
    }
}
