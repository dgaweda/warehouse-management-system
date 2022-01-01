using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Role;

namespace warehouse_management_system.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoleController : ApiControllerBase<RoleController>
    {
        public RoleController(IMediator mediator, ILogger<RoleController> logger) : base(mediator, logger)
        {
        }

        [HttpPost]
        [Route("Add")]
        public Task<IActionResult> AddRole([FromBody] AddRoleRequest request) => Handle<AddRoleRequest, AddRoleResponse>(request);

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetRoles([FromQuery] GetRolesRequest request) => Handle<GetRolesRequest, GetRolesResponse>(request);

        [HttpPut]
        [Route("Edit")]
        public Task<IActionResult> EditRole([FromBody] EditRoleRequest request) => Handle<EditRoleRequest, EditRoleResponse>(request);


        [HttpDelete]
        [Route("Delete")]
        public Task<IActionResult> RemoveRole([FromBody] RemoveRoleRequest request) => Handle<RemoveRoleRequest, RemoveRoleResponse>(request);
    }
}
