using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;

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
        [Route("GetAll")]
        public async Task<IActionResult> GetAllDeliveries([FromQuery] GetDeliveriesRequest request) => await Handle<GetDeliveriesRequest>(request);
    }
}
