using Microsoft.AspNetCore.Mvc;
using PortalNFE.Api.Controllers;
using PortalNFE.Core.Interfaces;
using PortalNFE.Orders.Application.ViewModels.Requests;
using PortalNFE.Orders.Application.ViewModels.Response;

namespace PortalNFE.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Orders")]
    public class OrdersController : MainController
    {
        public OrdersController(INotifier notificador) : base(notificador)
        {
        }

        [HttpPost("OrderCreate")]
        public async Task<ActionResult<OrderResponseViewModel>> OrderCreate(OrderRequestViewModel orderRequestViewModel)
        {



            return CustomResponse(orderRequestViewModel);
        }
    }
}
