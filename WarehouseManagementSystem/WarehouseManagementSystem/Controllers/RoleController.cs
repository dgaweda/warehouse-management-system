using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role;

namespace warehouse_management_system.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator mediator;
        public RoleController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAllRoles([FromQuery] GetRolesRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> EditRole([FromBody] EditRoleRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddRole([FromBody] AddRoleRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
