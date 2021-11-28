using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Delivery;

namespace warehouse_management_system.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeliveryController : ApiControllerBase
    {
        public DeliveryController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("Get")]
        public Task<IActionResult> GetDeliveries([FromQuery] GetDeliveriesRequest request) => Handle<GetDeliveriesRequest, GetDeliveriesResponse>(request);

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddDelivery([FromBody] AddDeliveryRequest request) => await Handle<AddDeliveryRequest, AddDeliveryResponse>(request);

        [HttpDelete]
        [Route("Remove")]
        public async Task<IActionResult> RemoveDelivery([FromQuery] RemoveDeliveryRequest request) => await Handle<RemoveDeliveryRequest, RemoveDeliveryResponse>(request);

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> EditDelivery([FromBody] EditDeliveryRequest request) => await Handle<EditDeliveryRequest, EditDeliveryResponse>(request);
    }
}
