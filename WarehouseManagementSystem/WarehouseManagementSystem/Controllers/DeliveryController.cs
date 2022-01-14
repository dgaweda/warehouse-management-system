using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Delivery;

namespace warehouse_management_system.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class DeliveryController : ApiControllerBase<DeliveryController>
    {
        public DeliveryController(IMediator mediator, ILogger<DeliveryController> logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetDeliveries([FromQuery] GetDeliveriesRequest request) => await Handle<GetDeliveriesRequest, GetDeliveriesResponse>(request);

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
