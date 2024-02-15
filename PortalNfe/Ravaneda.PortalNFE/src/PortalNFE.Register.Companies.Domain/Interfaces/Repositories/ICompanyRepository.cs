using PortalNFE.Core.Interfaces;
using PortalNFE.Register.Companies.Domain.Models;
using System.Linq.Expressions;

namespace PortalNFE.Register.Companies.Domain.Interfaces.Repositories
{
    public interface ICompanyRepository :  IRepository<Company>
    {
       
        Task<int> CompanyAdd(Company company);
        void CompanyUpdate(Company company);
        Task CompanyRemover(Guid id);
        Task<Company> CompanyById(Guid id);
        Task<Company> CompanyByDocument(string document);
        Task<IEnumerable<Company>> SearchCompany(Expression<Func<Company, bool>> predicate);
    }
}
