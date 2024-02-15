using Microsoft.EntityFrameworkCore;
using PortalNFE.Core.Interfaces;
using PortalNFE.Register.Companies.Data.Context;
using PortalNFE.Register.Companies.Domain.Interfaces.Repositories;
using PortalNFE.Register.Companies.Domain.Models;
using System.Linq.Expressions;

namespace PortalNFE.Register.Companies.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly PortalNFECompaniesContext _context;
        public CompanyRepository(PortalNFECompaniesContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<int> CompanyAdd(Company company)
        {
            await _context.Companies.AddAsync(company);
            return await _context.SaveChangesAsync();
        }

        public async Task CompanyRemover(Guid id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company != null)
                _context.Companies.Remove(company);
        }

        public void CompanyUpdate(Company company)
        {
            _context.Companies.Update(company);
        }
        public async Task<Company> CompanyById(Guid id)
        {
            return await _context.Companies.FindAsync(id);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<Company> CompanyByDocument(string document)
        {
            return await _context.Companies.FirstOrDefaultAsync(p => p.Document == document);
        }

        public async Task<IEnumerable<Company>> SearchCompany(Expression<Func<Company, bool>> predicate)
        {
            return await _context.Companies.AsNoTracking().Where(predicate).ToListAsync();
        }
    }
}
