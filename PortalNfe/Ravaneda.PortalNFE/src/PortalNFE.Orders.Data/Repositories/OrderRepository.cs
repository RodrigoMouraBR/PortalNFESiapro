using PortalNFE.Orders.Data.Context;
using PortalNFE.Orders.Domain.Interfaces.Repositories;
using PortalNFE.Orders.Domain.Models;

namespace PortalNFE.Orders.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PortalNFEOrdersContext _context;

        public OrderRepository(PortalNFEOrdersContext context)
        {
            _context = context;
        }

        public async Task<bool> OrderCreate(Order order)
        {
            await _context.Orders.AddAsync(order);
            var saveChanges =  await _context.SaveChangesAsync();

            if (saveChanges == 1) return true;

            return false;          
        }
    }
}
