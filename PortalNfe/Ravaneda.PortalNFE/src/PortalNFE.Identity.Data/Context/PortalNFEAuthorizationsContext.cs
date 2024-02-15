using Microsoft.EntityFrameworkCore;
using PortalNFE.Core.Interfaces;

namespace PortalNFE.Identity.Data.Context
{
    public class PortalNFEAuthorizationsContext : DbContext, IUnitOfWork
    {
        public Task<bool> Commit()
        {
            throw new NotImplementedException();
        }
    }
}
