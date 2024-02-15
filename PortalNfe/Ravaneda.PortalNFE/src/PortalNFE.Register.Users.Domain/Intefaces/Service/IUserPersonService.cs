using PortalNFE.Register.Users.Domain.Models;

namespace PortalNFE.Register.Users.Domain.Intefaces.Service
{
    public interface IUserPersonService : IDisposable
    {
        Task<bool> UserPersonAdd(UserPerson userPerson);
        Task<bool> UserPersonUpdate(UserPerson userPerson);
        Task<bool> UserPersonRemover(Guid id);
    }
}
