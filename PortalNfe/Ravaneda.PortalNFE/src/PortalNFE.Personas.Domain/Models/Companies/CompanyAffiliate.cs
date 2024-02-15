using PortalNFE.Core.DomainObjects;
using PortalNFE.Personas.Domain.Enums.Companies;

namespace PortalNFE.Personas.Domain.Models.Companies
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
