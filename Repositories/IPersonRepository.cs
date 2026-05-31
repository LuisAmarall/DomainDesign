using DomainDesign.Entities;
using DomainDesign.ValueObjects;
using System;
using System.Threading.Tasks;

namespace DomainDesign.Repositories.Interfaces
{
    public interface IPersonRepository : IRepository<PersonalInformation, Guid>
    {
        Task<PersonalInformation> FindByCpf(Cpf cpf);

        Task<PersonalInformation> FindByName(string name);

        Task<PersonalInformation> FindByEmail(Email email);
    }
}