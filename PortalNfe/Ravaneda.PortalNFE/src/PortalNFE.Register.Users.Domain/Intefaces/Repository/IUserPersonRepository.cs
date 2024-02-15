using PortalNFE.Core.Interfaces;
using PortalNFE.Register.Users.Domain.Models;
using System.Linq.Expressions;

namespace PortalNFE.Register.Users.Domain.Intefaces.Repository
{
    public interface IUserPersonRepository : IRepository<UserPerson>
    {
        Task UserPersonAdd(UserPerson userPerson);
        Task<int> UserPersonUpdate(UserPerson userPerson);
        Task<int> UserPersonRemover(Guid id);
        Task<UserPerson> UserPersonById(Guid id);
        Task<UserPerson> CompanyByEmail(string email);
        Task<IEnumerable<UserPerson>> SearchPerson(Expression<Func<UserPerson, bool>> predicate);
    }
}
