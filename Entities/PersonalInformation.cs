using DomainDesign.Exceptions;
using DomainDesign.ValueObjects;
using System;
using System.Collections.Generic;

namespace DomainDesign.Entities
{
    public class PersonalInformation
    {
        protected PersonalInformation() { }

        public PersonalInformation(
            Cpf cpf,
            Name name,
            Email email,
            Phone phone,
            BirthDate birthDate,
            Address residentialAddress,
            DateTime registrationDate)
        {
            ValidateProperties(cpf, name, email, phone, birthDate, residentialAddress);

            PersonId = Guid.NewGuid();
            Cpf = cpf;
            Name = name;
            Email = email;
            Phone = phone;
            BirthDate = birthDate;
            ResidentialAddress = residentialAddress;
            RegistrationDate = registrationDate;
        }

        private void ValidateProperties(
            Cpf cpf, Name name, Email email, Phone phone,
            BirthDate birthDate, Address residentialAddress)
        {
            if (cpf == null) throw new RequiredFieldException("CPF");
            if (name == null) throw new RequiredFieldException("Name");
            if (email == null) throw new RequiredFieldException("Email");
            if (phone == null) throw new RequiredFieldException("Phone");
            if (birthDate == null) throw new RequiredFieldException("BirthDate");
            if (residentialAddress == null) throw new RequiredFieldException("ResidentialAddress");
        }

        public Guid PersonId { get; private set; }
        public Cpf Cpf { get; private set; }
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Phone Phone { get; private set; }
        public BirthDate BirthDate { get; private set; }
        public Address ResidentialAddress { get; private set; }
        public DateTime RegistrationDate { get; private set; }

        public void ChangeName(Name name)
        {
            if (name == null) throw new RequiredFieldException("Name");
            if (name.Equals(Name)) throw new InvalidValueObjectException("Name already in use");
            Name = name;
        }

        public void ChangeEmail(Email email)
        {
            if (email == null) throw new RequiredFieldException("Email");
            if (email.Equals(Email)) throw new InvalidValueObjectException("Email already in use");
            Email = email;
        }

        public void ChangePhone(Phone phone)
        {
            if (phone == null) throw new RequiredFieldException("Phone");
            if (phone.Equals(Phone)) throw new InvalidValueObjectException("Phone already in use");
            Phone = phone;
        }

        public void ChangeAddress(Address address)
        {
            if (address == null) throw new RequiredFieldException("Address");
            if (address.Equals(ResidentialAddress)) throw new InvalidValueObjectException("Address already in use");
            ResidentialAddress = address;
        }
    }
}