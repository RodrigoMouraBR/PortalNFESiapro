using Microsoft.EntityFrameworkCore;
using PortalNFE.Core.Interfaces;
using PortalNFE.Register.Users.Data.Context;
using PortalNFE.Register.Users.Domain.Intefaces.Repository;
using PortalNFE.Register.Users.Domain.Models;
using System.Linq.Expressions;

namespace PortalNFE.Register.Users.Data.Repositories
{
    public class UserPersonRepository : IUserPersonRepository
    {

        private readonly PortalNFEUserPersonContext _context;
        public UserPersonRepository(PortalNFEUserPersonContext context) => _context = context;

        public IUnitOfWork UnitOfWork => _context;

        public async Task UserPersonAdd(UserPerson userPerson)
        {
            await _context.UserPersons.AddAsync(userPerson);            
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> UserPersonUpdate(UserPerson userPerson)
        {
            _context.UserPersons.Update(userPerson);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UserPersonRemover(Guid id)
        {
            var company = await _context.UserPersons.FindAsync(id);
            _context.UserPersons.Update(company);
            return await _context.SaveChangesAsync();
        }

        public async Task<UserPerson> UserPersonById(Guid id)
        {
            return await _context.UserPersons.FindAsync(id);
        }

        public async Task<UserPerson> CompanyByEmail(string email)
        {
            return await _context.UserPersons.FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task<IEnumerable<UserPerson>> SearchPerson(Expression<Func<UserPerson, bool>> predicate)
        {
            return await _context.UserPersons.AsNoTracking().Where(predicate).ToListAsync();            
        }
    }
}
