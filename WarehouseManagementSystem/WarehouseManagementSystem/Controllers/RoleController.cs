using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using warehouse_management_system.Authentication;
using warehouse_management_system.Controllers.BaseController;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Role;

namespace warehouse_management_system.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class RoleController : ApiControllerBase
    {
        public RoleController(IMediator mediator, IPrivilegesService privileges) 
            : base(mediator)
        {
        }

        [HttpPost]
        [Route("Add/")]
        public Task<IActionResult> AddRole([FromBody] AddRoleRequest request) => Handle<AddRoleRequest, AddRoleResponse>(request);

        [HttpGet]
        [Route("Get/")]
        public Task<IActionResult> GetRoles([FromQuery] GetRolesRequest request) => Handle<GetRolesRequest, GetRolesResponse>(request);

        [HttpPut]
        [Route("Edit/")]
        public Task<IActionResult> EditRole([FromBody] EditRoleRequest request) => Handle<EditRoleRequest, EditRoleResponse>(request);


        [HttpDelete]
        [Route("Delete/")]
        public Task<IActionResult> RemoveRole([FromBody] RemoveRoleRequest request) => Handle<RemoveRoleRequest, RemoveRoleResponse>(request);
    }
}
