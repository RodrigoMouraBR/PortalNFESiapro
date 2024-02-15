using PortalNFE.Identity.Data.Context;
using PortalNFE.Identity.Domain.Interfaces;
using PortalNFE.Identity.Domain.Models;

namespace PortalNFE.Identity.Data.Repositories
{
    public class AuthorizationsRepository : IAuthorizationsRepository
    {
        private readonly PortalNFEAuthorizationsContext _context;

        public AuthorizationsRepository(PortalNFEAuthorizationsContext context)
        {
            _context = context;
        }

        public Task CreateAspNetRole(AspNetRoles aspNetRoles)
        {
            throw new NotImplementedException();
        }

        public Task CreateAspNetUserRole(AspNetRoles aspNetRoles)
        {
            throw new NotImplementedException();
        }
    }
}
