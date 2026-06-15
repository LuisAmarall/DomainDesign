using DomainDesign.Exceptions;
using DomainDesign.Shared;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DomainDesign.ValueObjects
{
    public class Name : ValueObject<Name>
    {
        private Name() { }

        public Name(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || !Regex.IsMatch(name, @"^[A-Za-zÀ-ÖØ-öø-ÿ\s]+$"))
                throw new InvalidValueObjectException($"Invalid Name: {name}! Please check."); 

            IndividualsName = name.Trim();
        }

        public string IndividualsName { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return IndividualsName;
        }
    }
}
