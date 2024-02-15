using PortalNFE.Core.DomainObjects;

namespace PortalNFE.Register.Users.Domain.Models
{
    public class UserPersonCompany : Entity
    {
        public UserPersonCompany(Guid userPersonId, Guid companyId)
        {
            UserPersonId = userPersonId;
            CompanyId = companyId;
        }
        public Guid UserPersonId { get; private set; }
        public Guid CompanyId { get; private set; }
        public bool Active { get; private set; }
    }
}
