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
    public class RoleController : ControllerHandler
    {
        public RoleController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddRole([FromBody] AddRoleRequest request) => await Handle(request);

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetRoles([FromQuery] GetRolesRequest request) => await Handle(request);

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> EditRole([FromBody] EditRoleRequest request) => await Handle(request);


        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> RemoveRole([FromBody] RemoveRoleRequest request) => await Handle(request);
    }
}
