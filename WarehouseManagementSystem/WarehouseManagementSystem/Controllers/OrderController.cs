using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetOrders(GetOrdersRequest request) => await Handle<GetOrdersRequest, GetOrdersResponse>(request);
        
        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetOrderById([FromRoute] GetOrderByIdRequest request) => await Handle<GetOrderByIdRequest, GetOrderByIdResponse>(request);
        
        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] AddOrderRequest request) => await Handle<AddOrderRequest, AddOrderResponse>(request);
        
        [HttpPut]
        public async Task<IActionResult> EditOrder([FromBody] EditOrderRequest request) => await Handle<EditOrderRequest, EditOrderResponse>(request);
        
        [HttpDelete]   
        [Route("{Id}")]
        public async Task<IActionResult> RemoveOrder([FromRoute] RemoveOrderRequest request) => await Handle<RemoveOrderRequest, RemoveOrderResponse>(request);
    }
}
