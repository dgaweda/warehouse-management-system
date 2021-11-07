using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;

namespace warehouse_management_system.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeliveryController : ControllerHandler
    {
        public DeliveryController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetDeliveries([FromQuery] GetDeliveriesRequest request) => await Handle(request);

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddDelivery([FromBody] AddDeliveryRequest request) => await Handle(request);

        [HttpDelete]
        [Route("Remove")]
        public async Task<IActionResult> RemoveDelivery([FromBody] RemoveDeliveryRequest request) => await Handle(request);
    }
}
