using PortalNFE.Register.Companies.Application.ViewModels.Companies.Requests.CompanyAdd;
using PortalNFE.Register.Companies.Application.ViewModels.Companies.Requests.CompanyUpdate;

namespace PortalNFE.Register.Companies.Application.Interfaces
{
    public interface ICompanyAppService : IDisposable
    {
        Task<bool> CompanyRootAdd(CompanyAddViewModel companyAddViewModel);
        Task<bool> CompanyAffiliateAdd(CompanyAffiliateAddViewModel companyAffiliateAddViewModel);
        Task<bool> CompanyUpdate(CompanyUpdateViewModel companyUpdateViewModel);
        Task<bool> CompanyRemover(Guid id);       
    }
}
