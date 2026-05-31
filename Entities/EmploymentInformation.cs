using DomainDesign.Entities;
using DomainDesign.Exceptions;
using DomainDesign.ValueObjects;
using System;
using System.Collections.Generic;

namespace ProjectDesign.Entities
{
    public class EmploymentInformation : PersonalInformation
    {
        public enum LinkStatus
        {
            Active,
            OnLeave, 
            Suspended, 
            Terminated
        }

        protected EmploymentInformation() { }

        public EmploymentInformation(PersonalInformation person, Position position, uint weeklyWorkload, string employeeLinkStatus, 
            DateTime registrationDate) : base(person.Cpf, person.Name, person.Email, person.Phone,
                person.BirthDate, person.ResidentialAddress, registrationDate)
        {
            EmploymentInformationId = Guid.NewGuid();
            PersonId = person.PersonId;
            Person = person ?? throw new RequiredFieldException($"{Person}: Please note that the PersonalInformation field does not allow null values.");
            Position = position;
            WeeklyWorkload = weeklyWorkload;
            EmployeeLinkStatus = LinkStatus.Active.ToString();
            RegistrationDate = registrationDate;
        }

        public Guid EmploymentInformationId { get; private set; }
        public Guid PersonId { get; private set; }
        public PersonalInformation Person { get; private set; }
        
        public Position Position { get; private set; }
        public uint WeeklyWorkload { get; private set; }

        public string EmployeeLinkStatus { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public DateTime? DeactivationDate { get; private set; }
        public bool IsActive => DeactivationDate is null;

        public void ChangePosition(Position newPosition)
        {
            if (newPosition is null)
                throw new RequiredFieldException($"{newPosition}: Please note that the position field does not allow null values.");

            if (Position != null && Position.Equals(newPosition))
                throw new InvalidValueObjectException($"{newPosition}: Sorry, but this position is already in use.");

            Position = newPosition;
        }

        public void ChangeWeeklyWorkload(UInt16 workload)
        {
            if (workload == 0)
                throw new RequiredFieldException($"{workload}: Please note that the workload field does not allow null values.");

            if (workload.Equals(WeeklyWorkload))
                throw new InvalidValueObjectException($"{workload}: Sorry, but this workload is already in use.");

            WeeklyWorkload = workload;
        }

        public void ChangeEmployeeLinkStatus(LinkStatus link)
        {
            if (link.ToString().Equals(EmployeeLinkStatus))
                throw new InvalidValueObjectException($"{link}: Sorry, but this link status is already in use.");

            EmployeeLinkStatus = link.ToString();
        }

        public void SoftDeactivate()
        {
            if (!IsActive)
                throw new InvalidValueObjectException("The deactivation has already been completed.");

            DeactivationDate = DateTime.UtcNow;
        }

        public void Reactivate()
        {
            if (IsActive)
                throw new InvalidOperationException("The activation has already been completed.");

            DeactivationDate = null;
        }
    }
}