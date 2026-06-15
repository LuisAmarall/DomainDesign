using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainDesign.Repositories.Interfaces
{
    public interface IRepository<Type, Identity> where Type : class
    {
        Task<IEnumerable<Type>> FindAll();

        Task<Type> FindById(Identity id);

        Task<Type> Add(Type entity);

        Task<Type> Update(Type entity);

        Task Delete(Type entity);
    }
}