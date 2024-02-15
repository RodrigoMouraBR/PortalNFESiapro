using PortalNFE.Orders.Domain.Models;

namespace PortalNFE.Orders.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        Task<bool> OrderCreate(Order order);
    }
}
