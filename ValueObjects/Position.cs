using DomainDesign.Shared;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DomainDesign.Exceptions;

namespace DomainDesign.ValueObjects
{
    public class Position : ValueObject<Position>
    {
        private Position() { }

        public Position(string position, string hierarchicalLevel)
        {
            var pattern = "^[A-Za-zÀ-ÖØ-öø-ÿ\\s]+$";

            if (string.IsNullOrWhiteSpace(position) || !Regex.IsMatch(position, pattern))
                throw new InvalidValueObjectException($"Invalid Position: {position}! Please check.");

            if (string.IsNullOrWhiteSpace(hierarchicalLevel) || !Regex.IsMatch(hierarchicalLevel, pattern))
                throw new InvalidValueObjectException($"Invalid Hierarchical Level: {hierarchicalLevel}! Please check.");

            JobPosition = position;
            HierarchicalLevel = hierarchicalLevel;
        }

        public string JobPosition { get; }
        public string HierarchicalLevel { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return JobPosition;
            yield return HierarchicalLevel;
        }
    }
}
