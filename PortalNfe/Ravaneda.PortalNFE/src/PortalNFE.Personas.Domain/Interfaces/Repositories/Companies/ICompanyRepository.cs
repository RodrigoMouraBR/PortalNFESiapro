using PortalNFE.Core.Interfaces;
using PortalNFE.Personas.Domain.Models.Companies;
using System.Linq.Expressions;

namespace PortalNFE.Personas.Domain.Interfaces.Repositories.Companies
{
    public interface ICompanyRepository : IRepository<Company>
    {

        Task<int> CompanyAdd(Company company);
        void CompanyUpdate(Company company);
        Task CompanyRemover(Guid id);
        Task<Company> CompanyById(Guid id);
        Task<Company> CompanyByDocument(string document);
        Task<IEnumerable<Company>> SearchCompany(Expression<Func<Company, bool>> predicate);
    }
}
