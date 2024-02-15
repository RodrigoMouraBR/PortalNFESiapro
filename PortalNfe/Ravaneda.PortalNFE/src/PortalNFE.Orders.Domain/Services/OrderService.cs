using PortalNFE.Orders.Domain.Interfaces.Repositories;
using PortalNFE.Orders.Domain.Interfaces.Services;
using PortalNFE.Orders.Domain.Models;

namespace PortalNFE.Orders.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> OrderCreate(Order order)
        {
           return await _orderRepository.OrderCreate(order);
        }
    }
}
