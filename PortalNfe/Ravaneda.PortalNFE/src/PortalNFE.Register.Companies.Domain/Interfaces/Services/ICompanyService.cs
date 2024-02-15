using PortalNFE.Register.Companies.Domain.Models;

namespace PortalNFE.Register.Companies.Domain.Interfaces.Services
{
    public interface ICompanyService : IDisposable
    {
        Task<bool> CompanyAdd(Company company);
        Task<bool> CompanyUpdate(Company company);
        Task<bool> CompanyRemover(Guid id);        
    }
}
