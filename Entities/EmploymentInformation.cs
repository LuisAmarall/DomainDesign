using DomainDesign.Exceptions;
using DomainDesign.ValueObjects;
using System;

namespace DomainDesign.Entities
{
    public class EmploymentInformation
    {
        public enum LinkStatus
        {
            Active,
            OnLeave,
            Suspended,
            Terminated
        }

        protected EmploymentInformation() { }

        public EmploymentInformation(
            Guid personId,
            Position position,
            uint weeklyWorkload,
            LinkStatus employeeLinkStatus,
            DateTime registrationDate)
        {
            if (personId == Guid.Empty) throw new RequiredFieldException("PersonId");
            if (position == null) throw new RequiredFieldException("Position");
            if (weeklyWorkload == 0) throw new RequiredFieldException("WeeklyWorkload must be greater than 0");

            EmploymentInformationId = Guid.NewGuid();
            PersonId = personId;
            Position = position;
            WeeklyWorkload = weeklyWorkload;
            EmployeeLinkStatus = employeeLinkStatus.ToString();
            RegistrationDate = registrationDate;
        }

        public Guid EmploymentInformationId { get; private set; }
        public Guid PersonId { get; private set; }
        public Position Position { get; private set; }
        public uint WeeklyWorkload { get; private set; }
        public string EmployeeLinkStatus { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public DateTime? DeactivationDate { get; private set; }

        public bool IsActive => DeactivationDate == null;
        public LinkStatus Status => (LinkStatus)Enum.Parse(typeof(LinkStatus), EmployeeLinkStatus);

        public void ChangePosition(Position newPosition)
        {
            if (newPosition == null) throw new RequiredFieldException("Position");
            if (Position.Equals(newPosition)) throw new InvalidValueObjectException("Position already in use");
            Position = newPosition;
        }

        public void ChangeWeeklyWorkload(uint workload)
        {
            if (workload == 0) throw new RequiredFieldException("WeeklyWorkload must be greater than 0");
            if (workload == WeeklyWorkload) throw new InvalidValueObjectException("Workload already in use");
            WeeklyWorkload = workload;
        }

        public void ChangeEmployeeLinkStatus(LinkStatus linkStatus)
        {
            if (linkStatus.ToString() == EmployeeLinkStatus)
                throw new InvalidValueObjectException("Link status already in use");
            EmployeeLinkStatus = linkStatus.ToString();
        }

        public void SoftDeactivate()
        {
            if (!IsActive) throw new InvalidValueObjectException("Already deactivated");
            DeactivationDate = DateTime.UtcNow;
        }

        public void Reactivate()
        {
            if (IsActive) throw new InvalidOperationException("Already active");
            DeactivationDate = null;
        }
    }
}