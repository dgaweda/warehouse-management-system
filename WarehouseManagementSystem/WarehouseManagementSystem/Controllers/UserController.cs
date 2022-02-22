using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using warehouse_management_system.Controllers.BaseController;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.User;

namespace warehouse_management_system.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ApiControllerBase<UserController>
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator, ILogger<UserController> logger) 
            : base(mediator, logger)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Authenticate/")]
        public async Task<IActionResult> AuthenticateUser([FromBody] AuthenticateUserRequest request)
        {
            var response = await _mediator.Send(request);
            
        }
        
        [HttpPost]
        [Route("Add/")]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest request) => await Handle<AddUserRequest, AddUserResponse>(request);

        [HttpGet]
        [Route("Details/")]
        public async Task<IActionResult> GetUserDetails([FromQuery] AuthenticateUserRequest request) => await Handle<AuthenticateUserRequest, GetUserResponse>(request);

        [HttpGet]
        [Route("Get/")]
        public async Task<IActionResult> GetUsers([FromQuery] GetUsersRequest request) => await Handle<GetUsersRequest, GetUsersResponse>(request);

        [HttpPut]
        [Route("Edit/")]
        public async Task<IActionResult> EditUser([FromBody] EditUserRequest request) => await Handle<EditUserRequest, EditUserResponse>(request);

        [HttpDelete]
        [Route("Remove/")]
        public async Task<IActionResult> RemoveUser([FromQuery] RemoveUserRequest request) => await Handle<RemoveUserRequest, RemoveUserResponse>(request);
    }
}
