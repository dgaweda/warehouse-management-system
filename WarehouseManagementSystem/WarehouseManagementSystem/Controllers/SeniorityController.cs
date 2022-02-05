﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using warehouse_management_system.Authentication;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Seniority;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Seniority;

namespace warehouse_management_system.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class SeniorityController : ApiControllerBase<SeniorityController>
    {
        public SeniorityController(IMediator mediator, ILogger<SeniorityController> logger, IPrivilegesService privileges) 
            : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("all")]
        public Task<IActionResult> GetSeniorities([FromQuery] GetSenioritiesRequest request) => Handle<GetSenioritiesRequest, GetSenioritiesResponse>(request);

        [HttpPost]
        [Route("add")]
        public Task<IActionResult> AddSeniority([FromBody] AddSeniorityRequest request) => Handle<AddSeniorityRequest, AddSeniorityResponse>(request);

        [HttpPut]
        [Route("edit")]
        public Task<IActionResult> EditSeniority([FromBody] EditSeniorityRequest request) => Handle<EditSeniorityRequest, EditSeniorityResponse>(request);
    }
}
