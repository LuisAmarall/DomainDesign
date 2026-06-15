using DomainDesign.Exceptions;
using DomainDesign.Shared;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DomainDesign.ValueObjects
{
    public class Password : ValueObject<Password>
    {
        private Password() { }

        public Password(string hashedKey)
        {
            if (string.IsNullOrWhiteSpace(hashedKey))
                throw new InvalidValueObjectException("Password cannot be empty");

            Key = hashedKey;
        }

        public string Key { get; }

        public static Password Create(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new RequiredFieldException("Password");

            if (password.Length < 8)
                throw new InvalidValueObjectException("Password must have at least 8 characters");

            if (!Regex.IsMatch(password, @"^[a-zA-Z0-9_@.$#!]+$"))
                throw new InvalidValueObjectException("Password contains invalid characters");

            var hashedKey = HashPassword(password);
            return new Password(hashedKey);
        }

        private static string HashPassword(string password)
        {
            return password; 
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Key;
        }
    }
}