using Microsoft.Extensions.DependencyInjection;
using PortalNFE.Orders.Data.Repositories;
using PortalNFE.Orders.Domain.Interfaces.Repositories;
using PortalNFE.Orders.Domain.Interfaces.Services;
using PortalNFE.Orders.Domain.Services;

namespace PortalNFE.Orders.Application.IoC
{
    public static class NativeInjectorOrdersBootStrapper
    {
        public static void RegisterOrdersIoCServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }
    }
}
