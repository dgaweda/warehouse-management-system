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
    public class DeliveryProductController : ControllerBase
    {
        private readonly IMediator mediator;
        public DeliveryProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAllDeliveryProducts([FromQuery] GetDeliveryProductsRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
