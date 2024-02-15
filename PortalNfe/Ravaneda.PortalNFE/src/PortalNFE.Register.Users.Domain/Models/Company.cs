using PortalNFE.Core.DomainObjects;

namespace PortalNFE.Register.Users.Domain.Models
{
    public class Company : Entity
    {
        public string FantasyName { get; private set; } = string.Empty;
        public string Document { get; private set; } = string.Empty;
    }
}
