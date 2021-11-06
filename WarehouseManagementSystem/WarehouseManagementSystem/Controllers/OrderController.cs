using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;

namespace warehouse_management_system.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerHandler
    {
        public OrderController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAllOrders([FromQuery] GetOrdersRequest request) => await Handle(request);
    }
}
