using DomainDesign.Exceptions;
using DomainDesign.Shared;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DomainDesign.ValueObjects
{
    public class Address : ValueObject<Address>
    {
        private Address() { }

        public Address(string street, string neighborhood, string city, string state, string zipCode)
        {
            if (string.IsNullOrWhiteSpace(street) || !Regex.IsMatch(street, @"^[A-Za-zÀ-ÖØ-öø-ÿ0-9\s-]+$"))
                throw new InvalidValueObjectException($"Invalid Street: {street}");

            if (string.IsNullOrWhiteSpace(neighborhood) || !Regex.IsMatch(neighborhood, @"^[A-Za-zÀ-ÖØ-öø-ÿ\s-]+$"))
                throw new InvalidValueObjectException($"Invalid Neighborhood: {neighborhood}");

            if (string.IsNullOrWhiteSpace(city) || !Regex.IsMatch(city, @"^[A-Za-zÀ-ÖØ-öø-ÿ\s-]+$"))
                throw new InvalidValueObjectException($"Invalid City: {city}");

            if (string.IsNullOrWhiteSpace(state) || !Regex.IsMatch(state, @"^(AC|AL|AP|AM|BA|CE|DF|ES|GO|MA|MT|MS|MG|PA|PB|PR|PE|PI|RJ|RN|RS|RO|RR|SC|SP|SE|TO)$"))
                throw new InvalidValueObjectException($"Invalid State: {state}");

            if (string.IsNullOrWhiteSpace(zipCode) || !Regex.IsMatch(zipCode, @"^\d{5}-?\d{3}$"))
                throw new InvalidValueObjectException($"Invalid CEP: {zipCode}");

            Street = street.Trim();
            Neighborhood = neighborhood.Trim();
            City = city.Trim();
            State = state.ToUpper();
            ZipCode = zipCode;
        }

        public string Street { get; }
        public string Neighborhood { get; }
        public string City { get; }
        public string State { get; }
        public string ZipCode { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return Neighborhood;
            yield return City;
            yield return State;
            yield return ZipCode;
        }
    }
}