using PortalNFE.Core.Interfaces;
using PortalNFE.Core.Services;
using PortalNFE.Identity.Domain.Interfaces;
using PortalNFE.Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalNFE.Identity.Domain.Services
{
    public class AuthorizationsService : BaseService, IAuthorizationsService
    {
        public AuthorizationsService(INotifier notifier) : base(notifier)
        {
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
