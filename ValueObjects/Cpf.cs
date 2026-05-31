using DomainDesign.Exceptions;
using DomainDesign.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DomainDesign.ValueObjects
{
    public class Cpf : ValueObject<Cpf>
    {
        public Cpf() { }

        public Cpf(string document)
        {

            if (string.IsNullOrWhiteSpace(document))
                throw new InvalidValueObjectException("CPF cannot be empty.");

            document = Regex.Replace(document, @"\D", ""); // remove máscara

            if (document.Length != 11 || !Regex.IsMatch(document, @"^\d{11}$"))
                throw new InvalidValueObjectException($"Invalid CPF format: {document}");

            if (IsInvalidSequence(document) || !IsValidCpf(document))
                throw new InvalidValueObjectException($"Invalid CPF number: {document}");

            Document = document;
        }

        public string Document { get; }

        private bool IsInvalidSequence(string cpf) =>
            cpf.All(c => c == cpf[0]);

        private bool IsValidCpf(string cpf)
        {
            int[] multiplier1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            var tempCpf = cpf.Substring(0, 9);
            int sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];

            int remainder = sum % 11;
            remainder = remainder < 2 ? 0 : 11 - remainder;

            if (remainder != int.Parse(cpf[9].ToString()))
                return false;

            tempCpf += remainder;
            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];

            remainder = sum % 11;
            remainder = remainder < 2 ? 0 : 11 - remainder;

            return remainder == int.Parse(cpf[10].ToString());
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Document;
        }
    }
}
