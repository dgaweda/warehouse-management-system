using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using warehouse_management_system.Authentication;
using warehouse_management_system.Authentication.Privileges;
using warehouse_management_system.Controllers.BaseController;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Role;

namespace warehouse_management_system.Controllers
{
    [Authorize]
    [Route("api/role/")]
    [ApiController]
    public class RoleController : ApiControllerBase
    {
        public RoleController(IMediator mediator) 
            : base(mediator)
        {
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddRole([FromBody] AddRoleRequest request) => await Handle<AddRoleRequest, AddRoleResponse>(request);

        [HttpGet]
        public async Task<IActionResult> GetRoles([FromQuery] GetRolesRequest request) => await Handle<GetRolesRequest, GetRolesResponse>(request);

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> EditRole([FromBody] EditRoleRequest request) => await Handle<EditRoleRequest, EditRoleResponse>(request);


        [HttpDelete]
        [Route("remove/{RoleId}")]
        public async Task<IActionResult> RemoveRole([FromRoute] RemoveRoleRequest request) => await Handle<RemoveRoleRequest, RemoveRoleResponse>(request);
    }
}
