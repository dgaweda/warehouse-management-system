using MediatR;
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
    public class SeniorityController : ControllerBase
    {
        private readonly IMediator mediator;
        public SeniorityController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAllSeniorities([FromQuery] GetSenioritiesRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
