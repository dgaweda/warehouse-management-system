using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Seniority;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Seniority;

namespace warehouse_management_system.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SeniorityController : ApiControllerBase<SeniorityController>
    {
        public SeniorityController(IMediator mediator, ILogger<SeniorityController> logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("All")]
        public Task<IActionResult> GetSeniorities([FromQuery] GetSenioritiesRequest request) => Handle<GetSenioritiesRequest, GetSenioritiesResponse>(request);

        [HttpPost]
        [Route("Add")]
        public Task<IActionResult> AddSeniority([FromBody] AddSeniorityRequest request) => Handle<AddSeniorityRequest, AddSeniorityResponse>(request);

        [HttpPut]
        [Route("Edit")]
        public Task<IActionResult> EditSeniority([FromBody] EditSeniorityRequest request) => Handle<EditSeniorityRequest, EditSeniorityResponse>(request);
    }
}
