using PortalNFE.Orders.Domain.Models;

namespace PortalNFE.Orders.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<bool> OrderCreate(Order order);
    }
}
