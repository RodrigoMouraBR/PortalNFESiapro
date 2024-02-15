using PortalNFE.Core.DomainObjects;

namespace PortalNFE.Authorizations.Domain.Models
{
    public class UserPerson : Entity
    {
        public UserPerson(string name)
        {
            Name = name;
        }
        public string Name { get; private set; } = string.Empty;
    }
}
