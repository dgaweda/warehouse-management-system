using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Seniority;

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
        public async Task<IActionResult> GetSeniorities([FromQuery] GetSenioritiesRequest request) => await Handle(request);

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddSeniority([FromQuery] AddSeniorityRequest request) => await Handle(request);

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> EditSeniority([FromQuery] EditSeniorityRequest request) => await Handle(request);
    }
}
