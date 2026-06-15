using DomainDesign.Shared;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DomainDesign.Exceptions;

namespace DomainDesign.ValueObjects
{
    public class Specialty : ValueObject<Specialty>
    {
        private Specialty() { }

        public Specialty(string individualsSpecialty, string specialtyLevel)
        {
            var regex = new Regex("^[A-Za-zÀ-ÖØ-öø-ÿ\\s]+$");

            if (string.IsNullOrWhiteSpace(individualsSpecialty) || !regex.IsMatch(individualsSpecialty))
                throw new InvalidValueObjectException($"Invalid Specialty: {individualsSpecialty}. Please check.");

            if (string.IsNullOrWhiteSpace(specialtyLevel) || !regex.IsMatch(specialtyLevel))
                throw new InvalidValueObjectException($"Invalid Specialty Level: {specialtyLevel}. Please check.");

            IndividualsSpecialty = individualsSpecialty;
            SpecialtyLevel = specialtyLevel;
        }

        public string IndividualsSpecialty { get; }
        public string SpecialtyLevel { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return IndividualsSpecialty;
            yield return SpecialtyLevel;
        }
    }
}
