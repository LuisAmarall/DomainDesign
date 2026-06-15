using DomainDesign.Exceptions;
using DomainDesign.Shared;
using System;
using System.Collections.Generic;

namespace DomainDesign.ValueObjects
{
    public class BirthDate : ValueObject<BirthDate>
    {
        public BirthDate() { }

        public BirthDate(DateTime born)
        {
            if (born == default)
                throw new InvalidValueObjectException("Birth date cannot be empty");

            if (born > DateTime.Today)
                throw new InvalidValueObjectException("Birth date cannot be in the future");

            if (born < new DateTime(1900, 1, 1))
                throw new InvalidValueObjectException("Birth date cannot be before 1900");

            Born = born;
        }

        public DateTime Born { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Born;
        }
    }
}