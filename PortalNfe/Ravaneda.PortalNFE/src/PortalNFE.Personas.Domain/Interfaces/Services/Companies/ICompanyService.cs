using PortalNFE.Personas.Domain.Models.Companies;

namespace PortalNFE.Personas.Domain.Interfaces.Services.Companies
{
    public interface ICompanyService : IDisposable
    {
        Task<bool> CompanyAdd(Company company);
        Task<bool> CompanyUpdate(Company company);
        Task<bool> CompanyRemover(Guid id);
    }
}
