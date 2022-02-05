using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Employee;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Employee;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;
using Microsoft.Extensions.Logging;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.User;

namespace warehouse_management_system.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ApiControllerBase<UserController>
    {
        public UserController(IMediator mediator, ILogger<UserController> logger) 
            : base(mediator, logger)
        {
        }
        
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest request) => await Handle<AddUserRequest, AddUserResponse>(request);

        [HttpGet]
        [Route("current")]
        public async Task<IActionResult> GetCurrentUser([FromQuery] GetUserRequest request) => await Handle<GetUserRequest, GetUserResponse>(request);

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetUsers([FromQuery] GetUsersRequest request) => await Handle<GetUsersRequest, GetUsersResponse>(request);

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> EditUser([FromBody] EditUserRequest request) => await Handle<EditUserRequest, EditUserResponse>(request);

        [HttpDelete]
        [Route("remove")]
        public async Task<IActionResult> RemoveUser([FromQuery] RemoveUserRequest request) => await Handle<RemoveUserRequest, RemoveUserResponse>(request);
    }
}
