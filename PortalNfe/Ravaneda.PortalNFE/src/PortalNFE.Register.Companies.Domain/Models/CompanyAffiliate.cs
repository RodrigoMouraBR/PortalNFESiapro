using PortalNFE.Core.DomainObjects;
using PortalNFE.Register.Companies.Domain.Enums;

namespace PortalNFE.Register.Companies.Domain.Models
{
    public class CompanyAffiliate : Entity
    {
        public CompanyAffiliate(Guid affiliateCompanyId, Guid rootCompanyId, ECompanyStatus companyStatus)
        {
            AffiliateCompanyId = affiliateCompanyId;
            RootCompanyId = rootCompanyId;
            CompanyStatus = companyStatus;
        }

        protected CompanyAffiliate()
        {
        }
        public Guid AffiliateCompanyId { get; private set; }
        public Guid RootCompanyId { get; private set; }       
        public ECompanyStatus CompanyStatus { get; private set; }
        public Company Company { get; private set; }
    }
}
