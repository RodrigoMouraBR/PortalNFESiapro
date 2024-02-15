using PortalNFE.Identity.Domain.Models;

namespace PortalNFE.Identity.Domain.Interfaces
{
    public interface IAuthorizationsService
    {
        Task CreateAspNetRole(AspNetRoles aspNetRoles);
        Task CreateAspNetUserRole(AspNetRoles aspNetRoles);
    }
}
