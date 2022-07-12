using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> AddRole([FromBody] AddRoleRequest request) => await Handle<AddRoleRequest, AddRoleResponse>(request);

        [HttpGet]
        public async Task<IActionResult> GetRoles([FromQuery] GetRolesRequest request) => await Handle<GetRolesRequest, GetRolesResponse>(request);

        [HttpPut]
        public async Task<IActionResult> EditRole([FromBody] EditRoleRequest request) => await Handle<EditRoleRequest, EditRoleResponse>(request);


        [HttpDelete]
        [Route("{RoleId}")]
        public async Task<IActionResult> RemoveRole([FromRoute] RemoveRoleRequest request) => await Handle<RemoveRoleRequest, RemoveRoleResponse>(request);
    }
}
