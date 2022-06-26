using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using warehouse_management_system.Controllers.BaseController;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Order;

namespace warehouse_management_system.Controllers
{
    [Authorize]
    [Route("/api/order/")]
    [ApiController]
    public class OrderController : ApiControllerBase
    {
        public OrderController(IMediator mediator) 
            : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders([FromQuery] GetOrdersRequest request) => await Handle<GetOrdersRequest, GetOrdersResponse>(request);
        
        [HttpPost]   
        [Route("add")]
        public async Task<IActionResult> AddOrder([FromBody] AddOrderRequest request) => await Handle<AddOrderRequest, AddOrderResponse>(request);
        
        [HttpPut]   
        [Route("edit")]
        public async Task<IActionResult> EditOrder([FromBody] EditOrderRequest request) => await Handle<EditOrderRequest, EditOrderResponse>(request);
        
        [HttpDelete]   
        [Route("remove/{Id}")]
        public async Task<IActionResult> RemoveOrder([FromRoute] RemoveOrderRequest request) => await Handle<RemoveOrderRequest, RemoveOrderResponse>(request);
    }
}
