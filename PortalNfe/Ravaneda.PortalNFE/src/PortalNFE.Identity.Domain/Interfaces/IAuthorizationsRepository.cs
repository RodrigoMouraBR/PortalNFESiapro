using PortalNFE.Identity.Domain.Models;

namespace PortalNFE.Identity.Domain.Interfaces
{
    public interface IAuthorizationsRepository
    {
        Task CreateAspNetRole(AspNetRoles aspNetRoles);
        Task CreateAspNetUserRole(AspNetRoles aspNetRoles);
    }
}
