using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace warehouse_management_system.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ApiControllerBase<OrderController>
    {
        public OrderController(IMediator mediator, ILogger<OrderController> logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("All")]
        public Task<IActionResult> GetAllOrders([FromQuery] GetOrdersRequest request) => Handle<GetOrdersRequest, GetOrdersResponse>(request);
    }
}
