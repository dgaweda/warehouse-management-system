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
    public class SeniorityController : ControllerHandler
    {
        public SeniorityController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAllSeniorities([FromQuery] GetSenioritiesRequest request) => await Handle(request);
    }
}
