using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Users;

namespace warehouse_management_system.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ApiControllerBase<UsersController>
    {
        public UsersController(IMediator mediator, ILogger<UsersController> logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("All")]
        public Task<IActionResult> GetAll([FromQuery] GetUsersRequest request) => Handle<GetUsersRequest, GetUsersResponse>(request);

        [AllowAnonymous]
        [HttpPost]
        [Route("Create")]
        public Task<IActionResult> Create([FromBody] CreateUserRequest request) => Handle<CreateUserRequest, CreateUserResponse>(request);
    }
}
