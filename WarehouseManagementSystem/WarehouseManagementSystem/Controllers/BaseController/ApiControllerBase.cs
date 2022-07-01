using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;

namespace warehouse_management_system.Controllers.BaseController
{
    public abstract class ApiControllerBase : ControllerBase
    {
        private readonly IMediator _mediator;
        protected ApiControllerBase(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected async Task<IActionResult> Handle<TRequest, TResponse>(TRequest request)
            where TRequest : IRequest<TResponse>
        {
            if (User.IsPermitted(request) || request.IsAuthenticateUserRequest())
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }

            throw new NotAuthenticatedException($"User {User.Identity.Name} is not authenticated.");
        }
    }
}
