using PortalNFE.Core.DomainObjects;

namespace PortalNFE.Authorizations.Domain.Models
{
    public class ClaimsTypeAuthorization : Entity
    {
        public string ClaimName { get; set; }
        public string Description { get; set; }
    }
}
