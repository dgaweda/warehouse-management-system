using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using warehouse_management_system.Controllers.BaseController;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.OrderLine;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.OrderLine;

namespace warehouse_management_system.Controllers
{
    [Route("/api/order/{orderId}/order-line/")]
    [ApiController]
    public class OrderLineController: ApiControllerBase
    {
        public OrderLineController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderLine([FromBody] AddOrderLineRequest request) => await Handle<AddOrderLineRequest, AddOrderLineResponse>(request);
    }
}