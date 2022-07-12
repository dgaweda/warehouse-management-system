
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using warehouse_management_system.Controllers.BaseController;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.User;

namespace warehouse_management_system.Controllers
{
    
    [ApiController]
    [Route("/api/user/")]
    public class UserController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
            : base(mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> AuthenticateUser([FromBody] AuthenticateUserRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        } 

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest request) => await Handle<AddUserRequest, AddUserResponse>(request);

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] GetUsersRequest request) => await Handle<GetUsersRequest, GetUsersResponse>(request);

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> EditUser([FromBody] EditUserRequest request) => await Handle<EditUserRequest, EditUserResponse>(request);

        [Authorize]
        [HttpDelete]
        [Route("{UserId}")]
        public async Task<IActionResult> RemoveUser([FromRoute] RemoveUserRequest request) => await Handle<RemoveUserRequest, RemoveUserResponse>(request);
    }
}
