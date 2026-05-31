using DomainDesign.Shared;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DomainDesign.Exceptions;
using System.Runtime.ConstrainedExecution;

namespace DomainDesign.ValueObjects
{
    public class Address : ValueObject<Address>
    {
        private Address() { }

        public Address(string street, string neighborhood, string city, char state, char zipCode)
        {
            var states = ConvertToString(state);
            var zipCodes = ConvertToString(zipCode);

            if (string.IsNullOrWhiteSpace(street) || !Regex.IsMatch(street, @"^[A-Za-zÀ-ÖØ-öø-ÿ0-9\s]+$"))
                throw new InvalidValueObjectException($"Invalid Street: {street}! Please check.");

            if (string.IsNullOrWhiteSpace(neighborhood) || !Regex.IsMatch(neighborhood, @"^[A-Za-zÀ-ÖØ-öø-ÿ\s]+$"))
                throw new InvalidValueObjectException($"Invalid Neighborhood: {neighborhood}! Please check.");

            if (string.IsNullOrWhiteSpace(city) || !Regex.IsMatch(city, @"^[A-Za-zÀ-ÖØ-öø-ÿ\s]+$"))
                throw new InvalidValueObjectException($"Invalid City: {city}! Please check.");

            if (string.IsNullOrWhiteSpace(states) || !Regex.IsMatch(states, @"^(AC|AL|AP|AM|BA|CE|DF|ES|GO|MA|MT|MS|MG|PA|PB|PR|PE|PI|RJ|RN|RS|RO|RR|SC|SP|SE|TO)$"))
                throw new InvalidValueObjectException($"Invalid State: {states}! Please check.");

            if (string.IsNullOrWhiteSpace(zipCodes) || !Regex.IsMatch(zipCodes, @"^\d{5}-?\d{3}$"))
                throw new InvalidValueObjectException($"Invalid CEP: {zipCodes}! Please check.");

            Street = street;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public string Street { get; }
        public string Neighborhood { get; }
        public string City { get; }
        public char State { get; }
        public char ZipCode { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return Neighborhood;
            yield return City;
            yield return State;
            yield return ZipCode;
        }

        private string ConvertToString(char address)
        {
            string addressConvert = ConvertToString(address);
            return addressConvert;
        }
    }
}