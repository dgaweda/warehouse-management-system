using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using warehouse_management_system.Controllers.BaseController;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.OrderLine;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.OrderLine;

namespace warehouse_management_system.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderLineController: ApiControllerBase<OrderLineController>
    {
        public OrderLineController(IMediator mediator, ILogger<OrderLineController> logger) : base(mediator, logger)
        {
        }

        [HttpPost]
        [Route("Add/")]
        public Task<IActionResult> AddOrderLine([FromBody] AddOrderLineRequest request) =>
            Handle<AddOrderLineRequest, AddOrderLineResponse>(request);
    }
}