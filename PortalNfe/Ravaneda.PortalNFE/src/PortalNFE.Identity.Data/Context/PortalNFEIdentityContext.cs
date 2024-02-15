using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortalNFE.Identity.Domain.Extensions;

namespace PortalNFE.Identity.Data.Context
{
    public class PortalNFEIdentityContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public PortalNFEIdentityContext(DbContextOptions<PortalNFEIdentityContext> options) : base(options) { }
    }
}
