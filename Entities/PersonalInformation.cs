using DomainDesign.Exceptions;
using DomainDesign.ValueObjects;
using System;

namespace DomainDesign.Entities
{
    public class PersonalInformation
    {
        protected PersonalInformation() { }

        protected PersonalInformation(Cpf cpf, Name name, Email email, Phone phone, BirthDate birthDate, 
            Address residentialAddress,DateTime registrationDate)
        {
            PersonId = Guid.NewGuid();
            Cpf = cpf;
            Name = name;
            Email = email;
            Phone = phone;
            BirthDate = birthDate;
            ResidentialAddress = residentialAddress;
        }

        public Guid PersonId { get; private set; }
        public Cpf Cpf { get; private set; }
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Phone Phone { get; private set; }
        public BirthDate BirthDate { get; private set; }
        public Address ResidentialAddress { get; private set; }
        
        
        public void ChangeName(Name name)
        {
            if (name is null)
                throw new RequiredFieldException($"{name}: Please note that the name field does not allow null values.");
            
            if (name.Equals(Name))
                throw new InvalidValueObjectException($"{name}: Sorry, but this name is already in use.");
           
            Name = name;
        }

        public void ChangeEmail(Email email)
        {
            if (email is null)
                throw new RequiredFieldException($"{email} Please note that the E_mail field does not allow null values.");
            
            if (email.Equals(Email))
                throw new InvalidValueObjectException($"{email}: Sorry, but this E_mail is already in use.");

            Email = email;
        }

        public void ChangePhone(Phone phone)
        {
            if (phone is null)
                throw new RequiredFieldException($"{phone} Please note that the phone field does not allow null values.");

            if (phone.Equals(Phone))
                throw new InvalidValueObjectException($"{phone}: Sorry, but this phone is already in use.");

            Phone = phone;
        }

        public void ChangeAddress(Address address)
        {
            if (address is null)
                throw new RequiredFieldException($"{address} Please note that the address field does not allow null values.");

            if (address.Equals(ResidentialAddress))
                throw new InvalidValueObjectException($"{address}: Sorry, but this address is already in use.");

            ResidentialAddress = address;
        }
    }
}