using DomainDesign.Shared;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;
using DomainDesign.Exceptions;

namespace DomainDesign.ValueObjects
{
    public class BirthDate : ValueObject<BirthDate>
    {
        public BirthDate() { }

        public BirthDate(DateTime born)
        {
            var date = ConvertToString(born);

            if (string.IsNullOrWhiteSpace(date))
                throw new InvalidValueObjectException("Born date cannot be empty.");

            if (!DateTime.TryParseExact(date, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out var parsedDate))
                throw new InvalidValueObjectException($"Invalid Born date format: {born}");

            if (parsedDate > DateTime.Today)
                throw new InvalidValueObjectException("Born date cannot be in the future.");

            Born = born;
        }

        public DateTime Born { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Born;
        }

        private string ConvertToString(DateTime born)
        {
            string bornConvert = Convert.ToString(born);
            return bornConvert;
        }
    }
}
