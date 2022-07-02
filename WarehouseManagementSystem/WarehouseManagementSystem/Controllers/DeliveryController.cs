using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using warehouse_management_system.Controllers.BaseController;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Delivery;

namespace warehouse_management_system.Controllers
{
    [Route("/api/delivery/")]
    [ApiController]
    public class DeliveryController : ApiControllerBase
    {
        public DeliveryController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetDeliveries([FromQuery] GetDeliveriesRequest request) => await Handle<GetDeliveriesRequest, GetDeliveriesResponse>(request);

        [HttpPost]
        public async Task<IActionResult> AddDelivery([FromBody] AddDeliveryRequest request) => await Handle<AddDeliveryRequest, AddDeliveryResponse>(request);

        [HttpDelete]
        [Route("{DeliveryId}")]
        public async Task<IActionResult> RemoveDelivery([FromRoute] RemoveDeliveryRequest request) => await Handle<RemoveDeliveryRequest, RemoveDeliveryResponse>(request);

        [HttpPut]
        public async Task<IActionResult> EditDelivery([FromBody] EditDeliveryRequest request) => await Handle<EditDeliveryRequest, EditDeliveryResponse>(request);
    }
}
