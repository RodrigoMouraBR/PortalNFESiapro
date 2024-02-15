using PortalNFE.Register.Users.Application.ViewMoldes.Requests.UserPersonAdd;
using PortalNFE.Register.Users.Application.ViewMoldes.Requests.UserPersonUpdate;

namespace PortalNFE.Register.Users.Application.Interfaces
{
    public interface IUserPersonAppService : IDisposable
    {
        Task<bool> UserPersonAdd(UserPersonAddViewModel userPersonAddViewModel);      
        Task<bool> UserPersonUpdate(UserPersonUpdateViewModel userPersonUpdateViewModel);
        Task<bool> UserPersonRemover(Guid id);
    }
}
